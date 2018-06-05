using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scalable.Models;
using Newtonsoft.Json;

namespace Scalable.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Hex(int delay = 0)
        {
            // do some intentional blocking on this 
            Task.Delay(delay).Wait();

            var random = new Random();
            var color = String.Format("#{0:X6}", random.Next(0x1000000));
            return Json(new JsonResponse() { Key="hexcode", Value=color, ResponseCode=200 });
        }


        public IActionResult Sample()
        {
            // do some intentional blocking on this 
            //Task.Delay(delay).Wait();

            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public class JsonResponse
        {
            public int ResponseCode { get; set; }
            public string Key { get; set; }
            public object Value { get; set; }
        }
    }
}
