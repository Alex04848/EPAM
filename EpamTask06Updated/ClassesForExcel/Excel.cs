using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using _Excel = Microsoft.Office.Interop.Excel;

namespace EpamTask06.ClassesForExcel
{
    /// <summary>
    /// Static Excel Class For Writing values in Excel Files
    /// </summary>
    public static class Excel
    {
        /// <summary>
        /// Excel App
        /// </summary>
        static _Excel.Application app = new _Excel.Application();

        /// <summary>
        /// Current WorkBook
        /// </summary>
        static _Excel.Workbook wBook = app.Workbooks.Add(Missing.Value);

        /// <summary>
        /// Current Page
        /// </summary>
        static _Excel.Worksheet wSheet = wBook.ActiveSheet;


        /// <summary>
        /// Get new Work Book
        /// </summary>
        public static void GetWb()
            => wBook = app.Workbooks.Add(Missing.Value);

        /// <summary>
        /// Get new Sheet
        /// </summary>
        public static void GetSheet()
            => wSheet = wBook.ActiveSheet;

        /// <summary>
        /// Write Value
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="value"></param>
        public static void Write(int i,int j,string value)
                => wSheet.Cells[i + 1, j + 1] = value;
        /// <summary>
        /// Change File Name
        /// </summary>
        /// <param name="value"></param>
        public static void SaveAs(string value)
            => wBook.SaveAs(value);

        public static void Save()
            => wBook.Save();

        /// <summary>
        /// Close Work Book
        /// </summary>
        public static void Close()
            => wBook.Close();

        /// <summary>
        /// Change Directory
        /// </summary>
        /// <param name="path"></param>
        public static void ChangeDefaultPath(string path)
            => app.DefaultFilePath = path;

    }
}
