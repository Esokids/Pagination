using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pagination.Data;
using Pagination.Models;

namespace Pagination.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDb db;

        public void SetPerson()
        {
            for (int i = 1; i <= 35; i++)
            {
                Person person = new Person { Name = $"Person{i}" };
                db.Add(person);
                db.SaveChanges();
            }
        }

        public HomeController(ILogger<HomeController> logger, AppDb db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            //SetPerson();
            return View();
        }

        public IActionResult Person()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
