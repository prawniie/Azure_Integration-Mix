using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static HemNet_Azure.Test.SmhiClasses;

namespace HemNet_Azure.Test
{
    public class SmhiService
    {
        public async Task<string> Get(string url)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(url))
            using (HttpContent content = response.Content)
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception(response.ReasonPhrase);

                return await content.ReadAsStringAsync();
            }
        }
        public async Task<Rootobject> GetMeteorologicalForecast(decimal longitude, decimal latitude)
        {
            string sLongitude = Math.Round(longitude, 3).ToString(new CultureInfo("en"));
            string sLatitude = Math.Round(latitude, 3).ToString(new CultureInfo("en"));

            string page = $"https://opendata-download-metfcst.smhi.se/api/category/pmp3g/version/2/geotype/point/lon/{sLongitude}/lat/{sLatitude}/data.json";

            var smhi = new SmhiService();

            var result = await smhi.Get(page);
            return JsonConvert.DeserializeObject<Rootobject>(result);

        }

        public List<TimeTemp> FilterTemperature(Rootobject result, DateTime now)
        {
            List<TimeTemp> list = new List<TimeTemp>();
            var day = result.timeSeries.Where(d => d.validTime.Day == now.Day).ToList();

            foreach (var time in day)
            {
                TimeTemp timeTemp = new TimeTemp();
                timeTemp.Temp = time.parameters.Single(p => p.name == "t").values[0];
                timeTemp.Time = time.validTime;
                list.Add(timeTemp);
            }

            return list;
        }
    }
}
