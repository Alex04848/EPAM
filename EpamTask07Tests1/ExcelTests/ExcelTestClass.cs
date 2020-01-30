using EpamTask07.ExcelWriterClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask07Tests1.ExcelTests
{
    [TestClass()]
    public class ExcelTestClass
    {

        [DataTestMethod()]
        [DataRow(new string[] { @"..\..\ExcelFiles\Летняя Сессия 2018 Результат по Специальностям.xlsx" ,
         @"..\..\ExcelFiles\Зимняя Сессия 2018 Результат по Специальностям.xlsx" })]
        public void WriteResultsOfSessionForSpecialityTest(string[] pathes)
        {
            foreach (var path in pathes)
                if (File.Exists(path))
                    File.Delete(path);

            ExcelWriter.WriteResultsOfSessionForSpeciality();

            Assert.IsTrue(pathes.All(path => File.Exists(path)));
        }

        [DataTestMethod()]
        [DataRow(new string[] { @"..\..\ExcelFiles\Летняя Сессия 2018 Результат по Преподавателям.xlsx" ,
         @"..\..\ExcelFiles\Зимняя Сессия 2018 Результат по Преподавателям.xlsx" })]
        public void WriteResultsOfSessionForTeacherTest(string[] pathes)
        {
            foreach (var path in pathes)
                if (File.Exists(path))
                    File.Delete(path);

            ExcelWriter.WriteResultsOfSessionForTeacher();

            Assert.IsTrue(pathes.All(path => File.Exists(path)));
        }


        [DataTestMethod()]
        [DataRow(new string[] { @"..\..\ExcelFiles\Предметы 2018 года Результаты.xlsx" })]
        public void WriteResultsForYears(string[] pathes)
        {
            foreach (var path in pathes)
                if (File.Exists(path))
                    File.Delete(path);

            ExcelWriter.WriteResultsForYears();

            Assert.IsTrue(pathes.All(path => File.Exists(path)));
        }

        [DataTestMethod()]
        [DataRow(new string[] { @"..\..\ExcelFiles\Летняя Сессия 2018 Результат по Специальностям (Упорядоченный по Среднему баллу).xlsx" ,
         @"..\..\ExcelFiles\Зимняя Сессия 2018 Результат по Специальностям (Упорядоченный по Среднему баллу).xlsx" })]
        public void WriteResultsOfSessionForSpecialitiesOrderedTest(string[] pathes)
        {
            foreach (var path in pathes)
                if (File.Exists(path))
                    File.Delete(path);

            ExcelWriter.WriteResultsOfSessionForSpeciality(true);

            Assert.IsTrue(pathes.All(path => File.Exists(path)));
        }


        [DataTestMethod()]
        [DataRow(new string[] { @"..\..\ExcelFiles\Летняя Сессия 2018 Результат по Преподавателям (Упорядочено по среднему баллу).xlsx" ,
         @"..\..\ExcelFiles\Зимняя Сессия 2018 Результат по Преподавателям (Упорядочено по среднему баллу).xlsx" })]
        public void WriteResultsOfSessionForTeachersOrderedTest(string[] pathes)
        {
            foreach (var path in pathes)
                if (File.Exists(path))
                    File.Delete(path);

            ExcelWriter.WriteResultsOfSessionForTeacher(true);

            Assert.IsTrue(pathes.All(path => File.Exists(path)));
        }

    }
}
