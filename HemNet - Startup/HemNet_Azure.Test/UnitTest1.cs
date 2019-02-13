using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static HemNet_Azure.Test.SmhiClasses;

namespace HemNet_Azure.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetForecastString()
        {
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://opendata-download-metfcst.smhi.se/api/category/pmp3g/version/2/geotype/point/lon/18.07/lat/59.33/data.json");
                var weatherInfo = JObject.Parse(json);

            }

        }

        [TestMethod]
        public void GetForecastAsStringSmhiServiceAsync()
        {
            var smhi = new SmhiService();
            string forecast = smhi.Get("https://opendata-download-metfcst.smhi.se/api/category/pmp3g/version/2/geotype/point/lon/18.07/lat/59.33/data.json").Result;
        }

        [TestMethod]
        public void ExtractInfoFromForecast()
        {
            var service = new SmhiService();

            decimal longitud = 11.9751m;
            decimal latitud = 57.7087m;

            Rootobject result = service.GetMeteorologicalForecast(longitud, latitud).Result;
            //Parameter param = rootObject.timeSeries[0].parameters.Single(p => p.name == "t");
            //decimal temp = param.values[0];
            DateTime time = result.timeSeries[0].validTime;
            decimal temp = result.timeSeries[0].parameters[11].values[0];


        }

        [TestMethod]
        public void get_all_temperatures_for_a_position_a_given_day()
        {
            var service = new SmhiService();
            var result = service.GetMeteorologicalForecast(11.9751M, 57.7087M).Result;

            List<TimeTemp> timeTemps = service.FilterTemperature(result, DateTime.Now);
        }
    }
}
