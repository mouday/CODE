using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace MyExcelTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path0 = @"D:\Code\ExcelTest\MyExcelTest\0.xlsx";
            string path1 = @"D:\Code\ExcelTest\MyExcelTest\1.xlsx";
            string path2 = @"D:\Code\ExcelTest\MyExcelTest\2.xlsx";
            string path3 = @"D:\Code\ExcelTest\MyExcelTest\3.xlsx";

            string[] paths = { path1,path2,path3};
            Excel.Application xlapp = new Excel.Application();
            Excel.Workbook xlbook = xlapp.Workbooks.Open(path0);
            Excel.Worksheet xlsheet=xlbook.Worksheets[1];
            int current = 1;

            foreach (string path in paths)
            {
                Excel.Application xlappt = new Excel.Application();
                Excel.Workbook xlbookt = xlappt.Workbooks.Open(path);
                Excel.Worksheet xlsheett=xlbookt.Worksheets[1];
                
                Excel.Range ranget = xlsheett.UsedRange;
                int colnum = ranget.Columns.Count;
                int rownum = ranget.Rows.Count;
                char colchar=(char)(colnum+64);
                
               //ranget.Copy(xlsheet.Range["A"+current.ToString(),colchar.ToString()+rownum.ToString()]);
               //xlsheet.Range["A" + current.ToString(), colchar + rownum.ToString()] = ranget;
                for (int i = 1; i <= rownum; i++)
                {
                    for (int j = 1; j < colnum; j++)
                    {
                        xlsheet.Cells[current, j] = xlsheett.Cells[i, j];
                    }
                    current++;
                }
                current += rownum;
                xlbookt.Close();
                xlappt.Quit();
            }
            xlapp.Application.DisplayAlerts = false;
            xlbook.Save();
            xlbook.Close();
            xlapp.Quit();
            System.Diagnostics.Process[] excelProgress = System.Diagnostics.Process.GetProcessesByName("EXCEL");
            foreach (System.Diagnostics.Process p in excelProgress)
            {
                p.Kill();
            }
            MessageBox.Show("ok");
        }
    }
}
