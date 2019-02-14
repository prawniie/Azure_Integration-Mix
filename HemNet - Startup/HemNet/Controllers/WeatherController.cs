using Microsoft.AspNetCore.Mvc;
using HemNet_Azure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemNet_Azure.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Index()
        {
            var vm = new TimeTempVm();
            return View(vm);
        }

        public IActionResult DisplayTemperature(TimeTempVm vm)
        {

            try
            {
                var service = new SmhiService();
                var result = service.GetMeteorologicalForecast(vm.Latitude, vm.Longitude).Result;

                vm.TimeTemps = service.FilterTemperature(result, DateTime.Now);

                return View("Index", vm);

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.InnerException.Message;
                return View("Index",vm);
            }
        }

        //public IActionResult Success(int? lat, int? lon)
        //{
        //    int? x = lat;
        //    int? y = lon;
            
        //    return View();
        //}
    }
}
