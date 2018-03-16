using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace IntentRecognition
{
    class WeatherHandler
    {
        private static string currTemp = "", maxTemp = "", minTemp = "";
        private const string API_KEY = "25da974ec5035b0be0e1abf3e856542b";
        public static string[] GetWeather(string city)
        {
            string url =
            "http://api.openweathermap.org/data/2.5/weather?" +
            "q=" + city + "&mode=xml&units=metric&APPID=" + API_KEY;
            // Create a web client.
            using (WebClient client = new WebClient())
            {
                string xml = client.DownloadString(url);
                XmlDocument xml_document = new XmlDocument();
                xml_document.LoadXml(xml);
                minTemp = xml_document.DocumentElement.SelectSingleNode("temperature").Attributes["min"].Value;
                maxTemp = xml_document.DocumentElement.SelectSingleNode("temperature").Attributes["max"].Value;
                currTemp = xml_document.DocumentElement.SelectSingleNode("temperature").Attributes["value"].Value;

            }
            string[] q = { minTemp, maxTemp, currTemp };
            return q;

        }
    }
}