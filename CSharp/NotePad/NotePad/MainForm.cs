using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;

namespace NotePad
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "数据文档(*.mca)|*.mca|文本文档(*.txt)|*.txt|所有文件(*.*)|*.*";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
               richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName, Encoding.Default);
                //List<ColorRgb> colors = GetColors(openFileDialog1.FileName);
                
               // ReadMca(openFileDialog1.FileName,colors);
            }
        }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                this.richTextBox1.Font = fontDialog1.Font;
                //this.textBox1.ForeColor = fontDialog1.Color;
            }
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm fm = new AboutForm();
            fm.ShowDialog();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        struct ColorRgb
        {
            public int r;
            public int g;
            public int b;
        }
        Random random = new Random();
        private void ReadMca(string path, List<ColorRgb> colors)
        {
            StreamReader reader = new StreamReader(path, Encoding.Default);
            string current = null;
            int pos = 0;
            int length = 0;
            while ((current = reader.ReadLine()) != null)
            {

                string[] cells = current.Split(',');
                for (int i = 0; i < cells.Length; i++)
                {

                    richTextBox1.AppendText(cells[i]);
                    length = cells[i].Length;
                    richTextBox1.Select(pos, length);
                    pos = length + 1;
                    richTextBox1.SelectionColor = Color.FromArgb(colors[i].r, colors[i].g, colors[i].b);
                    if (i == cells.Length - 1)
                    {
                        //richTextBox1.AppendText();
                    }
                    else
                    {
                        richTextBox1.AppendText(",");
                        pos++;
                    }
                }
            }
        }
           
            
                
                
                   
           
        
        private List<ColorRgb> GetColors(string path)
        {
            //获取表头个数，为每个列设置颜色
            StreamReader reader = new StreamReader(path, Encoding.Default);
            string[] titles = reader.ReadLine().Split(',');
            reader.Close();

            List<ColorRgb> color = new List<ColorRgb>();
           
            for (int i = 0; i < titles.Length; i++)
            {
                ColorRgb rgb = new ColorRgb();
                rgb.r = random.Next(256);
                rgb.g = random.Next(256);
                rgb.b = random.Next(256);
                color.Add(rgb);               
            }
            return color;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //richTextBox1.AppendText("test");

            
            
            //richTextBox1.Select(0,0);
        }
    }
}
