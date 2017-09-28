using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Miko.CSharp.Form2048
{
    public partial class Form1 : Form
    {
        // 定义枚举 使四个动作分别对应一个数值
        enum actionType
        {
            none,
            up,
            down,
            left,
            right
        }

        const int gSize = 4;
        int[,] arr;         // 主存储数组

        bool gameOver;      // 在 reset() 中初始化

        int score;
        int scoreOld;

        Bitmap img;  // 绘图缓冲区
        Graphics g;
        Random r = new Random();    // 随机数生成器

        public Stack<int[,]> undoList;      // 撤销列表
        public Stack<int> scoreList;        // 撤销列表对应的分数

        // 初始化 / 重新开始
        void reset()
        {
            gameOver = false;   // 游戏是否结束
            score = 0;  // 分数
            scoreOld = -1;      // 分数不一致时刷新标签

            for (int i = 0; i < gSize; i++)
            {
                for (int j = 0; j < gSize; j++)
                {
                    arr[i, j] = 0;
                }
            }

            undoList.Clear();
            scoreList.Clear();

            randomNew();                    // 初始时随机生成两个数
            randomNew();

            setText();
            draw();
        }

        // 为每个数值设定不同颜色
        Brush switchBrush(int value)
        {
            switch (value)
            {
                case 0: return Brushes.White;
                case 2: return Brushes.LightSalmon;
                case 4: return Brushes.Peru;
                case 8: return Brushes.Chocolate;
                case 16: return Brushes.Gray;
                case 32: return Brushes.DarkSeaGreen;
                case 64: return Brushes.Gold;
                case 128: return Brushes.HotPink;
                case 256: return Brushes.DarkOrange;
                case 512: return Brushes.LightPink;
                case 1024: return Brushes.DarkRed;
                case 2048: return Brushes.Red;
                default: return Brushes.Gray;
            }
        }
        
        // 检查游戏是否结束 控制 gameOver 的状态
        void checkOver()
        {
            for (int i = 0; i < gSize; i++)
            {
                for (int j = 0; j < gSize - 1; j++)
                {
                    if (arr[i, j] == arr[i, j + 1]) return;
                    if (arr[j, i] == arr[j + 1, i]) return;
                }
            }
            gameOver = true;
            setText();
        }

        // 将第 index 个值为 0 的元素设置为 value 返回数组为 0 的元素个数
        int handleZero(ref int[,] array, int index = 0, int value = 0)
        {
            int s = 0;
            for (int a = 0; a < array.GetLength(0); a++)
            {
                for (int b = 0; b < array.GetLength(1); b++)
                {
                    if (array[a, b] == 0)
                    {
                        // s 先判断后加 1 (index 从0开始)
                        if (s++ == index && value != 0)
                        {
                            array[a, b] = value;
                        }
                    }
                }
            }
            return s;
        }

        // 随机在空白的位置产生一个新数
        void randomNew(int value = 2)
        {
            int s;

            // 没有一个为 0 (全部写满 退出)
            if ((s = handleZero(ref arr)) == 0)
            {
                return; // 返回
            }
            handleZero(ref arr, r.Next(s), value);        // Next() 不包含上限
        }

        void setText()
        {
            if (!gameOver)
            {
                label4.Text = "Ctrl + Z : 撤销";
            }
            else
            {
                label4.Text = "游戏结束 按回车键重新开始";
            }
        }
        // 将 arr 中的内容使用绘图函数输出
        void draw()
        {
            if (score != scoreOld)
            {
                scoreOld = score;
                label3.Text = score.ToString();
            }
            for (int a = 0; a < gSize; a++)
            {
                // 注意数组索引 a b 和 x y 的关系 (a->y b->x)
                for (int b = 0; b < gSize; b++)
                {
                    g.FillRectangle(switchBrush(arr[a, b]), b * 100, a * 100, 90, 90);
                    if (arr[a, b] != 0)
                    {
                        // 上下左右均居中
                        StringFormat strfmt = new StringFormat();
                        strfmt.Alignment = StringAlignment.Center;
                        strfmt.LineAlignment = StringAlignment.Center;

                        // 绘制每个方格的数值
                        g.DrawString(arr[a, b].ToString(), new Font("黑体", 24, FontStyle.Bold), Brushes.White, new RectangleF(b * 100, a * 100, 90, 90), strfmt);
                    }
                }
            }
            pictureBox1.Refresh();      // 刷新绘图框
        }

        // 将数组中非零元素移动到数组前端
        bool arrayZip(ref int[] array)
        {
            bool flag = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == 0)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[j] != 0)
                        {
                            array[i] = array[j];
                            array[j] = 0;
                            flag = true;    // 进行了移动
                            break;
                        }
                    }
                }
            }
            return flag;
        }

        // 从数组头部开始对相同的两个数合并 (第一个数乘二 第二个置零)
        bool arrayMerge(ref int[] array)
        {
            bool flag = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == 0)
                {
                    continue;
                }
                if (array[i] == array[i + 1])
                {
                    array[i] *= 2;
                    array[i + 1] = 0;
                    flag = true;            // 进行了合并

                    score += array[i];      // 分数是累加游新合成方块的值
                }
            }
            return flag;
        }

        void moveAction(actionType act)
        {
            bool flag = false;
            int[] array = new int[gSize];

            undoList.Push((int[,])arr.Clone());
            scoreList.Push(score);

            // 将每行列读出 分别对应四种读出方式
            for (int i = 0; i < gSize; i++)
            {
                for (int j = 0; j < gSize; j++)
                {
                    switch (act)
                    {
                        case actionType.up:
                            array[j] = arr[j, i];
                            break;
                        case actionType.down:
                            array[j] = arr[(gSize - 1) - j, i];
                            break;
                        case actionType.left:
                            array[j] = arr[i, j];
                            break;
                        case actionType.right:
                            array[j] = arr[i, (gSize - 1) - j];
                            break;
                    }
                }

                flag |= arrayZip(ref array);
                flag |= arrayMerge(ref array);
                flag |= arrayZip(ref array);

                // 将每行列写回
                for (int j = 0; j < gSize; j++)
                {
                    switch (act)
                    {
                        case actionType.up:
                            arr[j, i] = array[j];
                            break;
                        case actionType.down:
                            arr[(gSize - 1) - j, i] = array[j];
                            break;
                        case actionType.left:
                            arr[i, j] = array[j];
                            break;
                        case actionType.right:
                            arr[i, (gSize - 1) - j] = array[j];
                            break;
                    }
                }
            }

            // 根据 flag 的值判断是否进行了移动或合并操作 也可以比较栈中副本是否相同
            if (flag)
            {
                randomNew();

                // 检查是否填充满了
                if (handleZero(ref arr) == 0)
                {
                    checkOver();
                }
                draw();
            }
            else
            {
                undoList.Pop();     // 说明此步未发生移动 舍弃
                scoreList.Pop();    // 两个列表操作一定要成对
            }
        }

        void undo()
        {
            if (undoList.Count != 0)
            {
                if(gameOver)
                {
                    gameOver = false;
                    setText();
                }

                arr = undoList.Pop();
                score = scoreList.Pop();

                draw();
            }
        }

        public Form1()
        {
            InitializeComponent();

            arr = new int[gSize, gSize];

            undoList = new Stack<int[,]>();
            scoreList = new Stack<int>();

            img = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.BackgroundImage = img;
            g = Graphics.FromImage(img);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reset();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if(gameOver)
                        reset();
                    return;

                case Keys.Z:
                    if (e.Control)
                        undo();
                    break;

                case Keys.W:
                case Keys.Up:
                    if (!gameOver)
                        moveAction(actionType.up);
                    break;

                case Keys.S:
                case Keys.Down:
                    if (!gameOver)
                        moveAction(actionType.down);
                    break;

                case Keys.A:
                case Keys.Left:
                    if (!gameOver)
                        moveAction(actionType.left);
                    break;

                case Keys.D:
                case Keys.Right:
                    if (!gameOver)
                        moveAction(actionType.right);
                    break;
            }
        }
    }
}
