using HelloWorldAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HelloWorldAPI.Services;

namespace HelloWorldAPI.Controllers
{
    public class DataController : ApiController
    {
        private DataRepository dataRepository;

        public DataController()
        {
            this.dataRepository = new DataRepository();
        }

        public DataObject [] Get(string cultureAbbrev)
        {
            return dataRepository.GetData(cultureAbbrev); //Hello world in English + datetime formatted as per culture
        }

        public DataObject[] GetAll()
        {
            return dataRepository.GetAllData(); //Multiple languages + datetime cultures
        }
    }
}
