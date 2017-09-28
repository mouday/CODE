using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormstest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.SelectedIndex.ToString();
            createstatuspanels();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //listBox1.Items.Clear();
            //listbox1.items.add("list1");
            //listbox1.items.add("list3");
            //listbox1.items.add("list2");
            //listbox1.selectedindex = 2;
            string[] s = new string[10];
            for (int i = 0; i < s.Length; i++)
            {
                s[i] = "item "+i;
            }
            listBox1.Items.AddRange(s);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.SelectedItem.ToString();
        }
        private void createstatuspanels()
        {
            statusStrip1.Items.Add("   ");
            statusStrip1.Items.Add("  ceshi ");

        }
    }
}
