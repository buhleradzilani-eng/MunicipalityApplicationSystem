
using System;
using System.Collections.Generic;

namespace ApplicationClassLibrary
{
    public class ServiceRequest
    {
        public string RequestId { get; set; }
        public string ResidentName { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public int Priority { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime? DateCompleted { get; set; }

        public List<string> ProgressHistory { get; set; }
            = new List<string>();

        public ServiceRequest()
        {
            RequestId = string.Empty;
            ResidentName = string.Empty;
            Category = string.Empty;
            Description = string.Empty;
            Location = string.Empty;
            Status = "Submitted";
            Priority = 3;
            DateSubmitted = DateTime.Now;
        }

        public ServiceRequest(
            string requestId,
            string residentName,
            string category,
            string description,
            string location,
            string status,
            int priority,
            DateTime dateSubmitted)
            : this()
        {
            RequestId = requestId;
            ResidentName = residentName;
            Category = category;
            Description = description;
            Location = location;
            Status = status;
            Priority = priority;
            DateSubmitted = dateSubmitted;

            ProgressHistory.Add(
                $"{dateSubmitted:yyyy-MM-dd HH:mm} - {status}");
        }

        public void UpdateStatus(string newStatus)
        {
            if (string.IsNullOrWhiteSpace(newStatus))
                throw new ArgumentException("Status is required.");

            Status = newStatus;
            ProgressHistory.Add(
                $"{DateTime.Now:yyyy-MM-dd HH:mm} - {newStatus}");

            if (newStatus.Equals(
                "Completed",
                StringComparison.OrdinalIgnoreCase))
            {
                DateCompleted = DateTime.Now;
            }
        }
    }
}
