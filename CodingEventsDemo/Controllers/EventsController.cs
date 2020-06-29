using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Event> events = new List<Event>(EventData.GetAll());

            return View(events);
        }

        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();
            return View(addEventViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    EventLocation = addEventViewModel.EventLocation,
                    NumberOfAttendees = addEventViewModel.NumberOfAttendees
                };

                EventData.Add(newEvent);
                return Redirect("/Events");
            }
            return View(addEventViewModel);
            
        }

        [HttpGet("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            ViewBag.edit = EventData.GetById(eventId);
            return View();
        }

        [HttpPost("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int id, string name, string description, string contactEmail, string eventLocation, int numberOfAttendees)
        {

            Event newEdit = EventData.GetById(id);

            newEdit.Name = name;
            newEdit.Description = description;
            newEdit.ContactEmail = contactEmail;
            newEdit.EventLocation = eventLocation;
            newEdit.NumberOfAttendees = numberOfAttendees;

            return Redirect("/Events");
        }

        public IActionResult Delete()
        {
            //ViewBag.title = "Delete Events";
            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events");
        }
    }
}

   