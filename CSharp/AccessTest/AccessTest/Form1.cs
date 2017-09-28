using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccessTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "Data.mdb";
            dataGridView1.DataSource = AccessHelper_PSY.GetDataTable(path, "DataTable");
            //AccessHelper access = new AccessHelper();
            //string sql = "select * from DataTable where Personal=true";

            //dataGridView1.DataSource = access.GetDataTableFromDB(sql);
        }


    }
}
