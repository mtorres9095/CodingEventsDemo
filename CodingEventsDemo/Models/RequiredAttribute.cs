using System;

namespace CodingEventsDemo.Models
{
    internal class RequiredAttribute : Attribute
    {
        public string ErrorMessage { get; set; }
    }
}