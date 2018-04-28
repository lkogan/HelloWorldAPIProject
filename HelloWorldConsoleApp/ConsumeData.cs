using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;


namespace HelloWorldConsoleApp
{
    public class ConsumeData
    {
        public void GetAPIData() //Get All Events Records  
        {
            using (var client = new WebClient()) 
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
 
                string ApiURL = ConfigurationManager.AppSettings["HelloWorldAPIURL"]; 
                var result = client.DownloadString(ApiURL); //URI  

                Console.WriteLine("Displaying 'Hello World' in 3 languages, with date/time formatted as per corresponding culture:");

                string formattedResult = Environment.NewLine;

                dynamic stuff1 = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                 
                for (int i = 0; i < stuff1.Count; i++)
                {
                    formattedResult += stuff1[i].HelloMessage.Value + "\t\t" + stuff1[i].currentDateTime.Value + Environment.NewLine;
                }
                 
                Console.WriteLine(formattedResult);

                var input = Console.ReadLine();
            }
        }
    }
}