using System;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Miko.WPF.Tetris
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum cubeType
        {
            None,
            I,
            J,
            L,
            O,
            S,
            T,
            Z,
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
                    0,0,2,0,
                    0,0,2,0,
                    0,2,2,0,
                    0,0,0,0
                },
                {
                    0,0,0,0,
                    2,2,2,0,
                    0,0,2,0,
                    0,0,0,0
                },
                {
                    0,2,2,0,
                    0,2,0,0,
                    0,2,0,0,
                    0,0,0,0
                },
                {
                    2,0,0,0,
                    2,2,2,0,
                    0,0,0,0,
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
                    0,0,0,0,
                    0,4,4,0,
                    0,4,4,0,
                    0,0,0,0
                },
                {
                    0,0,0,0,
                    0,4,4,0,
                    0,4,4,0,
                    0,0,0,0
                },
                {
                    0,0,0,0,
                    0,4,4,0,
                    0,4,4,0,
                    0,0,0,0
                },
                {
                    0,0,0,0,
                    0,4,4,0,
                    0,4,4,0,
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
                    0,6,0,0,
                    6,6,6,0,
                    0,0,0,0,
                    0,0,0,0
                },
                {
                    0,0,6,0,
                    0,6,6,0,
                    0,0,6,0,
                    0,0,0,0
                },
                {
                    0,0,0,0,
                    6,6,6,0,
                    0,6,0,0,
                    0,0,0,0
                },
                {
                    0,6,0,0,
                    0,6,6,0,
                    0,6,0,0,
                    0,0,0,0
                }
            },
            {
                {
                    0,0,7,0,
                    0,7,7,0,
                    0,7,0,0,
                    0,0,0,0
                },
                {
                    0,0,0,0,
                    7,7,0,0,
                    0,7,7,0,
                    0,0,0,0
                },
                {
                    0,0,7,0,
                    0,7,7,0,
                    0,7,0,0,
                    0,0,0,0
                },
                {
                    0,0,0,0,
                    7,7,0,0,
                    0,7,7,0,
                    0,0,0,0
                }
            },
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

        // 默认的方块颜色
        public cubeColor nowColor = new cubeColor()
        {
            I = Brushes.LightSalmon,
            O = Brushes.Peru,
            L = Brushes.LightBlue,
            J = Brushes.DarkOrange,
            S = Brushes.DarkSeaGreen,
            Z = Brushes.Gold,
            T = Brushes.HotPink
        };

        const int xSize = 10;
        const int ySize = 20;
        const int buffer = -4;      // 下落起点 Y 坐标
        const int multiple = 25;

        byte[,] arr;
        bool gameOver;
        bool run;
        bool activated;         // 窗体是否为活动窗体

        public bool Preview = true;
        public bool CheatMode = false;
        public bool autoPause = true;

        int lineSum;
        int fixedSum;
        int score;

        tetris now = new tetris();
        tetris next = new tetris();
        Random r = new Random();

        public DispatcherTimer timer;

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
                    return null;
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
            fixedSum += 1;
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
                if (checkLine(i))
                {
                    removeLine(i);
                    lineSum += 1;
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
                        else if (j + y >= ySize)    // 出底界
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

            lineSum = 0;
            fixedSum = 0;
            score = -1;

            arr = new byte[xSize, ySize];
            for (int i = 0; i < xSize; i++)
            {
                for (int j = 0; j < ySize; j++)
                {
                    arr[i, j] = 0;
                }
            }

            next.Type = (cubeType)r.Next(1, 8);
            next.Status = (byte)r.Next(4);
            randomNew();

            draw();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!gameOver && run)
            {
                moveDown();
            }

            //GC.Collect();
        }
        
        // 界面刷新主要函数
        public void draw()
        {
            int t = 0;
            int p = 0;

            if (gameOver)
            {
                label.Content = "游戏结束 按 Enter 重新开始";
            }
            else if (!run)
            {
                label.Content = "F1 : 设置 Enter : 开始 ESC : 退出";
            }
            else if ((t = fixedSum * 2 + lineSum * 10) != score)
            {
                score = t;
                label.Content = string.Format("方块 {0} 行数 {1} 分数 {2}", fixedSum, lineSum, score);
            }

            // 主要区域位置偏移
            const int offX = 0;
            const int offY = 0;

            // 次要区域位置偏移
            const int offsetX = 270;
            const int offsetY = 0;

            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();



            // 两个边框
            drawingContext.DrawRectangle(null, new Pen(switchBrush(now.Type), 1), new Rect(offX + 1, offY + 1, xSize * multiple + 1, ySize * multiple + 1));
            drawingContext.DrawRectangle(null, new Pen(switchBrush(next.Type), 1), new Rect(offsetX + 1, offsetY + 1, 4 * multiple + 1, 4 * multiple + 1));

            // 绘制已固定的方块
            for (int i = 0; i < xSize; i++)
            {
                for (int j = 0; j < ySize; j++)
                {
                    if ((t = arr[i, j]) == 0) continue;
                    drawingContext.DrawRectangle(switchBrush((cubeType)t), new Pen(Brushes.White, 1), new Rect(i * multiple + offX + 2, j * multiple + offY + 2, multiple - 1, multiple - 1));
                }
            }

            // 绘制正在下落的方块和预览
            if (Preview)
            {
                p = getPreview();
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    t = cube[(int)now.Type, now.Status, j * 4 + i];
                    if (t != 0)
                    {
                        if (Preview && j + p >= 0)
                        {
                            drawingContext.DrawRectangle(null, new Pen(Brushes.White, 1), new Rect((i + now.X) * multiple + offX + 2, (j + p) * multiple + offY + 2, multiple - 2, multiple - 2));
                        }
                        if (j + now.Y >= 0)
                        {
                            drawingContext.DrawRectangle(switchBrush((cubeType)t), null, new Rect((i + now.X) * multiple + offX + 2, (j + now.Y) * multiple + offY + 2, multiple - 1, multiple - 1));
                        }
                    }
                }
            }

            // 绘制下一个方块
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    t = cube[(int)next.Type, next.Status, j * 4 + i];
                    if (t != 0)
                    {
                        drawingContext.DrawRectangle(null, new Pen(switchBrush((cubeType)t), 1), new Rect((i + next.X) * multiple + offsetX + 2, (j + next.Y) * multiple + offsetY + 2, multiple - 1, multiple - 1));
                    }
                }
            }

            drawingContext.Close();
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)image.Width, (int)image.Height, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(drawingVisual);
            image.Source = bmp;
        }

        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(400);
            timer.Tick += new EventHandler(timer_Tick);

            arr = new byte[xSize, ySize];
        }

        private void Default_Loaded(object sender, RoutedEventArgs e)
        {
            reset();
            timer.Start();
        }



        private void Default_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.DragMove();
        }

        private void Default_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    this.Close();
                    break;

                case Key.F1:
                    {
                        Setting set = new Setting();
                        set.Owner = this;
                        set.ShowDialog();
                        break;
                    }
                case Key.Enter:
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

                case Key.Delete:
                    if (CheatMode)
                    {
                        if (gameOver)
                        {
                            gameOver = false;
                            run = false;
                        }
                        removeLine(ySize - 1);
                        draw();
                    }
                    break;

                case Key.A:
                case Key.Left:
                    if (!gameOver && run)
                        moveH(true);
                    break;

                case Key.D:
                case Key.Right:
                    if (!gameOver && run)
                        moveH(false);
                    break;

                case Key.W:
                case Key.Up:
                    if (!gameOver && run)
                        rotate();
                    break;

                case Key.S:
                case Key.Down:
                    if (!gameOver && run)
                        downSet();
                    break;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            activated = true;
            draw();
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            if (autoPause && run == true)
            {
                run = false;
            }

            activated = false;
            draw();
        }
    }
}
