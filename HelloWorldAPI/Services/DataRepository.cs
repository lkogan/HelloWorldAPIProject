using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelloWorldAPI.Models;
using System.Globalization;
using HelloWorldAPI.Helpers;

namespace HelloWorldAPI.Services
{ 
    public class DataRepository
    {
        public const int SAVE_TO_DATABASE = 1;
        public const int EXPORT_TO_TEXT = 2;
        public const int EXPORT_TO_XML = 3;
         
        public DataRepository()
        { 

        }

        public DataObject[] GetData(string cultureAbbrev)
        {
            var msgObject = DataFactory.CreateHelloMessage(cultureAbbrev);

            return new DataObject[] { msgObject};
        }

        public DataObject[] GetAllData()
        {
            var englishMessage = DataFactory.CreateHelloMessage("en-US");
            var spanishMessage = DataFactory.CreateHelloMessage("es-MX");
            var germanMesage = DataFactory.CreateHelloMessage("de-DE");

            List<DataObject> lst = new List<DataObject>();
            lst.Add(englishMessage);
            lst.Add(spanishMessage);
            lst.Add(germanMesage);

            return lst.ToArray();
        }
         
        
        public bool SaveData(DataObject data, int SaveMethod)
        {
            bool result = false;
            try
            { 
                switch (SaveMethod)
                {
                    case SAVE_TO_DATABASE:
                        DatabaseRepository dr = new DatabaseRepository();
                        dr.Save(data);
                        break;

                    case EXPORT_TO_TEXT:
                        TextRepository tr = new TextRepository();
                        tr.Save(data);
                        break;

                    case EXPORT_TO_XML:
                        XmlRepository xr = new XmlRepository();
                        xr.Save(data);
                        break;
                }
               

                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            

            return result;
        }
    }
}