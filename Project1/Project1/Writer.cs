using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Project1
{
    class Writer
    {
        private int type;
        private int it1 = 2;
        private int it2 = 2;
        private Excel.Workbooks excelappworkbooks;
        private Excel.Workbook excelappworkbook;
        Excel.Application ex = new Microsoft.Office.Interop.Excel.Application();
        Excel.Workbook workBook;
        Excel.Worksheet workSheet;
        Excel.Worksheet workSheet2;
        public Writer()
        {
            workBook = ex.Workbooks.Add();
            workBook.Worksheets.Add();
            workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);
            workSheet.StandardWidth = 30;
            workSheet.Name = "Отчёт";
            //type = _type;
        }
        public void ReadyToC()
        {
            workSheet.Cells[1, 1] = "ID";
            workSheet.Columns[1].ColumnWidth = 4;
            workSheet.Cells[1, 2] = "Состояние";
            workSheet.Cells[1, 3] = "Припасон к отделу";
            workSheet.Cells[1, 4] = "Ответственный";
        }
        public void ReadyToD()
        {
            workSheet.Cells[1, 1] = "ID";
            workSheet.Columns[1].ColumnWidth = 4;
            workSheet.Cells[1, 2] = "ID Компьютера";
            workSheet.Columns[2].ColumnWidth = 10;
            workSheet.Cells[1, 3] = "Название";
            workSheet.Cells[1, 4] = "Тип";
            workSheet.Cells[1, 5] = "Производитель";
            workSheet.Cells[1, 6] = "Состояние";
        }
        public void ReadyToAC()
        {
            workSheet.Cells[1, 1] = "ID";
            workSheet.Columns[1].ColumnWidth = 4;
            workSheet.Cells[1, 2] = "Состояние";
            workSheet.Cells[1, 3] = "Мат плата";
            workSheet.Cells[1, 4] = "Процессор";
            workSheet.Cells[1, 5] = "Жёсткий диск";
        }
        public void DoWriteC(string id, string status, string dep, string name)
        {
            workSheet.Cells[it1, 1] = id;
            workSheet.Cells[it1, 2] = status;
            workSheet.Cells[it1, 3] = dep;
            workSheet.Cells[it1, 4] = name;
            it1++;
        }
        public void DoWriteP(string PDID, string ComputerId, string Name, string TypeName, string manufac, string status)
        {
            workSheet.Cells[it2, 1] = PDID;
            workSheet.Cells[it2, 2] = ComputerId;
            workSheet.Cells[it2, 3] = Name;
            workSheet.Cells[it2, 4] = TypeName;
            workSheet.Cells[it2, 5] = manufac;
            workSheet.Cells[it2, 6] = status;
            it2++;
        }
        public void DoWriteAC(string id, string status, string mat, string cp, string hdd)
        {
            workSheet.Cells[it1, 1] = id;
            workSheet.Cells[it1, 2] = status;
            workSheet.Cells[it1, 3] = mat;
            workSheet.Cells[it1, 4] = cp;
            workSheet.Cells[it1, 5] = hdd;
            it1++;
        }
        public void SaveFile(string str1)
        {
            ex.Application.ActiveWorkbook.SaveAs(str1 + "/" + DateTime.Now.ToString("dd MMMM yyyy HH mm ss") + ".xlsx");
            //ex.Visible = true;
            //ex.UserControl = true;
            workBook.Close();
        }
    }
}