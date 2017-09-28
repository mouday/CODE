using System;
using System.Drawing;
using System.Windows.Forms;

namespace Miko.CSharp.Tetris
{
    public partial class Form1 : Form
    {
        enum cubeType
        {
            none,
            I,
            O,
            L,
            J,
            S,
            Z,
            T
        }

        #region 使用数组定义方块的形状 值代表颜色 顺序与 cubeType 相同
        readonly byte[,,] cube =
        {
            {
                {
                    0,0,0,0,
                    0,0,0,0,
                    0,0,0,0,
                    0,0,0,0
                },
                {
                    0,0,0,0,
                    0,0,0,0,
                    0,0,0,0,
                    0,0,0,0
                },
                {
                    0,0,0,0,
                    0,0,0,0,
                    0,0,0,0,
                    0,0,0,0
                },
                {
                    0,0,0,0,
                    0,0,0,0,
                    0,0,0,0,
                    0,0,0,0
                },
            },
            {
                {
                    0,1,0,0,
                    0,1,0,0,
                    0,1,0,0,
                    0,1,0,0
                },
                {
                    0,0,0,0,
                    0,0,0,0,
                    1,1,1,1,
                    0,0,0,0
                },
                {
                    0,1,0,0,
                    0,1,0,0,
                    0,1,0,0,
                    0,1,0,0
                },
                {
                    0,0,0,0,
                    0,0,0,0,
                    1,1,1,1,
                    0,0,0,0
                }
            },
            {
                {
                    0,0,0,0,
                    0,2,2,0,
                    0,2,2,0,
                    0,0,0,0
                },
                {
                    0,0,0,0,
                    0,2,2,0,
                    0,2,2,0,
                    0,0,0,0
                },
                {
                    0,0,0,0,
                    0,2,2,0,
                    0,2,2,0,
                    0,0,0,0
                },
                {
                    0,0,0,0,
                    0,2,2,0,
                    0,2,2,0,
                    0,0,0,0
                }
            },
            {
                {
                    0,3,0,0,
                    0,3,0,0,
                    0,3,3,0,
                    0,0,0,0
                },
                {
                    0,0,3,0,
                    3,3,3,0,
                    0,0,0,0,
                    0,0,0,0
                },
                {
                    0,3,3,0,
                    0,0,3,0,
                    0,0,3,0,
                    0,0,0,0
                },
                {
                    0,0,0,0,
                    3,3,3,0,
                    3,0,0,0,
                    0,0,0,0
                }
            },
            {
                {
                    0,0,4,0,
                    0,0,4,0,
                    0,4,4,0,
                    0,0,0,0
                },
                {
                    0,0,0,0,
                    4,4,4,0,
                    0,0,4,0,
                    0,0,0,0
                },
                {
                    0,4,4,0,
                    0,4,0,0,
                    0,4,0,0,
                    0,0,0,0
                },
                {
                    4,0,0,0,
                    4,4,4,0,
                    0,0,0,0,
                    0,0,0,0
                }
            },
            {
                {
                    0,5,0,0,
                    0,5,5,0,
                    0,0,5,0,
                    0,0,0,0
                },
                {
                    0,0,0,0,
                    0,5,5,0,
                    5,5,0,0,
                    0,0,0,0
                },
                {
                    0,5,0,0,
                    0,5,5,0,
                    0,0,5,0,
                    0,0,0,0
                },
                {
                    0,0,0,0,
                    0,5,5,0,
                    5,5,0,0,
                    0,0,0,0
                }
            },
            {
                {
                    0,0,6,0,
                    0,6,6,0,
                    0,6,0,0,
                    0,0,0,0
                },
                {
                    0,0,0,0,
                    6,6,0,0,
                    0,6,6,0,
                    0,0,0,0
                },
                {
                    0,0,6,0,
                    0,6,6,0,
                    0,6,0,0,
                    0,0,0,0
                },
                {
                    0,0,0,0,
                    6,6,0,0,
                    0,6,6,0,
                    0,0,0,0
                }
            },
            {
                {
                    0,7,0,0,
                    7,7,7,0,
                    0,0,0,0,
                    0,0,0,0
                },
                {
                    0,0,7,0,
                    0,7,7,0,
                    0,0,7,0,
                    0,0,0,0
                },
                {
                    0,0,0,0,
                    7,7,7,0,
                    0,7,0,0,
                    0,0,0,0
                },
                {
                    0,7,0,0,
                    0,7,7,0,
                    0,7,0,0,
                    0,0,0,0
                }
            }
        };
        #endregion

