using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NPOI.HSSF.UserModel;//2003
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using System.IO;
using NPOI.XSSF.UserModel;//2007
namespace NPOITest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            //HSSF 是Horrible SpreadSheet Format的缩写，也即“讨厌的电子表格格式”
            //创建excel，workbook对象
            HSSFWorkbook Workbook2003 = new HSSFWorkbook();
            
            //设置文档信息            
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "mouday";
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "excel example";
            Workbook2003.DocumentSummaryInformation = dsi;
            Workbook2003.SummaryInformation = si;

            //添加Worksheet
           
            Workbook2003.CreateSheet("sheet1");
            Workbook2003.CreateSheet("sheet2");
            Workbook2003.CreateSheet("sheet3");

            //创建cell,poi中下标从零开始
            //HSSFRow row = (HSSFRow)sheet.CreateRow(0);
            //row.CreateCell(0).SetCellValue("this is a test");

            //保存
            FileStream file2003 = new FileStream(@"Excel2003.xls", FileMode.Create);
            Workbook2003.Write(file2003);
            file2003.Close();
            Workbook2003.Close();


            XSSFWorkbook workbook2007 = new XSSFWorkbook();  //新建xlsx工作簿  
            workbook2007.CreateSheet("Sheet1");
            workbook2007.CreateSheet("Sheet2");
            workbook2007.CreateSheet("Sheet3");
            FileStream file2007 = new FileStream(@"Excel2007.xlsx", FileMode.Create);
            workbook2007.Write(file2007);
            file2007.Close();
            workbook2007.Close();  
            MessageBox.Show("Excel文件创建成功");
        }
    }
}
