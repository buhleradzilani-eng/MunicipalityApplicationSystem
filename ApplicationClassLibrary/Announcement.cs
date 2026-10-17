using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationClassLibrary
{
    public class Announcement
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public string Location { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Title} - {EventDate:dd MMM yyyy}";
        }
    }
}
