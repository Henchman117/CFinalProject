using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class ScoreController : Controller
    {
        private ScoreContext context { get; set; }

        public ScoreController(ScoreContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            // Viewbag
            return View("Edit", new ScoreModel());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            // Viewbag
            var scores = context.Scores.Find(id);
            return View(scores);
        }
        [HttpPost]
        public IActionResult Edit(ScoreModel scoreVariable)
        {
            if (ModelState.IsValid)
            {
                if (scoreVariable.ScoreId == 0)
                    context.Scores.Add(scoreVariable);
                else
                    context.Scores.Update(scoreVariable);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (scoreVariable.ScoreId == 0) ? "Add" : "Edit";
                // Viewbag
                return View(scoreVariable);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = context.Scores.Find(id);
            return View(contact);
        }
        [HttpPost]
        public IActionResult Delete(ScoreModel score)
        {
            context.Scores.Remove(score);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