        struct tetris
        {
            public cubeType Type;
            public int X;
            public int Y;
            public int Status;
        }

        public struct cubeColor
        {
            public Brush I;
            public Brush J;
            public Brush L;
            public Brush O;
            public Brush S;
            public Brush T;
            public Brush Z;
        }

        const int xSize = 10;
        const int ySize = 20;
        const int buffer = -4;      // 下落起点 Y 坐标
        const int multiple = 25;
        
        byte[,] arr;
        bool gameOver;
        bool run;       // 或者用 timer1.Enabled
        bool activated;         // 窗体是否为活动窗体

        public bool Preview = true;
        public bool CheatMode = false;
        public bool autoPause = true;

        int score;
        int Score
        {
            get
            {
                return score;
            }
            set
            {
                if (score != value)
                {
                    score = value;
                    label3.Text = score.ToString();
                }
            }
        }

        Bitmap img;
        Bitmap prev;
        Bitmap close;
        Bitmap back;

        Graphics g;
        Graphics gra;
        Graphics grab;
        Graphics grac;

        tetris now = new tetris();
        tetris next = new tetris();
        Random r = new Random();

        public cubeColor nowColor = new cubeColor()     // 默认的方块颜色
        {
            I = Brushes.LightSalmon,
            O = Brushes.Peru,
            L = Brushes.LightBlue,
            J = Brushes.DarkOrange,
            S = Brushes.DarkSeaGreen,
            Z = Brushes.Gold,
            T = Brushes.HotPink
        };

        Brush switchBrush(cubeType c)
        {
            switch (c)
            {
                case cubeType.I:
                    return nowColor.I;
                case cubeType.J:
                    return nowColor.J;
                case cubeType.L:
                    return nowColor.L;
                case cubeType.O:
                    return nowColor.O;
                case cubeType.S:
                    return nowColor.S;
                case cubeType.T:
                    return nowColor.T;
                case cubeType.Z:
                    return nowColor.Z;
                default:
                    return Brushes.White;
            }
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
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            sfd.Filter = "PNG 文件|*.png";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                sav.Save(sfd.FileName);
            }
        }

        // 获取方块的下落位置
        int getPreview()
        {
            for (int i = now.Y + 1; i < ySize; i++)
            {
                if (handlePosition(now.Type, now.X, i, now.Status) != 0)
                {
                    return i - 1;
                }
            }
            return now.Y;
        }

        // 判断方块是否能继续向下移动
        void moveDown()
        {
            if (handlePosition(now.Type, now.X, now.Y + 1, now.Status) == 0)
            {
                now.Y += 1;
                draw();
            }
            else
            {
                downSet(false);
            }
        }

        // 默认使用 getPreview() 获取下落终点 若参数为 false 则认为 now.Y 下落终点
        void downSet(bool preview = true)
        {
            int tempY = (preview) ? getPreview() : now.Y;
            handlePosition(now.Type, now.X, tempY, now.Status, true);
            Score += 2;
            checkRemove();
            randomNew();

            // 最上层有元素时游戏结束
            if (checkExist(0))
            {
                gameOver = true;
            }

            draw();
        }
        
        // 判断第 y 行是否存在元素
        bool checkExist(int y)
        {
            for (int i = 0; i < xSize; i++)
            {
                if (arr[i, y] != 0)
                {
                    return true;
                }
            }
            return false;
        }

        // 使方块水平移动 参数为真向左移 反之向右
        void moveH(bool left)
        {
            if (handlePosition(now.Type, now.X + (left ? -1 : 1), now.Y, now.Status) == 0)
            {
                now.X += (left ? -1 : 1);
            }
            draw();
        }

        // 方块旋转
        void rotate()
        {
            int sta = now.Status + 1;
            if (sta >= 4) sta = 0;

            int t = handlePosition(now.Type, now.X, now.Y, sta);

            if (t == 0)
            {
                now.Status = sta;
                draw();
                return;
            }
            else
            {
                for (int i = 1; i < 4; i++)         // 旋转失败 向左右移位并重新检查
                {
                    if (handlePosition(now.Type, now.X + i, now.Y, sta) == 0)
                    {
                        now.Status = sta;
                        now.X += i;
                        draw();
                        return;
                    }
                    else if (handlePosition(now.Type, now.X - i, now.Y, sta) == 0)
                    {
                        now.Status = sta;
                        now.X -= i;
                        draw();
                        return;
                    }
                }
            }
        }

