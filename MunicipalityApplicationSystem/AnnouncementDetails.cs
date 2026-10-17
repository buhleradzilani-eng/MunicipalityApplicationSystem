
using System;
using System.Drawing;
using System.Windows.Forms;
using ApplicationClassLibrary;

namespace MunicipalityApplicationSystem
{
    public partial class AnnouncementDetails : Form
    {
        private readonly Announcement announcement;

        public AnnouncementDetails(Announcement selectedAnnouncement)
        {
            if (selectedAnnouncement == null)
                throw new ArgumentNullException(nameof(selectedAnnouncement));

            announcement = selectedAnnouncement;

            InitializeComponent();
            LoadAnnouncementDetails();
        }

        private void LoadAnnouncementDetails()
        {
            lblTitle.Text = announcement.Title;
            lblCategory.Text = "●  " + announcement.Category;
            lblDate.Text = announcement.EventDate.ToString(
                "dddd, dd MMMM yyyy");
            lblTime.Text = announcement.EventDate.ToString("HH:mm");
            lblLocation.Text = announcement.Location;
            txtDescription.Text = announcement.Description;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
