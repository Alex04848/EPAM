using EpamTask06;
using EpamTask06.ClassesOfUniversity;
using EpamTask07.LINQtoSQL_ORM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask07Tests.LINQtoSQL_ORM
{
    [TestClass()]
    public class TeacherRepositoryTest
    {
        IRepository<Teacher> repository = TeacherRepository.GetRepository;

        [TestMethod()]
        public void ReadTest()
        {

            

            Assert.Fail();
        }


    }
}
