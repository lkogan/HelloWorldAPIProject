using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorldAPI.Services;
using HelloWorldAPI.Controllers;
using HelloWorldAPI.Models;
using System;
using System.Linq;

namespace HelloWorldTest
{
    [TestClass]
    public class HelloWorldTestClass
    {
        private DataObject[] data;

        [TestInitialize]       
        public void Setup()
        {
            using (DataController dc = new DataController())
            {
                data = dc.GetAll();
            }
        }
         
        [TestMethod]        
        public void TestItemsCount()
        { 
            Assert.AreEqual(3, data.Length);
        }

        [TestMethod]
        public void TestItemValue()
        {
            var DataObject = data.Where(x => x.culture.Name.Equals("es-MX")).FirstOrDefault();
            Assert.AreEqual(DataObject.HelloMessage, "Hola Mundo");
        }

        [TestMethod]
        public void TestDateTime()
        {
            try
            {
                var DataObject = data.Where(x => x.culture.Name.Equals("en-US")).FirstOrDefault();
                DateTime dt = DateTime.Parse(DataObject.currentDateTime, DataObject.culture);

                if (dt.Date == DateTime.Now.Date)
                {
                    return;
                }
                else
                {
                    Assert.Fail();
                }
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestSavingData()
        {
            DataRepository dr = new DataRepository();

            var DataObject = data.Where(x => x.culture.Name.Equals("en-US")).FirstOrDefault();
            bool result = dr.SaveData(DataObject, DataRepository.EXPORT_TO_TEXT);

            Assert.AreEqual(result, true);
        }

        [TestCleanup]
        public void ShutDown()
        {
            data = null;
        }
 
    }
}
