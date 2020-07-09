using System;
using CodingEventsDemo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = CodingEventsDemo.Models.RequiredAttribute;

namespace CodingEventsDemo.ViewModels
{
    public class AddEventCategoryViewModel
    {
        [Required(ErrorMessage = "Category Name is required.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Category Name must be between 3 and 20 characters.")]
        public string Name { get; set; }

        
    }
}
