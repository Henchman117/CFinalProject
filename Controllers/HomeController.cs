using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsShaw.Controllers
{
    public class HomeController : Controller
    {
        // Home Controller
        private ScoreContext context { get; set; }
        public HomeController(ScoreContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var scores = context.Scores.OrderBy(c => c.Score).ToList();
            return View(scores);
        }
        // custom routing attribute
        [Route("Attribute")]
        public IActionResult Attribute()
        {
            return Content("Home controller, Attribute action");
        }
        // Default
        public IActionResult List(string Name)
        {
            return Content("name=" + Name);
        }
        // custom routing rules
        public IActionResult List2(string id = "All", int page = 1)
        {
            return Content("id=" + id + " page=" + page);
        }
    }
}