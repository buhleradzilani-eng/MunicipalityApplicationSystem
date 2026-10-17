
using ApplicationClassLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalityApplicationSystem.Services
{
    public class AnnouncementService
    {
        // Fast lookup by event ID.
        public Dictionary<string, Announcement> EventsById { get; } = new Dictionary<string, Announcement>(StringComparer.OrdinalIgnoreCase);

        // Alternative hash-table lookup by event ID.
        public Hashtable EventHashTable { get; } = new Hashtable(StringComparer.OrdinalIgnoreCase);

        // Events organised chronologically.
        public SortedDictionary<DateTime, List<Announcement>> EventsByDate { get; } = new SortedDictionary<DateTime, List<Announcement>>();

        // Unique categories and event dates.
        public HashSet<string> Categories { get; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public HashSet<DateTime> EventDates { get; } = new HashSet<DateTime>();

        // Events waiting to be displayed or processed.
        public Queue<Announcement> UpcomingEventQueue { get; } = new Queue<Announcement>();

        // Recently viewed events, with the newest on top.
        public Stack<Announcement> RecentlyViewed { get; } = new Stack<Announcement>();

        // Higher-priority events are presented first.
        public PriorityQueue<Announcement, int> PriorityEvents { get; } = new PriorityQueue<Announcement, int>();

        private readonly HashSet<string> viewedIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public AnnouncementService()
        {
            LoadSampleEvents();
        }

        public void AddEvent(Announcement announcement)
        {
            if (announcement == null)
                throw new ArgumentNullException(nameof(announcement));

            if (string.IsNullOrWhiteSpace(announcement.Id))
                throw new ArgumentException("Event ID is required.");

            if (string.IsNullOrWhiteSpace(announcement.Title))
                throw new ArgumentException("Event title is required.");

            if (EventsById.ContainsKey(announcement.Id))
                throw new ArgumentException("An event with this ID already exists.");

            if (string.IsNullOrWhiteSpace(announcement.Category))
                announcement.Category = "General";

            EventsById.Add(announcement.Id, announcement);
            EventHashTable.Add(announcement.Id, announcement);
            Categories.Add(announcement.Category.Trim());
            EventDates.Add(announcement.EventDate.Date);

            if (!EventsByDate.TryGetValue(
                    announcement.EventDate.Date, out var events))
            {
                events = new List<Announcement>();
                EventsByDate.Add(announcement.EventDate.Date, events);
            }

            events.Add(announcement);

            if (announcement.EventDate.Date >= DateTime.Today)
            {
                UpcomingEventQueue.Enqueue(announcement);

                // Earlier event dates have higher priority.
                int priority = Math.Max(0,
                    (announcement.EventDate.Date - DateTime.Today).Days);

                PriorityEvents.Enqueue(announcement, priority);
            }
        }

        public List<Announcement> GetUpcomingEvents()
        {
            return EventsByDate
                .Where(group => group.Key >= DateTime.Today)
                .SelectMany(group => group.Value)
                .OrderBy(item => item.EventDate)
                .ToList();
        }

        public List<Announcement> Search(string searchText, string category,DateTime? selectedDate)
        {
            IEnumerable<Announcement> results = GetUpcomingEvents();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                string term = searchText.Trim();

                results = results.Where(item =>
                    item.Title.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    item.Description.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    item.Category.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    item.Location.Contains(term, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(category) && category != "All Categories")
            {
                results = results.Where(item => item.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
            }

            if (selectedDate.HasValue)
            {
                results = results.Where(item => item.EventDate.Date == selectedDate.Value.Date);
            }

            return results.OrderBy(item => item.EventDate).ToList();
        }

        public Announcement? GetById(string id)
        {
            return EventsById.TryGetValue(id, out var announcement)
                ? announcement
                : null;
        }

        public void RecordViewedEvent(Announcement announcement)
        {
            if (viewedIds.Add(announcement.Id))
                RecentlyViewed.Push(announcement);
        }

        private void LoadSampleEvents()
        {
            AddEvent(new Announcement
            {
                Id = "EV001",
                Title = "Community Meeting",
                Description = "Discuss local development and community concerns.",
                Category = "Community Meetings",
                EventDate = DateTime.Today.AddDays(2).AddHours(10),
                Location = "Municipal Community Hall"
            });

            AddEvent(new Announcement
            {
                Id = "EV002",
                Title = "Road Maintenance Notice",
                Description = "Scheduled maintenance and temporary road closures.",
                Category = "Road Closures",
                EventDate = DateTime.Today.AddDays(3).AddHours(8),
                Location = "Main Road"
            });

            AddEvent(new Announcement
            {
                Id = "EV003",
                Title = "Water Supply Update",
                Description = "Planned water maintenance and supply interruption notice.",
                Category = "Service Announcements",
                EventDate = DateTime.Today.AddDays(4).AddHours(9),
                Location = "Ward 5"
            });

            AddEvent(new Announcement
            {
                Id = "EV004",
                Title = "Community Health Awareness",
                Description = "Public health education and wellness information.",
                Category = "Awareness Events",
                EventDate = DateTime.Today.AddDays(5).AddHours(9),
                Location = "Community Clinic"
            });

            AddEvent(new Announcement
            {
                Id = "EV005",
                Title = "Waste Collection Campaign",
                Description = "Residents are invited to participate in a clean-up campaign.",
                Category = "Community Outreach",
                EventDate = DateTime.Today.AddDays(6).AddHours(8),
                Location = "Central Park"
            });

            AddEvent(new Announcement
            {
                Id = "EV006",
                Title = "Public Budget Consultation",
                Description = "Provide feedback on municipal priorities and budgeting.",
                Category = "Community Meetings",
                EventDate = DateTime.Today.AddDays(8).AddHours(11),
                Location = "Municipal Council Chamber"
            });

            AddEvent(new Announcement
            {
                Id = "EV007",
                Title = "Electricity Maintenance Notice",
                Description = "Scheduled electrical maintenance in selected streets.",
                Category = "Service Announcements",
                EventDate = DateTime.Today.AddDays(9).AddHours(8),
                Location = "Ward 3"
            });

            AddEvent(new Announcement
            {
                Id = "EV008",
                Title = "Youth Development Workshop",
                Description = "Information on skills development and youth programmes.",
                Category = "Awareness Events",
                EventDate = DateTime.Today.AddDays(10).AddHours(10),
                Location = "Youth Centre"
            });
        }
    }
}
