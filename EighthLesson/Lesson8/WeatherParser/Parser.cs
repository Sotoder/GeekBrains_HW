using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WeatherParser
{
    class Parser
    {
        HttpClient http;
        List<string> urls;

        public Parser()
        {
            urls = new List<string>
            {
                @"https://xml.meteoservice.ru/export/gismeteo/point/199.xml",
                @"https://xml.meteoservice.ru/export/gismeteo/point/146.xml",
                @"https://xml.meteoservice.ru/export/gismeteo/point/32277.xml",
                @"https://xml.meteoservice.ru/export/gismeteo/point/135.xml"
            };
            http = new HttpClient();
        }

        public ObservableCollection<WeatherData> Parsexml()
        {
            ObservableCollection<WeatherData> wetherCollection = new ObservableCollection<WeatherData>();

            foreach (string url in urls)
            {
                string urlXML = http.GetStringAsync(url).Result;

                var weatherFromXML = XDocument.Parse(urlXML)
                    .Descendants("MMWEATHER")
                    .Descendants("REPORT")
                    .Descendants("TOWN")
                    .ToList();
                foreach(var xmlFromTown in weatherFromXML)
                {
                    foreach (var forecast in xmlFromTown.Elements("FORECAST"))
                    {
                        wetherCollection.Add(
                            new WeatherData()
                            {
                                Town = xmlFromTown.Attribute("sname").Value,
                                Day = Convert.ToDateTime(forecast.Attribute("day").Value + @"/" +
                                                         forecast.Attribute("month").Value + @"/" +
                                                         forecast.Attribute("year").Value + @" " +
                                                         forecast.Attribute("hour").Value + @":00:00.000"),
                                PressureMax = forecast.Element("PRESSURE").Attribute("max").Value,
                                PressureMin = forecast.Element("PRESSURE").Attribute("min").Value,
                                TemperatureMax = forecast.Element("TEMPERATURE").Attribute("max").Value,
                                TemperatureMin = forecast.Element("TEMPERATURE").Attribute("min").Value,
                                WindForceMax = forecast.Element("WIND").Attribute("max").Value,
                                WindForceMin = forecast.Element("WIND").Attribute("min").Value
                            }
                        );
                    }
                }
            }
            return wetherCollection;
        }
    }
}
