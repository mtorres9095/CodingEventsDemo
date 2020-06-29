using System;
using System.Collections.Generic;
using System.Linq;
using CodingEventsDemo.Models;

namespace CodingEventsDemo.Data
{
    public class EventData
    {
        static private Dictionary<int, Event> Event = new Dictionary<int, Event>();

        // GetAll
        public static IEnumerable<Event> GetAll()
        {
            return Event.Values;
        }

        // Add
        public static void Add(Event newEvent)
        {
            Event.Add(newEvent.Id, newEvent);
        }

        // Remove
        public static void Remove(int id)
        {
            Event.Remove(id);
        }

        // GetById
        public static Event GetById(int id)
        {
            return Event[id];
        }
    }
}
