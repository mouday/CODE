using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Miko.CSharp.Snake
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

        // 蛇身体是个队列 绘图时整体只读取出 由 Head 的位置逐点确定坐标
        struct snake
        {
            public Point Head;
            public Queue<actionType> Body;
        }

        public struct snakeColor
        {
            public Brush Head;
            public Brush Body;
            public Brush Food;
        }

        bool gameOver;
        bool run;

        public bool godMode = false;
        public bool auxLine = true;         // 是否显示灰色的辅助线
        public bool autoPause = true;

        byte[,] arr;
        int score;
        
        public int gridSize { get; private set; }
        int multiple;

        actionType lastAction;
        actionType nextAction;        // 下一步方向 由定时器执行 可能会显得操作不灵活

        Point food;
        Bitmap img;
        Graphics g;
        Random r = new Random();         // 随机数生成器

        snake sna = new snake()
        {
            Body = new Queue<actionType>()
        };
        public snakeColor snaColor = new snakeColor()
        {
            Head = Brushes.Black,
            Body = Brushes.Gray,
            Food = Brushes.LightGreen
        };

        Brush switchBrush(int x, int y)
        {
            switch (arr[x, y])
            {
                case 1: return snaColor.Food;
                case 2: return snaColor.Body;
                case 3: return snaColor.Head;
                default:
                    if (auxLine && (x == food.X || y == food.Y)) return new SolidBrush(Color.FromArgb(248, 248, 248));
                    else return Brushes.White;
            }
        }

        // 参数为新的网格大小
        public void reset(int value = 0)
        {
            if (value != 0)
            {
                gridSize = value;
            }
            if (gridSize < 2 || gridSize > 200)
            {
                gridSize = 20;
            }
            multiple = 400 / gridSize;

            gameOver = false;
            run = false;

            score = 0;
            label3.Text = score.ToString();

            arr = new byte[gridSize, gridSize];
            for (int a = 0; a < gridSize; a++)
            {
                for (int b = 0; b < gridSize; b++)
                {
                    arr[a, b] = 0;
                }
            }
            sna.Head.X = 0;
            sna.Head.Y = 0;
            sna.Body.Clear();

            arr[0, 0] = 3;
            randomNew();
            arr[food.X, food.Y] = 1;

            lastAction = actionType.none;
            nextAction = actionType.right;

            label4.Text = "按 F1 打开设置窗口";
            label4.ForeColor = Color.Gray;

            g.Clear(Color.FromArgb(240, 240, 240));
            drawImg();
            drawUI();
        }

        void moveAction()
        {
            Point p = new Point();
            p.X = sna.Head.X;
            p.Y = sna.Head.Y;

            lastAction = nextAction;
            switch (nextAction)
            {
                case actionType.up:
                    p.Y -= 1;
                    break;
                case actionType.down:
                    p.Y += 1;
                    break;
                case actionType.left:
                    p.X -= 1;
                    break;
                case actionType.right:
                    p.X += 1;
                    break;
            }

            if (p.X >= gridSize || p.X < 0 || p.Y >= gridSize || p.Y < 0 || (arr[p.X, p.Y] != 0 && arr[p.X, p.Y] != 1))
            {
                if (!godMode)
                {
                    gameOver = true;
                    drawUI();
                }
            }
            else
            {
                bool ate = arr[p.X, p.Y] == 1;

                sna.Head.X = p.X;
                sna.Head.Y = p.Y;

                for (int a = 0; a < gridSize; a++)
                {
                    for (int b = 0; b < gridSize; b++)
                    {
                        arr[a, b] = 0;
                    }
                }

                arr[sna.Head.X, sna.Head.Y] = 3;

                sna.Body.Enqueue(nextAction);
                if (!ate)
                {
                    sna.Body.Dequeue();
                }

                var actionList = sna.Body.ToArray();
                for (int i = actionList.Length - 1; i >= 0; i--)
                {
                    switch (actionList[i])
                    {
                        case actionType.up:
                            p.Y += 1;
                            break;
                        case actionType.down:
                            p.Y -= 1;
                            break;
                        case actionType.left:
                            p.X += 1;
                            break;
                        case actionType.right:
                            p.X -= 1;
                            break;
                    }
                    arr[p.X, p.Y] = 2;
                }

                if (ate)
                {
                    score += 1;
                    label3.Text = score.ToString();
                    if (randomNew() == false)
                    {
                        gameOver = true;
                        drawUI();
                        drawImg();
                        return;
                    }
                }
                arr[food.X, food.Y] = 1;
                drawImg();
            }
        }

        // 刷新绘图边框 设置提示文本
        public void drawUI()
        {
            Func<Color> frameColor = () =>
            {
                if (gameOver)
                    return Color.Red;
                else if (!run)
                    return Color.Yellow;
                else if (godMode)
                    return Color.Purple;
                else
                    return Color.LightGreen;
            };
            if (gameOver)
            {
                label4.Text = "游戏结束 按回车键重新开始";
                label4.ForeColor = Color.Red;
            }
            g.DrawRectangle(new Pen(frameColor()), 0, 0, gridSize * multiple, gridSize * multiple);
            pictureBox1.Refresh();
        }

        // 刷新绘图核心区域
        public void drawImg()
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    g.FillRectangle(switchBrush(i, j), i * multiple + 1, j * multiple + 1, multiple - 1, multiple - 1);
                }
            }
            pictureBox1.Refresh();
        }

        // 在第 index 个值为 0 的元素设置 value 返回数组为 0 的元素个数
        int handleZero(ref byte[,] array, int index = 0, byte value = 0)
        {
            int s = 0;
            for (int a = 0; a < array.GetLength(0); a++)
            {
                for (int b = 0; b < array.GetLength(1); b++)
                {
                    if (array[a, b] == 0)
                    {
                        if (s++ == index && value != 0)                 // s 先判断后加 1 (index 从0开始)
                        {
                            food.X = a;
                            food.Y = b;
                        }
                    }
                }
            }
            return s;
        }

        // 随机在空白的位置产生一个新数
        bool randomNew()
        {
            int s;
            if ((s = handleZero(ref arr)) == 0)        // 没有一个为 0 (全部写满 退出)
            {
                return false;                     // 返回 false (失败)
            }
            handleZero(ref arr, r.Next(s), 1);        // Next() 不包含上限
            return true;
        }

        // 保存程序截图
        void saveImg()
        {
            Bitmap sav = new Bitmap(this.Width, this.Height);
            Graphics g = Graphics.FromImage(sav);
            g.CopyFromScreen(this.Location, new Point(0, 0), this.Size);
            g.Dispose();

            var sfd = new SaveFileDialog();
            sfd.Title = "保存";
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            sfd.Filter = "PNG文件|*.png";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                sav.Save(sfd.FileName);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            img = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.BackgroundImage = img;
            g = Graphics.FromImage(img);
            reset();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!gameOver && run)
            {
                moveAction();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                case Keys.Up:
                    if (lastAction != actionType.down || sna.Body.Count == 0)         // 只有当没有身体时 才允许反向移动
                        nextAction = actionType.up;
                    break;

                case Keys.S:
                case Keys.Down:
                    if (lastAction != actionType.up || sna.Body.Count == 0)
                        nextAction = actionType.down;
                    break;

                case Keys.A:
                case Keys.Left:
                    if (lastAction != actionType.right || sna.Body.Count == 0)
                        nextAction = actionType.left;
                    break;

                case Keys.D:
                case Keys.Right:
                    if (lastAction != actionType.left || sna.Body.Count == 0)
                        nextAction = actionType.right;
                    break;

                case Keys.Enter:
                    if (gameOver) reset();
                    else
                    {
                        run = !run;
                        drawUI();
                    }
                    break;

                case Keys.F1:
                    (new Form2()).ShowDialog(this);
                    break;

                case Keys.F2:
                    saveImg();
                    break;
            }
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (autoPause && run == true)
            {
                run = false;
                drawUI();
            }
        }
    }
}
