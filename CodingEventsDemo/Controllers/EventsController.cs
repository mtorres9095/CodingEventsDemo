using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {
        static private Dictionary<string, string> Events = new Dictionary<string, string>();
        // GET: /<controller>/
        public IActionResult Index()
        {
            //Events.Add("Code With Pride", "Gigs from all over the world meeting to code with Daryn");
            //Events.Add("Apple WWDC", "Coders from the Reston area meeting to code with Daryn");
            //Events.Add("Strange Loop", "Coders from Maryland meeting to code with Daryn");
            ViewBag.events = Events;
            return View();
        }
        [HttpGet]
        public IActionResult AddEvent()
        {
            return View();
        }
        [HttpPost]
        [Route("Events/AddEvent")]
        public IActionResult NewEvent(string name, string desc)
        {
            Events.Add(name, desc);
            return Redirect("/Events");

        }
    }

}
