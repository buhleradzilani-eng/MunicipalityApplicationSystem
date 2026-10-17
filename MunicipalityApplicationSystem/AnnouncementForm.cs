using ApplicationClassLibrary;
using MunicipalityApplicationSystem.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalityApplicationSystem
{
    public partial class AnnouncementForm : Form
    {
        private readonly AnnouncementService announcementService;
        private readonly RecommendationService recommendationService;

        private readonly HashSet<string> viewedEventIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        private List<Announcement> currentRecommendations = new List<Announcement>();

        public AnnouncementForm()
        {
            InitializeComponent();

            announcementService = new AnnouncementService();
            recommendationService = new RecommendationService();

            MunicipalityTheme.StyleForm(this);
            MunicipalityTheme.StyleButton(btnSearch, true);
            MunicipalityTheme.StyleButton(btnClear, false);
            MunicipalityTheme.StyleInput(txtSearch);
            MunicipalityTheme.StyleInput(cmbCategory);
            MunicipalityTheme.StyleInput(dtpDate);

            pnlHeader.BackColor = Color.FromArgb(24, 43, 65);
            lblTitle.ForeColor = Color.White;
            lblSubtitle.ForeColor = Color.FromArgb(211, 221, 231);
            lblHeaderIcon.ForeColor = Color.FromArgb(255, 170, 82);
            lblWelcome.ForeColor = Color.FromArgb(255, 190, 119);

            pnlFilters.BackColor = Color.White;
            pnlMain.BackColor = Color.FromArgb(245, 247, 250);
            tblContent.BackColor = pnlMain.BackColor;
            eventPanel.BackColor = Color.FromArgb(245, 247, 250);

            // Keep date selection disabled until the user checks "Apply date filter".
            dtpDate.Enabled = chkFilterDate.Checked;


            LoadCategories();
            DisplayEvents(announcementService.GetUpcomingEvents());
            RefreshRecommendations();
            RefreshRecentlyViewed();
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("All Categories");

            foreach (string category in announcementService.Categories.OrderBy(c => c))
                cmbCategory.Items.Add(category);

            cmbCategory.SelectedIndex = 0;
        }

        private void chkFilterDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpDate.Enabled = chkFilterDate.Checked;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string category = cmbCategory.SelectedItem?.ToString() ?? "All Categories";
            string searchText = txtSearch.Text.Trim();
            DateTime? selectedDate = chkFilterDate.Checked
                ? dtpDate.Value.Date
                : (DateTime?)null;

            recommendationService.RecordSearch(category, searchText);
            DisplayEvents(announcementService.Search(searchText, category, selectedDate));
            RefreshRecommendations();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            if (cmbCategory.Items.Count > 0)
                cmbCategory.SelectedIndex = 0;

            chkFilterDate.Checked = false;
            dtpDate.Value = DateTime.Today;

            DisplayEvents(announcementService.GetUpcomingEvents());
            RefreshRecommendations();
        }

        private void eventPanel_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control control in eventPanel.Controls)
            {
                if (control is Panel card && card.Tag is Announcement)
                {
                    card.Width = Math.Max(390, eventPanel.ClientSize.Width - 30);
                    foreach (Control child in card.Controls)
                    {
                        if (child.Name == "eventTitle")
                            child.Width = card.Width - 45;
                        if (child.Name == "eventDescription")
                            child.Width = Math.Max(150, card.Width - 165);
                        if (child.Name == "detailsButton")
                            child.Left = card.Width - 137;
                    }
                }
            }
        }

        private void DisplayEvents(List<Announcement> events)
        {
            eventPanel.SuspendLayout();
            eventPanel.Controls.Clear();
            lblResultCount.Text = $"{events.Count} event(s) found";

            if (events.Count == 0)
            {
                eventPanel.Controls.Add(new Label
                {
                    Text = "No upcoming events match your search.\nTry another keyword, category or date.",
                    AutoSize = true,
                    Padding = new Padding(16),
                    ForeColor = MunicipalityTheme.Muted,
                    Font = MunicipalityTheme.MakeFont(10)
                });
            }

            foreach (Announcement item in events)
                eventPanel.Controls.Add(CreateEventCard(item));

            eventPanel.ResumeLayout();
        }

        private Panel CreateEventCard(Announcement item)
        {
            int cardWidth = Math.Max(390, eventPanel.ClientSize.Width - 30);

            var card = new Panel
            {
                Width = cardWidth,
                Height = 168,
                Margin = new Padding(4, 5, 4, 9),
                BackColor = MunicipalityTheme.White,
                BorderStyle = BorderStyle.FixedSingle,
                Tag = item
            };

            var accent = new Panel
            {
                BackColor = MunicipalityTheme.Orange,
                Dock = DockStyle.Left,
                Width = 5
            };

            var dateBadge = new Panel
            {
                BackColor = MunicipalityTheme.SoftCream,
                Location = new Point(17, 14),
                Size = new Size(64, 61)
            };

            var dateDay = new Label
            {
                Text = item.EventDate.ToString("dd"),
                Font = MunicipalityTheme.MakeFont(17, FontStyle.Bold),
                ForeColor = MunicipalityTheme.OrangeDark,
                Dock = DockStyle.Top,
                Height = 34,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var dateMonth = new Label
            {
                Text = item.EventDate.ToString("MMM").ToUpperInvariant(),
                Font = MunicipalityTheme.MakeFont(8.5f, FontStyle.Bold),
                ForeColor = MunicipalityTheme.DarkBrown,
                Dock = DockStyle.Bottom,
                Height = 22,
                TextAlign = ContentAlignment.MiddleCenter
            };

            dateBadge.Controls.Add(dateMonth);
            dateBadge.Controls.Add(dateDay);

            var title = new Label
            {
                Name = "eventTitle",
                Text = item.Title,
                Font = MunicipalityTheme.MakeFont(12, FontStyle.Bold),
                ForeColor = MunicipalityTheme.DarkBrown,
                Location = new Point(94, 14),
                Size = new Size(cardWidth - 115, 25),
                AutoEllipsis = true
            };

            var category = new Label
            {
                Text = item.Category.ToUpperInvariant(),
                Font = MunicipalityTheme.MakeFont(8.2f, FontStyle.Bold),
                ForeColor = MunicipalityTheme.OrangeDark,
                BackColor = MunicipalityTheme.SoftCream,
                Location = new Point(94, 43),
                AutoSize = true,
                Padding = new Padding(5, 3, 5, 3)
            };

            var time = new Label
            {
                Text = item.EventDate.ToString("dddd, dd MMM yyyy  •  HH:mm"),
                Font = MunicipalityTheme.MakeFont(8.8f),
                ForeColor = MunicipalityTheme.Text,
                Location = new Point(94, 73),
                AutoSize = true
            };

            var location = new Label
            {
                Text = "Location: " + item.Location,
                Font = MunicipalityTheme.MakeFont(8.8f),
                ForeColor = MunicipalityTheme.Muted,
                Location = new Point(94, 95),
                AutoSize = true
            };

            var description = new Label
            {
                Name = "eventDescription",
                Text = item.Description,
                Font = MunicipalityTheme.MakeFont(8.5f),
                ForeColor = MunicipalityTheme.Muted,
                Location = new Point(94, 119),
                Size = new Size(Math.Max(150, cardWidth - 245), 32),
                AutoEllipsis = true
            };

            var details = new Button
            {
                Name = "detailsButton",
                Text = "◉  View details  ›",
                Size = new Size(125, 34),
                Location = new Point(cardWidth - 145, 117),
                Tag = item
            };
            MunicipalityTheme.StyleButton(details, true);
            details.Click += (s, e) => ShowEventDetails(item);

            card.Controls.Add(dateBadge);
            card.Controls.Add(title);
            card.Controls.Add(category);
            card.Controls.Add(time);
            card.Controls.Add(location);
            card.Controls.Add(description);
            card.Controls.Add(details);
            card.Controls.Add(accent);

            return card;
        }


        private void ShowEventDetails(Announcement item)
        {
            if (item == null)
                return;

            // Record the selected announcement in the viewing history.
            announcementService.RecordViewedEvent(item);
            viewedEventIds.Add(item.Id);

            // Refresh the recommendation and history panels.
            RefreshRecentlyViewed();
            RefreshRecommendations();

            // Open the full announcement details window.
            using (AnnouncementDetails details = new AnnouncementDetails(item))
            {
                details.ShowDialog(this);
            }
        }


        private void RefreshRecommendations()
        {
            lstRecommendations.Items.Clear();
            currentRecommendations = recommendationService.Recommend(
                announcementService.GetUpcomingEvents(), viewedEventIds, 5);

            foreach (Announcement item in currentRecommendations)
                lstRecommendations.Items.Add($"{item.EventDate:dd MMM}  |  {item.Title}");

            if (currentRecommendations.Count == 0)
                lstRecommendations.Items.Add("Search a category to personalise suggestions.");
        }

        private void RefreshRecentlyViewed()
        {
            lstRecentlyViewed.Items.Clear();

            foreach (Announcement item in announcementService.RecentlyViewed)
                lstRecentlyViewed.Items.Add($"{item.EventDate:dd MMM}  |  {item.Title}");
        }

        private void lstRecommendations_DoubleClick(object sender, EventArgs e)
        {
            int index = lstRecommendations.SelectedIndex;
            if (index >= 0 && index < currentRecommendations.Count)
                ShowEventDetails(currentRecommendations[index]);
        }
    }
}
