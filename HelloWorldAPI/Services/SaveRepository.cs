using HelloWorldAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HelloWorldAPI.Services
{ 
    public interface IRepository<T> where T : DataObject
    {
        bool Save(T entity);
    }
     
    public class DatabaseRepository : IRepository<DataObject>
    {
        public bool Save(DataObject entity)
        { 
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                //TO do: add functionality for saving to database

                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public class TextRepository : IRepository<DataObject>
    {
        public bool Save(DataObject entity)
        {
            try
            {
                string saveTextDirectory = ConfigurationManager.AppSettings["SaveTextDirectory"];

                //TO DO: add functionality for saving to text file

                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public class XmlRepository : IRepository<DataObject>
    {
        public bool Save(DataObject entity)
        {
            try
            {
                string saveXMLDirectory = ConfigurationManager.AppSettings["SaveXMLDirectory"];

                //TO DO: add functionality for serializing object to XML, and saving to xml file

                return true;
            }
            catch
            {
                return false;
            } 
        }
    }
}