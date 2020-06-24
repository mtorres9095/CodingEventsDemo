using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {
        static private List<Event> Events = new List<Event>();
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.events = Events;
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("Events/Add")]
        public IActionResult NewEvent(string name, string desc)
        {
            Events.Add(new Event(name, desc));

            return Redirect("/Events");

        }
    }

}
