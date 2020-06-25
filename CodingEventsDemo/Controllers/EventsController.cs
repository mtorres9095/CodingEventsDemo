using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("Events/Add")]
        public IActionResult NewEvent(string name, string description)
        {
            EventData.Add(new Event(name, description));

            return Redirect("/Events");
        }
        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach(int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }
            return Redirect("/Events");

        }
        //GET: /events/edit/{id}
        [HttpGet("/events/edit/{id}")]
        [Route("events/edit/{id}")]
        public IActionResult Edit(int id)
        {
            ViewBag.eventToEdit = EventData.GetById(id);
            return View();
        }
        //Post:/events/edit
        [HttpPost]
        [Route("/events/edit")]
        public IActionResult Update(int id, string name, string description)
        {
            Event eventToUpdate = EventData.GetById(id);
            eventToUpdate.Name = name;
            eventToUpdate.Description = description;

            return Redirect("/events");
        }
    }

}
