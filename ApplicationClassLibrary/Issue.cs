using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationClassLibrary
{
    public class Issue
    {
        private string issueId;
        private string title;
        private string location;
        private string category;
        private string description;
        private string filePath;

        public string IssueId
        {
            get { return issueId; }
            set { issueId = value; }
        }
        public string Title
        {
            get { return title; }
            set {  title = value; }
        }
        public string Location
        {
            get { return location; }
            set {  location = value; }
        }
        public string Category
        {
            get { return category; }
            set {  category = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string FilePath
        {
            get { return filePath; }
            set {  filePath = value; }
        }
    }
}