        // 移除所有可以消除的行
        void checkRemove()
        {
            for (int i = ySize - 1; i >= 0; i--)
            {
                if(checkLine(i))
                {
                    removeLine(i);
                    Score += 10;
                    i++;  // 由于该行被上一行覆盖消除 所以重新检查
                }
            }
        }

        // 检查参数指向的行是否可消除
        bool checkLine(int y)
        {
            for (int i = 0; i < xSize; i++)
            {
                if (arr[i, y] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        // 移除参数指向的行 参数为真用上面的行覆盖 反之用下面的行覆盖 (可利用上移在尾行产生障碍物 此功能待添加)
        void removeLine(int y, bool up = true)
        {
            for (int i = 0; i < xSize; i++)
            {
                if (up == true)
                {
                    for (int j = y - 1; j >= 0; j--)
                    {
                        arr[i, j + 1] = arr[i, j];
                        arr[i, j] = 0;
                    }
                }
                else
                {
                    for (int j = y + 1; j < ySize; j++)
                    {
                        arr[i, j - 1] = arr[i, j];
                        arr[i, j] = 0;
                    }
                }
            }
        }

        // 方块位置处理主函数
        int handlePosition(cubeType type, int x, int y, int status, bool update = false)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (cube[(int)type, status, j * 4 + i] != 0)
                    {
                        if (i + x < 0)      // 出左界
                        {
                            return 1;
                        }
                        else if (i + x >= xSize)    // 出右界
                        {
                            return 2;
                        }
                        else if (j + y >= ySize)    // 出低界
                        {
                            return 3;
                        }
                        else if (j + y < buffer)    // 超出缓冲区
                        {
                            return 4;
                        }
                        else if (j + y < 0)         // 在缓冲区中
                        {
                            continue;
                        }
                        else if (arr[i + x, j + y] != 0)        // 与现有方块冲突
                        {
                            return 5;
                        }
                        else if (update)        // 固定该方块
                        {
                            arr[i + x, j + y] = cube[(int)type, status, j * 4 + i];
                        }
                    }
                }
            }
            return 0;
        }

