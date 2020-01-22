using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using _Excel = Microsoft.Office.Interop.Excel;

namespace EpamTask06.ClassesForExcel
{
    public static class Excel
    {
        static _Excel.Application app = new _Excel.Application();

        static _Excel.Workbook wBook = app.Workbooks.Add(Missing.Value);

        static _Excel.Worksheet wSheet = wBook.ActiveSheet;



        public static void GetWb()
            => wBook = app.Workbooks.Add(Missing.Value);

        public static void GetSheet()
            => wSheet = wBook.ActiveSheet;

        public static void Write(int i,int j,string value)
                => wSheet.Cells[i + 1, j + 1] = value;

        public static void SaveAs(string value)
            => wBook.SaveAs(value);

        public static void Save()
            => wBook.Save();


        public static void Close()
            => wBook.Close();


        public static void ChangeDefaultPath(string path)
            => app.DefaultFilePath = path;

    }
}
