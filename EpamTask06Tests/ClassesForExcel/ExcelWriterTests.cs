using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamTask06.ClassesForExcel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EpamTask06.ClassesForExcel.Tests
{
    [TestClass()]
    public class ExcelWriterTests
    {

        [DataTestMethod()]
        [DataRow(new string[]{@"..\..\ExcelFiles\Зимняя Сессия 2018 (ИТ-11).xlsx",
            @"..\..\ExcelFiles\Летняя Сессия 2018 (ИТ-11).xlsx",
            @"..\..\ExcelFiles\Зимняя Сессия 2018 (ЭУ-11).xlsx",
            @"..\..\ExcelFiles\Летняя Сессия 2018 (ЭУ-11).xlsx" })]
        public void WriteResultsTest(string[] paths)
        {
            foreach (string path in paths) 
                if (File.Exists(path))
                    File.Delete(path);
            

            ExcelWriter.WriteResults();


            Assert.IsTrue(paths.All(path => File.Exists(path)));
        }

        [DataTestMethod()]
        [DataRow(new string[]{@"..\..\ExcelFiles\Зимняя Сессия 2018 (ИТ-11) - Упорядочен по списку студентов.xlsx",
            @"..\..\ExcelFiles\Летняя Сессия 2018 (ИТ-11) - Упорядочен по списку студентов.xlsx",
            @"..\..\ExcelFiles\Зимняя Сессия 2018 (ЭУ-11) - Упорядочен по списку студентов.xlsx",
            @"..\..\ExcelFiles\Летняя Сессия 2018 (ЭУ-11) - Упорядочен по списку студентов.xlsx" })]
        public void WriteResultsOrderedByStudentsNameTest(string[] paths)
        {
            foreach (string path in paths)
                if (File.Exists(path))
                    File.Delete(path);


            ExcelWriter.WriteResultsOrderedByStudentsName();


            Assert.IsTrue(paths.All(path => File.Exists(path)));
        }


        [DataTestMethod()]
        [DataRow(new string[]{@"..\..\ExcelFiles\Зимняя Сессия 2018 (ИТ-11) - Упорядочен по оценкам.xlsx",
            @"..\..\ExcelFiles\Летняя Сессия 2018 (ИТ-11) - Упорядочен по оценкам.xlsx",
            @"..\..\ExcelFiles\Зимняя Сессия 2018 (ЭУ-11) - Упорядочен по оценкам.xlsx",
            @"..\..\ExcelFiles\Летняя Сессия 2018 (ЭУ-11) - Упорядочен по оценкам.xlsx" })]
        public void WriteResultsOrderedByGradesTest(string[] paths)
        {
            foreach (string path in paths)
                if (File.Exists(path))
                    File.Delete(path);


            ExcelWriter.WriteResultsOrderedByGrades();


            Assert.IsTrue(paths.All(path => File.Exists(path)));
        }

        [DataTestMethod()]
        [DataRow(new string[]{@"..\..\ExcelFiles\Зимняя Сессия 2018 (ИТ-11) - Студенты для отчисления.xlsx",
            @"..\..\ExcelFiles\Летняя Сессия 2018 (ИТ-11) - Студенты для отчисления.xlsx",
            @"..\..\ExcelFiles\Зимняя Сессия 2018 (ЭУ-11) - Студенты для отчисления.xlsx",
            @"..\..\ExcelFiles\Летняя Сессия 2018 (ЭУ-11) - Студенты для отчисления.xlsx" })]
        public void WriteStudentsForExpellingTest(string[] paths)
        {
            foreach (string path in paths)
                if (File.Exists(path))
                    File.Delete(path);


            ExcelWriter.WriteStudentsForExpelling();


            Assert.IsTrue(paths.All(path => File.Exists(path)));
        }

        [DataTestMethod()]
        [DataRow(new string[]{@"..\..\ExcelFiles\Зимняя Сессия 2018 (ИТ-11) - Студенты для отчисления упорядоченные по имени.xlsx",
            @"..\..\ExcelFiles\Летняя Сессия 2018 (ИТ-11) - Студенты для отчисления упорядоченные по имени.xlsx",
            @"..\..\ExcelFiles\Зимняя Сессия 2018 (ЭУ-11) - Студенты для отчисления упорядоченные по имени.xlsx",
            @"..\..\ExcelFiles\Летняя Сессия 2018 (ЭУ-11) - Студенты для отчисления упорядоченные по имени.xlsx" })]
        public void WriteStudentsForExpellingOrderedByStudentsNameTest(string[] paths)
        {
            foreach (string path in paths)
                if (File.Exists(path))
                    File.Delete(path);


            ExcelWriter.WriteStudentsForExpellingOrderedByStudentsName();


            Assert.IsTrue(paths.All(path => File.Exists(path)));
        }

        [DataTestMethod()]
        [DataRow(new string[]{@"..\..\ExcelFiles\Зимняя Сессия 2018 (ИТ-11) - Студенты для отчисления упорядоченные по оценкам.xlsx",
            @"..\..\ExcelFiles\Летняя Сессия 2018 (ИТ-11) - Студенты для отчисления упорядоченные по оценкам.xlsx",
            @"..\..\ExcelFiles\Зимняя Сессия 2018 (ЭУ-11) - Студенты для отчисления упорядоченные по оценкам.xlsx",
            @"..\..\ExcelFiles\Летняя Сессия 2018 (ЭУ-11) - Студенты для отчисления упорядоченные по оценкам.xlsx" })]
        public void WriteStudentsForExpellingOrderedByGradesTest(string[] paths)
        {
            foreach (string path in paths)
                if (File.Exists(path))
                    File.Delete(path);


            ExcelWriter.WriteStudentsForExpellingOrderedByGrades();


            Assert.IsTrue(paths.All(path => File.Exists(path)));
        }

        [DataTestMethod()]
        [DataRow(new string[]{@"..\..\ExcelFiles\Зимняя Сессия 2018 - Сводка по группам.xlsx",
            @"..\..\ExcelFiles\Летняя Сессия 2018 - Сводка по группам.xlsx"})]
        public void WriteResultsForGroupsTest(string[] paths)
        {
            foreach (string path in paths)
                if (File.Exists(path))
                    File.Delete(path);


            ExcelWriter.WriteResultsForGroups();


            Assert.IsTrue(paths.All(path => File.Exists(path)));
        }
    }
}