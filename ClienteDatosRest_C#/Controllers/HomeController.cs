using ClienteDatosRest_C_.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ClienteDatosRest_C_.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherService _weatherService = new WeatherService();

        // GET: Weather
        public async Task<ActionResult> Index(double lat = 19.4326, double lon = -99.1332)
        {
            var clima = await _weatherService.GetWeatherAsync(lat, lon);
            return View(clima);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}