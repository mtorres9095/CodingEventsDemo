using System;
using System.Collections.Generic;
using System.Linq;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
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

        //GET: EventCategory/Create
        public IActionResult Create()
        {
            AddEventCategoryViewModel viewModel = new AddEventCategoryViewModel();
            return View(viewModel);

            //AddEventCategoryViewModel addEventCategoryViewModel = new AddEventCategoryViewModel();
            //return View(addEventCategoryViewModel);
            
        }

        //Post: EventCategory/Create
        [HttpPost] //add ("EventCategory/Create")
        public IActionResult Create(AddEventCategoryViewModel viewModel)
        // public IActionResult ProcessCreateEventCategoryForm(AddEventCategoryViewModel addEventCategoryViewModel)
         {
                if (ModelState.IsValid)
                {
                    EventCategory eventCategory = new EventCategory()
                    //EventCategory newEventCategory = new EventCategory // eventCategory for new...
                    {
                        
                        Name = viewModel.Name
                        //Name = addEventCategoryViewModel.Name //viewModel only

                    };

                    context.Categories.Add(eventCategory); // .Category
                    context.SaveChanges();//new 
                     // context.Add(newEventCategory); // .Category  delete new and change tp event..
                    
                    return Redirect("/EventCategory");

                }
             return View("Create", viewModel);
            // return View(addEventCategoryViewModel);
         }

        
    }
}
