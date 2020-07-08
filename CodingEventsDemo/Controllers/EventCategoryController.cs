using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingEventsDemo.Controllers
{
    public class EventCategoryController : Controller
    {
        private EventDbContext context;
        public EventCategoryController(EventDbContext dbContext)
        {
            context = dbContext;
        }
        //GET: /Eventcategory
        public IActionResult Index()
        {
            List<EventCategory> categories = context.Categories.ToList();

            return View(categories);
        }
        
    }
}
