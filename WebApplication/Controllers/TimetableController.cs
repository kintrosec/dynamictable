using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class TimetableController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserInput userInput)
        {
            if (!ModelState.IsValid)
            {
                return View(userInput);
            }

            // Generate a list of subjects (for demonstration purposes).
            var subjects = new List<Subject>();
            for (var i = 0; i < userInput.TotalSubjects; i++)
            {
                subjects.Add(new Subject { Name = $"Subject {i + 1}" });
            }

            // Shuffle the subjects randomly (for demonstration purposes).
            var random = new Random();
            subjects = subjects.OrderBy(_ => random.Next()).ToList();

            // Generate a timetable (you should implement your logic here).
            var timetable = new List<List<Subject>>();
            for (var day = 0; day < userInput.WorkingDays; day++)
            {
                var subjectsForDay = subjects.Skip(day * userInput.SubjectsPerDay)
                                             .Take(userInput.SubjectsPerDay)
                                             .ToList();
                timetable.Add(subjectsForDay);
            }

            return View("Timetable", timetable);
        }
    }

}
