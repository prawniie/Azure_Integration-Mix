using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System.Net;

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
        public void GetForecastStringViaSmhiServiceAsync()
        {
            var smhi = new SmhiService();
            string forecast = smhi.Get("https://opendata-download-metfcst.smhi.se/api/category/pmp3g/version/2/geotype/point/lon/18.07/lat/59.33/data.json").Result;
        }
    }
}
