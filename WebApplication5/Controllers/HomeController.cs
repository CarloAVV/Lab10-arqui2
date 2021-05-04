using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.ValorRaspi = ValorRaspi;
            ViewBag.ValorWeb = ValorWeb;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //variables
        static string ValorWeb   = "0";
        static string ValorRaspi = "0";
        static int Resultado = 0;
        static string Test = "";

        [Route("api2/[controller]")]
        [HttpGet]
        public string Get()
        {
            int ValorWebInt;
            int ValorRaspiInt;
            if ((int.TryParse(ValorWeb,out ValorWebInt)) && (int.TryParse(ValorRaspi, out ValorRaspiInt)))
            {
                Resultado = ValorRaspiInt - ValorWebInt;
            }
            return Resultado.ToString();
            //return Test;
        }
        [Route("api2/[controller]")]
        [HttpPost]
        public void Post(IFormCollection form)
        {
            if(form.Keys.First() == "valorWeb")
            {
                ValorWeb = form["valorWeb"];
            }
            if (form.Keys.First() == "valorRaspi")
            {
                ValorRaspi = form["valorRaspi"];
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
