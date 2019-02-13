using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            var smhi = new SmhiService();

            decimal longitud = 11.9751m;
            decimal latitud = 57.7087m;

            Rootobject rootObject = smhi.GetMeteorologicalForecast(longitud, latitud).Result;
            //var result = rootObject.timeSeries[0].parameters.Where(p => p.name == "t");
            decimal result = rootObject.timeSeries[0].parameters[11].values[0];


        }
    }
}
