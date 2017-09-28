using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace CreateExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreateExcel_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\PSY\Desktop";
            //创建excel对象
            Excel.Application xlApp = new Excel.Application();
            //添加工作薄
            Excel.Workbook xlworkbook = xlApp.Workbooks.Add(true);
            //获取缺少的object类型值
            object missing = System.Reflection.Missing.Value;
            //添加工作表
            Excel.Worksheet xlworksheet = xlworkbook.Worksheets.Add(missing, missing, missing, missing);
            //Excel.Worksheet xlworksheet = xlworkbook.Worksheets.Add();
            //保存工作薄
            if (path.EndsWith("\\"))//判断是否以“\”结尾
            {
                //保存副本，不修改内存中的工作薄
                xlworkbook.SaveCopyAs(path + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xlsx");
            }
            else
            {
                xlworkbook.SaveCopyAs(path + "\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xlsx");
            }
            MessageBox.Show("Excel文件创建成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //关闭进程
            System.Diagnostics.Process[] excelProcess = System.Diagnostics.Process.GetProcessesByName("EXCEL");
            foreach (System.Diagnostics.Process p in excelProcess)
            {
                p.Kill();
            }
        }

        private void btnAddSheet_Click(object sender, EventArgs e)
        {
            object missing = System.Reflection.Missing.Value;
            Excel.Application xlApp = new Excel.Application();
            string path = @"C:\Users\PSY\Desktop\20170801094326.xlsx";
            Excel.Workbook xlworkbook = xlApp.Workbooks.Open(path);
            Excel.Worksheet xlworksheet = xlworkbook.Worksheets.Add(missing, missing, 1, missing);
            MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            xlApp.Application.DisplayAlerts = false;
            xlworkbook.Save();
            xlworkbook.Close();
            xlApp.Quit();
            BindSheets();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindSheets();
        }
        private void BindSheets()
        {
            cmbSheets.Items.Clear();
            string path = @"C:\Users\PSY\Desktop\20170801094326.xlsx";
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlworkbook = xlApp.Workbooks.Open(path);

            foreach (Excel.Worksheet xlworksheet in xlworkbook.Sheets)
            {
                cmbSheets.Items.Add(xlworksheet.Name);
            }
            xlworkbook.Close();
            xlApp.Quit();
            cmbSheets.SelectedIndex = 0;
        }

        private void btnDeleteSheet_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\PSY\Desktop\20170801094326.xlsx";
            Excel.Application xlApp = new Excel.Application();
            object missing = System.Reflection.Missing.Value;
            Excel.Workbook xlworkbook = xlApp.Workbooks.Open(path);
            xlworkbook.Sheets[cmbSheets.Text].Delete();
            MessageBox.Show("工作表删除成功！");
            xlApp.Application.DisplayAlerts = false;
            xlworkbook.Save();
            xlworkbook.Close();
            xlApp.Quit();
            System.Diagnostics.Process[] excelProgress = System.Diagnostics.Process.GetProcessesByName("EXCEL");
            foreach (System.Diagnostics.Process p in excelProgress)
            {
                p.Kill();
            }
            BindSheets();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindSheets();
        }

        private void btnSaveAsXls_Click(object sender, EventArgs e)
        {
            string txtPath = @"D:\Code\ExcelTest\CreateExcel\bin\Debug\关雎.txt";
            string xlsPath = @"D:\Code\ExcelTest\CreateExcel\bin\Debug\关雎.xlsx";

            StreamReader reader = new StreamReader(txtPath,Encoding.Default);
            string current = null;
            List<string> list=new List<string>();
            while ((current = reader.ReadLine()) != null)//到达输入流末尾则为null
            {
                list.Add(current);
            }
            reader.Close();

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlworkbook = xlApp.Workbooks.Open(xlsPath);
            Excel.Worksheet xlworksheet = xlworkbook.Sheets["Sheet1"];
            xlApp.Application.DisplayAlerts = false;
            for (int i = 0; i < list.Count; i++)
            {
                xlworksheet.Cells[i + 1,1] = list[i];//excel索引下标从1开始
            }
            xlworkbook.Save();
            xlworkbook.Close();
            xlApp.Quit();
            MessageBox.Show("ok");
            //System.Diagnostics.Process[] excelProgress = System.Diagnostics.Process.GetProcessesByName("EXCEL");
            //foreach (System.Diagnostics.Process p in excelProgress)
            //{
            //    p.Kill();
            //}
        }
    }
}
