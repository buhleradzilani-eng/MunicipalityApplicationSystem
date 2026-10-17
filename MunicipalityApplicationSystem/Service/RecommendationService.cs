
using ApplicationClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalityApplicationSystem.Services
{
    public class RecommendationService
    {
        // Category -> number of searches.
        private readonly Dictionary<string, int> searchCounts =
            new Dictionary<string, int>(
                StringComparer.OrdinalIgnoreCase);

        // Category -> keywords commonly used by residents.
        private readonly Dictionary<string, HashSet<string>> categoryKeywords =
            new Dictionary<string, HashSet<string>>(
                StringComparer.OrdinalIgnoreCase)
            {
                ["Community Meetings"] = new HashSet<string>(
                new[] { "meeting", "council", "budget", "community" },
                StringComparer.OrdinalIgnoreCase),

                ["Road Closures"] = new HashSet<string>(
                new[] { "road", "closure", "traffic", "maintenance" },
                StringComparer.OrdinalIgnoreCase),

                ["Service Announcements"] = new HashSet<string>(
                new[] { "water", "electricity", "service", "supply" },
                StringComparer.OrdinalIgnoreCase),

                ["Awareness Events"] = new HashSet<string>(
                new[] { "health", "awareness", "workshop", "youth" },
                StringComparer.OrdinalIgnoreCase),

                ["Community Outreach"] = new HashSet<string>(
                new[] { "waste", "clean-up", "outreach", "environment" },
                StringComparer.OrdinalIgnoreCase)
            };

        public void RecordSearch(string category, string searchText)
        {
            if (!string.IsNullOrWhiteSpace(category) &&
                category != "All Categories")
            {
                Increment(category);
            }

            if (string.IsNullOrWhiteSpace(searchText))
                return;

            string text = searchText.Trim();

            // Learn from words in a search, even if no category
            // filter was selected.
            foreach (var entry in categoryKeywords)
            {
                if (entry.Value.Any(keyword =>
                    text.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
                {
                    Increment(entry.Key);
                }
            }
        }

        private void Increment(string category)
        {
            if (!searchCounts.ContainsKey(category))
                searchCounts[category] = 0;

            searchCounts[category]++;
        }

        public List<Announcement> Recommend(
            IEnumerable<Announcement> upcomingEvents,
            IEnumerable<string> viewedEventIds,
            int maximumResults = 3)
        {
            var viewed = new HashSet<string>(
                viewedEventIds, StringComparer.OrdinalIgnoreCase);

            return upcomingEvents
                .Where(item =>
                    item.EventDate.Date >= DateTime.Today &&
                    !viewed.Contains(item.Id))
                .Select(item => new
                {
                    Event = item,
                    Score = CalculateScore(item)
                })
                .Where(item => item.Score > 0)
                .OrderByDescending(item => item.Score)
                .ThenBy(item => item.Event.EventDate)
                .Take(maximumResults)
                .Select(item => item.Event)
                .ToList();
        }

        private int CalculateScore(Announcement announcement)
        {
            int score = 0;

            if (searchCounts.TryGetValue(
                announcement.Category, out int count))
            {
                score += count * 10;
            }

            // Add a keyword similarity score based on the event title
            // and description.
            if (categoryKeywords.TryGetValue(
                announcement.Category, out var keywords))
            {
                string content =
                    announcement.Title + " " + announcement.Description;

                score += keywords.Count(keyword =>
                    content.Contains(keyword,
                        StringComparison.OrdinalIgnoreCase)) * 2;
            }

            return score;
        }

        public void ResetSearchHistory()
        {
            searchCounts.Clear();
        }
    }
}
