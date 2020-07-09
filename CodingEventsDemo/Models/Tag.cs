using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodingEventsDemo.Models
{
    public class Tag
    {
         public int Id { get; set; }

        [Required(ErrorMessage = "Tag Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tag Name must be between 3 and 50 characters.")]
        public string Name { get; set; }

        public Tag()
        {
        }
        public Tag(string name)
        {
            Name = name;
        }

    }
}
