using System;
using System.Drawing;
using System.Windows.Forms;

namespace Miko.CSharp.Snake
{
    public partial class Form2 : Form
    {
        Form1 owner;
        
        public Form2()
        {
            InitializeComponent();

            // 添加网格尺寸 网格尺寸要能被 400 整除
            for (int i = 2, t; i <= (400 / 2); i++)
            {
                if ((400 / i) * i == 400)
                {
                    comboBox2.Items.Add(i);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tick, gSize;
            int.TryParse(comboBox1.Text, out tick);
            int.TryParse(comboBox2.Text, out gSize);

            if (tick > 1000 || tick < 1)
            {
                MessageBox.Show("时间间隔应当介于 0 和 1000 之间", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var color = new Form1.snakeColor()
                {
                    Head = new SolidBrush(label7.BackColor),
                    Body = new SolidBrush(label8.BackColor),
                    Food = new SolidBrush(label9.BackColor)
                };

                owner.snaColor = color;
                owner.timer1.Interval = tick;
                owner.godMode = checkBox1.Checked;
                owner.auxLine = checkBox2.Checked;
                owner.autoPause = checkBox3.Checked;

                if (gSize == owner.gridSize)
                {
                    owner.drawImg();
                }
                else
                {
                    owner.reset(gSize);
                }
                this.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            owner = (Form1)this.Owner;
            if (owner == null)
            {
                throw new Exception("子窗口调用者不存在或无效!");
            }
            
            var color = owner.snaColor;
            label7.BackColor = ((SolidBrush)color.Head).Color;
            label8.BackColor = ((SolidBrush)color.Body).Color;
            label9.BackColor = ((SolidBrush)color.Food).Color;

            comboBox1.Text = owner.timer1.Interval.ToString();
            comboBox2.Text = owner.gridSize.ToString();

            checkBox1.Checked = owner.godMode;
            checkBox2.Checked = owner.auxLine;
            checkBox3.Checked = owner.autoPause;

            toolTip1.SetToolTip(checkBox1, "开启后碰到边界和自己会停止运动");
            toolTip1.SetToolTip(checkBox2, "将食物所在的行列用浅灰色绘出");
            toolTip1.SetToolTip(comboBox1, "间隔越小运动越快 默认值为 200 (毫秒)");
            toolTip1.SetToolTip(comboBox2, "改变此项将重置游戏");
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                label7.BackColor = colorDialog1.Color;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                label8.BackColor = colorDialog1.Color;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                label9.BackColor = colorDialog1.Color;
            }
        }
    }
}
