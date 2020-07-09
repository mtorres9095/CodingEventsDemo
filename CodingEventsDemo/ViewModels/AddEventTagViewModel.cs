using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace CodingEventsDemo.ViewModels
{
    public class AddEventTagViewModel
    {
        [Required(ErrorMessage = "Event is required")]
        public int EventId { get; set; }
        [Required(ErrorMessage = "Tag required")]
        public int TagId { get; set; }

        public Event Event { get; set; }

        public List<SelectListItem> Tags { get; set; }

        public AddEventTagViewModel(Event theEvent, List<Tag> possibleTags)
        {
            Tags = new List<SelectListItem>();
            foreach (var tag in possibleTags)
            {
                Tags.Add(new SelectListItem
                {
                    Value = tag.Id.ToString(),
                    Text = tag.Name
                });

            }
            Event = theEvent;

        }
        public AddEventTagViewModel()
        {
        }
    }
}
