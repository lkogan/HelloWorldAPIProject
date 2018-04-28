using HelloWorldAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace HelloWorldAPI.Models
{ 
    public static class DataFactory
    {
        //Assumption: we might want to return some additional contents based on language/region, 
        //hence use of subclasses with Factory pattern
        public static DataObject CreateHelloMessage(string cultureAbbrev)
        {
            switch (cultureAbbrev)
            {
                case "en-US":
                case "en-GB":
                    return new HelloWorldEnglish(cultureAbbrev);
                case "es-MX":
                case "es-PE":
                case "es-ES":
                    return new HelloWorldSpanish(cultureAbbrev);
                case "de-DE":
                    return new HelloWorldGerman(cultureAbbrev);
                default:
                    return new HelloWorldEnglish(cultureAbbrev);
            }
        }
    }

    public abstract class DataObject
    { 
        public long Id { get; protected set; }

        public string HelloMessage { get; set; }

        public string currentDateTime { get; set; }

        public CultureInfo culture { get; set; }

        public DataObject(string cultureAbbrev)
        {
            this.Id = Extensions.LongRandom();
            this.culture = new CultureInfo(cultureAbbrev);
            this.currentDateTime = DateTime.Now.FormatDateTimePerCulture(this.culture);
        }
    }

    public class HelloWorldEnglish : DataObject
    {
        public HelloWorldEnglish(string cultureAbbrev) : base(cultureAbbrev)
        {
            this.HelloMessage = "Hello World";           
        }

    }

    public class HelloWorldSpanish : DataObject
    { 
        public HelloWorldSpanish(string cultureAbbrev) : base(cultureAbbrev)
        {
            this.HelloMessage = "Hola Mundo";
        }
    }
    public class HelloWorldGerman : DataObject
    { 
        public HelloWorldGerman(string cultureAbbrev) : base(cultureAbbrev)
        {
            this.HelloMessage = "Hallo Welt";
        }
    }
}