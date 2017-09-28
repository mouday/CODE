using System;
using System.Drawing;
using System.Windows.Forms;

namespace Miko.CSharp.Tetris
{
    public partial class Form2 : Form
    {
        bool activated;

        Bitmap close;
        Bitmap back;

        Graphics grab;
        Graphics grac;

        Form1 owner;
        Form1.cubeColor newColor;

        void draw()     // 可以与 Form1 合并写一个单独的类 因为只有两个窗口 所以直接复制了
        {
            const int interval = 10;

            Brush btn;

            Pen p;

            if (activated)
            {
                btn = Brushes.Red;
                p = new Pen(Color.Red);
            }
            else
            {
                btn = Brushes.Gray;
                p = new Pen(Color.Gray);
            }

            grab.DrawRectangle(p, 0, 0, this.Width - 1, this.Height - 1);

            grac.FillRectangle(btn, 0, 0, closeButton.Width, closeButton.Height);
            grac.DrawLine(new Pen(Color.White, 1), interval, interval, closeButton.Width - (interval + 1), closeButton.Height - (interval + 1));
            grac.DrawLine(new Pen(Color.White, 1), closeButton.Width - (interval + 1), interval, interval, closeButton.Height - (interval + 1));

            this.Refresh();
        }

        protected override void WndProc(ref Message m)      // 同 Form1
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

        public Form2()
        {
            InitializeComponent();

            
            close = new Bitmap(closeButton.Width, closeButton.Height);
            back = new Bitmap(this.Width, this.Height);

            closeButton.BackgroundImage = close;
            this.BackgroundImage = back;

            grac = Graphics.FromImage(close);
            grab = Graphics.FromImage(back);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if ((owner = (Form1)this.Owner) == null)
            {
                throw new Exception("子窗口调用者不存在或无效 !");
            }

            newColor = owner.nowColor;

            checkBox1.Checked = owner.Preview;
            checkBox2.Checked = owner.CheatMode;
            checkBox3.Checked = owner.autoPause;

            comboBox1.Text = owner.timer1.Interval.ToString();
            comboBox2.Text = "I";

            toolTip1.SetToolTip(checkBox2, "开启后按下 Delete 消除底部一行");
            toolTip1.SetToolTip(comboBox1, "设置方块下落间隔 时间越短速度越快 单位为毫秒");
            toolTip1.SetToolTip(comboBox2, "请选择一个方块名 然后点击右边的颜色标签设置颜色");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tick;
            int.TryParse(comboBox1.Text, out tick);

            if (tick > 1000 || tick < 1)
            {
                MessageBox.Show("时间间隔应当介于 0 和 1000 之间", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                owner.Preview = checkBox1.Checked;
                owner.CheatMode = checkBox2.Checked;
                owner.autoPause = checkBox3.Checked;
                owner.timer1.Interval = tick;
                owner.nowColor = newColor;
            }

            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                label5.BackColor = colorDialog1.Color;
                Brush tempBrush= new SolidBrush(label5.BackColor);

                switch (comboBox2.Text)
                {
                    case "I":
                        newColor.I = tempBrush;
                        break;
                    case "J":
                        newColor.J = tempBrush;
                        break;
                    case "L":
                        newColor.L = tempBrush;
                        break;
                    case "O":
                        newColor.O = tempBrush;
                        break;
                    case "S":
                        newColor.S = tempBrush;
                        break;
                    case "T":
                        newColor.T = tempBrush;
                        break;
                    case "Z":
                        newColor.Z = tempBrush;
                        break;
                    default:
                        return;
                }
            }
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            Brush tempBrush;
            switch (comboBox2.Text)
            {
                case "I":
                    tempBrush = newColor.I;
                    break;
                case "J":
                    tempBrush = newColor.J;
                    break;
                case "L":
                    tempBrush = newColor.L;
                    break;
                case "O":
                    tempBrush = newColor.O;
                    break;
                case "S":
                    tempBrush = newColor.S;
                    break;
                case "T":
                    tempBrush = newColor.T;
                    break;
                case "Z":
                    tempBrush = newColor.Z;
                    break;
                default:
                    return;
            }
            label5.BackColor = ((SolidBrush)tempBrush).Color;
            colorDialog1.Color = label5.BackColor;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            activated = true;
            draw();
        }

        private void Form2_Deactivate(object sender, EventArgs e)
        {
            activated = false;
            draw();
        }


    }
}
