using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.IO; 

namespace NPOIConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            HSSFWorkbook newbook = new HSSFWorkbook();
           

            FileStream fs = File.Open("1010_20170717_01_PRT_BH.xls", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            HSSFWorkbook workbook = new HSSFWorkbook(fs);
            fs.Close();

            ISheet sheet = workbook.GetSheetAt(0);
            ISheet newSheet = newbook.CreateSheet("sheet1");
            Console.WriteLine(sheet.LastRowNum);
            Console.WriteLine(sheet.FirstRowNum);
            Console.WriteLine(sheet.GetRow(0).LastCellNum);
            Console.WriteLine(sheet.GetRow(0).FirstCellNum);
            for (int i = 0; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                IRow newRow = newSheet.CreateRow(i);
                if (row != null)
                {
                    for (int j = 0; j <=row.LastCellNum; j++)
                    {
                        ICell cell = row.GetCell(j);
                        ICell newCell = newRow.CreateCell(j);
                        if (cell != null)
                        {
                            string cellvalue = cell.ToString();
                            newCell.SetCellValue(cellvalue);
                            Console.Write(cellvalue + "\t");
                        }
                    }
                }
                Console.WriteLine();
            }
            
            FileStream newfs = new FileStream("newExcel.xls",FileMode.Create);
            newbook.Write(newfs);
            newfs.Close();
            
            workbook.Close();           
            newbook.Close();

            Console.WriteLine("ok");
            Console.ReadKey();
        }

        private static void ReadSetvalue()
        {
            string path = @"excel.xls";
            HSSFWorkbook workbook = null;
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                workbook = new HSSFWorkbook(fs);
                fs.Close();
            }
            ICellStyle cellStyle = workbook.CreateCellStyle();
            //设置单元格上下左右边框线  
            cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            //文字水平和垂直对齐方式  
            cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            cellStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            //是否换行  
            //cellStyle.WrapText = true;  
            //缩小字体填充  
            cellStyle.ShrinkToFit = true;
            ICellStyle newCellStyle = workbook.CreateCellStyle();
            newCellStyle.CloneStyleFrom(cellStyle);
            newCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;  
            ISheet sheet = workbook.GetSheetAt(0);
            IRow row = sheet.CreateRow(1);
            ICell cell = row.CreateCell(0);

            cell.CellStyle = cellStyle;
            cell.SetCellValue("test");
            sheet.GetRow(0).GetCell(0).CellStyle = newCellStyle;
            using (FileStream fs = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                workbook.Write(fs);
                fs.Close();
            }
            Console.WriteLine("ok");
        }
        private static void CreateSetvalue()
        {
            //容器-值  container-value
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("sheet1");
            IRow row = sheet.CreateRow(0);
            ICell cell = row.CreateCell(0);
            cell.SetCellValue("1234");
            //打开一个xls文件，如果没有则自行创建，如果存在myxls.xls文件则在创建时不要打开该文件  
            using (FileStream fs = File.OpenWrite("excel.xls"))
            {
                workbook.Write(fs);//向打开的这个xls文件中写入并保存。  
            }
            //FileStream file = new FileStream("excel03.xls",FileMode.Create);
            //workbook.Write(file);
            //file.Close();
            workbook.Close();
            Console.WriteLine("创建赋值成功");
        }
        //以下程序新建一个Excel 2003 xls和一个2007 xlsx文件
        private static  void CreateExcel()
        {
            HSSFWorkbook workbook2003 = new HSSFWorkbook(); //新建xls工作簿  
            workbook2003.CreateSheet("Sheet1");  //新建3个Sheet工作表  
            workbook2003.CreateSheet("Sheet2");
            workbook2003.CreateSheet("Sheet3");
            FileStream file2003 = new FileStream(@"Excel2003.xls", FileMode.Create);
            workbook2003.Write(file2003);
            file2003.Close();  //关闭文件流  
            workbook2003.Close();

            XSSFWorkbook workbook2007 = new XSSFWorkbook();  //新建xlsx工作簿  
            workbook2007.CreateSheet("Sheet1");
            workbook2007.CreateSheet("Sheet2");
            workbook2007.CreateSheet("Sheet3");
            FileStream file2007 = new FileStream(@"Excel2007.xlsx", FileMode.Create);
            workbook2007.Write(file2007);
            file2007.Close();
            workbook2007.Close();

            Console.WriteLine("创建成功！");
        }

        //顺序：读取（或新建一个工作簿）->获取工作表->对工作表添加行->对每一行添加单元格->对单元格赋值；
        private static  void WriteToExcel()
        {
            HSSFWorkbook workbook2003 = new HSSFWorkbook(); //新建工作簿  
            workbook2003.CreateSheet("Sheet1");  //新建1个Sheet工作表              
            HSSFSheet SheetOne = (HSSFSheet)workbook2003.GetSheet("Sheet1"); //获取名称为Sheet1的工作表  
            //对工作表先添加行，下标从0开始  
            for (int i = 0; i < 10; i++)
            {
                SheetOne.CreateRow(i);   //创建10行  
            }
            //对每一行创建10个单元格  
            HSSFRow SheetRow = (HSSFRow)SheetOne.GetRow(0);  //获取Sheet1工作表的首行  
            HSSFCell[] SheetCell = new HSSFCell[10];
            for (int i = 0; i < 10; i++)
            {
                SheetCell[i] = (HSSFCell)SheetRow.CreateCell(i);  //为第一行创建10个单元格  
            }
            //创建之后就可以赋值了  
            SheetCell[0].SetCellValue(true); //赋值为bool型           
            SheetCell[1].SetCellValue(0.000001); //赋值为浮点型  
            SheetCell[2].SetCellValue("Excel2003"); //赋值为字符串  
            SheetCell[3].SetCellValue("123456789987654321");//赋值为长字符串  
            for (int i = 4; i < 10; i++)
            {
                SheetCell[i].SetCellValue(i);    //循环赋值为整形  
            }
            FileStream file2003 = new FileStream(@"Excel2003.xls", FileMode.Create);
            workbook2003.Write(file2003);
            file2003.Close();
            workbook2003.Close();

            Console.WriteLine("写入成功！");
        }

        private static void ReadExcel()
        {
            IWorkbook workbook = null;  //新建IWorkbook对象  
            string fileName = "Excel2003.xls";
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            if (fileName.IndexOf(".xlsx") > 0) // 2007版本  
            {
                workbook = new XSSFWorkbook(fileStream);  //xlsx数据读入workbook  
            }
            else if (fileName.IndexOf(".xls") > 0) // 2003版本  
            {
                workbook = new HSSFWorkbook(fileStream);  //xls数据读入workbook  
            }
            ISheet sheet = workbook.GetSheetAt(0);  //获取第一个工作表  
            IRow row;// = sheet.GetRow(0);            //新建当前工作表行数据  
            for (int i = 0; i < sheet.LastRowNum; i++)  //对工作表每一行  
            {
                row = sheet.GetRow(i);   //row读入第i行数据  
                if (row != null)
                {
                    for (int j = 0; j < row.LastCellNum; j++)  //对工作表每一列  
                    {
                        string cellValue = row.GetCell(j).ToString(); //获取i行j列数据  
                        Console.WriteLine(cellValue);
                    }
                }
            }            
            fileStream.Close();
            workbook.Close();
            
            Console.WriteLine("读取成功！");
        }
    }
}
