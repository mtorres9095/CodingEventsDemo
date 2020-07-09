using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {

        private EventDbContext context; 

        public EventsController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            // List<Event> events = new List<Event>(EventData.GetAll());
            List<Event> events = context.Events
                .Include(e => e.Category)
                .ToList();

            return View(events);
        }

        public IActionResult Add()
        {
            List<EventCategory> categories = context.Categories.ToList();
            AddEventViewModel addEventViewModel = new AddEventViewModel(categories);
            return View(addEventViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory theCategory = context.Categories.Find(addEventViewModel.CategoryId);
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    EventLocation = addEventViewModel.EventLocation,
                    NumberOfAttendees = addEventViewModel.NumberOfAttendees,
                    Category = theCategory
            };
                // EventData.Add(newEvent); 
                context.Events.Add(newEvent);
                context.SaveChanges(); // added

                return Redirect("/Events");
            }
            return View(addEventViewModel);
            
        }

        [HttpGet("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            //ViewBag.edit = EventData.GetById(eventId); -- error on EventData, changed an error on GetById
            ViewBag.edit = context.Events.Find(eventId);
            context.SaveChanges(); // added
            return View();
        }

        [HttpPost("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int id, string name, string description, string contactEmail, string eventLocation, int numberOfAttendees)
        {
            //Event newEdit = EventData.GetById(id); -- error on EventData, changed an error on GetById
            Event newEdit = context.Events.Find(id);

            newEdit.Name = name;
            newEdit.Description = description;
            newEdit.ContactEmail = contactEmail;
            newEdit.EventLocation = eventLocation;
            newEdit.NumberOfAttendees = numberOfAttendees;

            context.SaveChanges(); // added
            return Redirect("/Events");
        }

        public IActionResult Delete()
        {
            //ViewBag.title = "Delete Events";
            //ViewBag.events =EventData.GetAll();
            ViewBag.events = context.Events.ToList();
            //context.SaveChanges(); //added
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                //EventData.Remove(eventId);
                Event theEvent = context.Events.Find(eventId);
                context.Events.Remove(theEvent);
            }

            context.SaveChanges();

            return Redirect("/Events");
        }
        // /Events/Detail/5 ("path parameter" per the video (Event Details View Tag Model) Step 20.4)
        public IActionResult Detail(int id)
        {
            Event theEvent = context.Events
               .Include(e => e.Category)
               .Single(e => e.Id == id);

            List<EventTag> eventTags = context.EventTags
                .Where(et => et.EventId == id)
                .Include(et => et.Tag)
                .ToList();

            EventDetailViewModel viewModel = new EventDetailViewModel(theEvent, eventTags);
            return View(viewModel);
        }
    }
}

   