        // 绘图并刷新界面
        public void draw()
        {

            const int interval = 10;

            Brush btn;

            if (activated)
            {
                btn = Brushes.Red;
            }
            else
            {
                btn = Brushes.Gray;
            }

            Pen penNow;
            Pen penNext;

            Pen p;

            if (gameOver)
            {
                label1.Text = "游戏结束 按 Enter 重新开始";
                p = new Pen(Color.Red);
                penNow = p;
                penNext = p;
            }
            else if (!run)
            {
                label1.Text = "按 Enter 暂停继续游戏";
                p = new Pen(Color.Gray);
                penNow = p;
                penNext = p;
            }
            else
            {
                label1.Text = "按 F1 打开设置窗口";
                if (CheatMode)
                {
                    p = new Pen(Color.Purple);
                    penNow = p;
                    penNext = p;
                }
                else
                {
                    // 窗体边框使用随机颜色
                    p = new Pen(Color.FromArgb(r.Next()));

                    // 两个图片框的边框的颜色为各自方块颜色
                    penNow = new Pen(((SolidBrush)switchBrush(now.Type)).Color);
                    penNext = new Pen(((SolidBrush)switchBrush(next.Type)).Color);
                }
            }

            // 窗体边框
            grab.DrawRectangle(p, 0, 0, this.Width - 1, this.Height - 1);

            // 关闭按钮 (可以用两张位图直接替换)
            grac.FillRectangle(btn, 0, 0, closeButton.Width, closeButton.Height);
            grac.DrawLine(new Pen(Color.White), interval, interval, closeButton.Width - (interval + 1), closeButton.Height - (interval + 1));
            grac.DrawLine(new Pen(Color.White), closeButton.Width - (interval + 1), interval, interval, closeButton.Height - (interval + 1));

            // 两个图片框的边框
            g.DrawRectangle(penNow, 0, 0, xSize * multiple, ySize * multiple);
            gra.DrawRectangle(penNext, 0, 0, 4 * multiple, 4 * multiple);

            
            // 绘制下一个方块
            int t;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    t = cube[(int)next.Type, next.Status, j * 4 + i];
                    gra.FillRectangle(switchBrush((cubeType)t), i * multiple + 1, j * multiple + 1, multiple - 1, multiple - 1);
                }
            }

            // 绘制当已固定的方块
            for (int i = 0; i < xSize; i++)
            {
                for (int j = 0; j < ySize; j++)
                {
                    t = arr[i, j];
                    g.FillRectangle(switchBrush((cubeType)t), i * multiple + 1, j * multiple + 1, multiple - 1, multiple - 1);
                }
            }

            // 绘制当前方块 选择性绘制下落位置预览
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    t = cube[(int)now.Type, now.Status, j * 4 + i];
                    if (t != 0)
                    {
                        if (Preview) g.DrawRectangle(new Pen(switchBrush((cubeType)t)), (i + now.X) * multiple + 1, (j + getPreview()) * multiple + 1, multiple - 2, multiple - 2);
                        g.FillRectangle(switchBrush((cubeType)t), (i + now.X) * multiple + 1, (j + now.Y) * multiple + 1, multiple - 1, multiple - 1);
                    }
                }
            }

            this.Refresh();
        }

        // 随机生成一个新的方块
        void randomNew()
        {
            now.X = xSize / 2 - 2;
            now.Y = buffer;
            now.Type = next.Type;
            now.Status = next.Status;

            next.Type = (cubeType)r.Next(1, 8);
            next.Status = (byte)r.Next(4);
        }

        // 重置程序
        void reset()
        {
            gameOver = false;
            run = false;
            Score = 0;

            arr = new byte[xSize, ySize];
            for (int i = 0; i < xSize; i++)
            {
                for (int j = 0; j < ySize; j++)
                {
                    arr[i, j] = 0;
                }
            }

            g.Clear(Color.FromArgb(239, 239, 239));
            gra.Clear(Color.FromArgb(239, 239, 239));

            next.Type = (cubeType)r.Next(1, 8);
            next.Status = (byte)r.Next(4);
            randomNew();

            draw();
        }

        public Form1()
        {
            InitializeComponent();

            img = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            prev = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            close = new Bitmap(closeButton.Width, closeButton.Height);
            back = new Bitmap(this.Width, this.Height);

            pictureBox1.BackgroundImage = img;
            pictureBox2.BackgroundImage = prev;
            closeButton.BackgroundImage = close;
            this.BackgroundImage = back;

            g = Graphics.FromImage(img);
            gra = Graphics.FromImage(prev);
            grac = Graphics.FromImage(close);
            grab = Graphics.FromImage(back);
        }

        // 实现无边框窗体的移动
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x4e:
                case 0xd:
                case 0xe:
                case 0x14:
                    base.WndProc(ref m);
                    break;

                //鼠标点任意位置后可以拖动窗体
                case 0x84:
                    this.DefWndProc(ref m);
                    if (m.Result.ToInt32() == 0x01)
                    {
                        m.Result = new IntPtr(0x02);
                    }
                    break;

                //禁止双击最大化
                case 0xA3:
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!gameOver && run)
            {
                moveDown();
            }
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
                    if (gameOver)
                    {
                        reset();
                    }
                    else
                    {
                        run = !run;
                        
                        draw();
                    }
                    break;

                case Keys.F1:
                    (new Form2()).ShowDialog(this);
                    break;

                case Keys.F2:
                    saveImg();
                    break;

                case Keys.Delete:
                    if (CheatMode)
                    {
                        if(gameOver)
                        {
                            gameOver = false;
                            run = false;
                        }
                        removeLine(ySize - 1);
                        draw();
                    }
                    break;

                case Keys.A:
                case Keys.Left:
                    if (!gameOver && run)
                        moveH(true);
                    break;

                case Keys.D:
                case Keys.Right:
                    if (!gameOver && run)
                        moveH(false);
                    break;

                case Keys.W:
                case Keys.Up:
                    if (!gameOver && run)
                        rotate();
                    break;

                case Keys.S:
                case Keys.Down:
                    if (!gameOver && run)
                        downSet();
                    break;
            }
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (autoPause && run == true)
            {
                run = false;
            }

            activated = false;
            draw();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            activated = true;
            draw();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
