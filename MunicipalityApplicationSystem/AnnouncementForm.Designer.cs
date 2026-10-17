using System;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalityApplicationSystem
{
    partial class AnnouncementForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHeader, pnlFilters, pnlMain;
        private Label lblTitle, lblSubtitle, lblHeaderIcon, lblWelcome, lblSearch, lblCategory, lblDate, lblResultCount;
        private TextBox txtSearch;
        private ComboBox cmbCategory;
        private CheckBox chkFilterDate;
        private DateTimePicker dtpDate;
        private Button btnSearch, btnClear;
        private TableLayoutPanel tblContent, tblSide;
        private GroupBox grpEvents, grpRecommendations, grpRecentlyViewed;
        private FlowLayoutPanel eventPanel;
        private ListBox lstRecommendations, lstRecentlyViewed;
        private Label lblRecommendationHint;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblHeaderIcon = new Label();
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblWelcome = new Label();
            pnlFilters = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblDate = new Label();
            chkFilterDate = new CheckBox();
            dtpDate = new DateTimePicker();
            btnSearch = new Button();
            btnClear = new Button();
            lblResultCount = new Label();
            pnlMain = new Panel();
            tblContent = new TableLayoutPanel();
            grpEvents = new GroupBox();
            eventPanel = new FlowLayoutPanel();
            tblSide = new TableLayoutPanel();
            grpRecommendations = new GroupBox();
            lblRecommendationHint = new Label();
            lstRecommendations = new ListBox();
            grpRecentlyViewed = new GroupBox();
            lstRecentlyViewed = new ListBox();

            SuspendLayout();

            // Window
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1440, 900);
            MinimumSize = new Size(1080, 720);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Municipality Services | Community Announcements";
            Font = new Font("Segoe UI", 9F);

            // Header
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 132;
            pnlHeader.BackColor = Color.FromArgb(24, 43, 65);
            pnlHeader.Padding = new Padding(30, 18, 28, 16);
            pnlHeader.Controls.Add(lblWelcome);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblHeaderIcon);

            lblHeaderIcon.Text = "▦";
            lblHeaderIcon.Font = new Font("Segoe UI Symbol", 27F, FontStyle.Bold);
            lblHeaderIcon.ForeColor = Color.FromArgb(255, 170, 82);
            lblHeaderIcon.Location = new Point(30, 26);
            lblHeaderIcon.Size = new Size(58, 58);
            lblHeaderIcon.TextAlign = ContentAlignment.MiddleCenter;

            lblTitle.Text = "Community announcements";
            lblTitle.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(96, 23);
            lblTitle.Size = new Size(670, 43);

            lblSubtitle.Text = "Local events, service notices and important municipal updates.";
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(211, 221, 231);
            lblSubtitle.Location = new Point(99, 70);
            lblSubtitle.Size = new Size(700, 27);

            lblWelcome.Text = "●  COMMUNITY HUB";
            lblWelcome.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(255, 190, 119);
            lblWelcome.TextAlign = ContentAlignment.MiddleRight;
            lblWelcome.Dock = DockStyle.Right;
            lblWelcome.Width = 245;

            // Search and filters toolbar
            pnlFilters.Dock = DockStyle.Top;
            pnlFilters.Height = 156;
            pnlFilters.BackColor = Color.White;
            pnlFilters.Padding = new Padding(28, 13, 28, 12);
            pnlFilters.Controls.Add(lblResultCount);
            pnlFilters.Controls.Add(btnClear);
            pnlFilters.Controls.Add(btnSearch);
            pnlFilters.Controls.Add(chkFilterDate);
            pnlFilters.Controls.Add(dtpDate);
            pnlFilters.Controls.Add(lblDate);
            pnlFilters.Controls.Add(cmbCategory);
            pnlFilters.Controls.Add(lblCategory);
            pnlFilters.Controls.Add(txtSearch);
            pnlFilters.Controls.Add(lblSearch);

            lblSearch.Text = "⌕  SEARCH";
            lblSearch.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblSearch.ForeColor = Color.FromArgb(70, 86, 103);
            lblSearch.Location = new Point(28, 12);
            lblSearch.Size = new Size(270, 20);

            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(28, 36);
            txtSearch.Size = new Size(300, 31);
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;

            lblCategory.Text = "◇  CATEGORY";
            lblCategory.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblCategory.ForeColor = Color.FromArgb(70, 86, 103);
            lblCategory.Location = new Point(350, 12);
            lblCategory.Size = new Size(190, 20);

            cmbCategory.Font = new Font("Segoe UI", 10F);
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Location = new Point(350, 36);
            cmbCategory.Size = new Size(205, 31);

            lblDate.Text = "▦  EVENT DATE";
            lblDate.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblDate.ForeColor = Color.FromArgb(70, 86, 103);
            lblDate.Location = new Point(578, 12);
            lblDate.Size = new Size(160, 20);

            dtpDate.Font = new Font("Segoe UI", 10F);
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(578, 36);
            dtpDate.Size = new Size(160, 31);
            dtpDate.Enabled = false;

            chkFilterDate.Text = "Apply date filter";
            chkFilterDate.Font = new Font("Segoe UI", 9F);
            chkFilterDate.ForeColor = Color.FromArgb(70, 86, 103);
            chkFilterDate.Location = new Point(578, 72);
            chkFilterDate.Size = new Size(150, 24);
            chkFilterDate.CheckedChanged += chkFilterDate_CheckedChanged;

            btnSearch.Text = "⌕   Search";
            btnSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSearch.BackColor = Color.FromArgb(35, 91, 137);
            btnSearch.ForeColor = Color.White;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Location = new Point(770, 36);
            btnSearch.Size = new Size(124, 37);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.Click += btnSearch_Click;

            btnClear.Text = "↺  Reset";
            btnClear.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnClear.BackColor = Color.FromArgb(246, 239, 232);
            btnClear.ForeColor = Color.FromArgb(104, 69, 43);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.FlatAppearance.BorderColor = Color.FromArgb(232, 216, 202);
            btnClear.Location = new Point(905, 36);
            btnClear.Size = new Size(100, 37);
            btnClear.Cursor = Cursors.Hand;
            btnClear.Click += btnClear_Click;

            lblResultCount.Text = "●  Upcoming announcements";
            lblResultCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblResultCount.ForeColor = Color.FromArgb(103, 119, 136);
            lblResultCount.Location = new Point(28, 112);
            lblResultCount.Size = new Size(500, 22);

            // Main content area
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Padding = new Padding(24, 20, 24, 22);
            pnlMain.BackColor = Color.FromArgb(245, 247, 250);
            pnlMain.Controls.Add(tblContent);

            tblContent.Dock = DockStyle.Fill;
            tblContent.ColumnCount = 2;
            tblContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 69F));
            tblContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31F));
            tblContent.RowCount = 1;
            tblContent.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblContent.BackColor = pnlMain.BackColor;
            tblContent.Controls.Add(grpEvents, 0, 0);
            tblContent.Controls.Add(tblSide, 1, 0);

            grpEvents.Dock = DockStyle.Fill;
            grpEvents.Text = "  ▤  ALL ANNOUNCEMENTS";
            grpEvents.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            grpEvents.ForeColor = Color.FromArgb(31, 52, 73);
            grpEvents.BackColor = Color.White;
            grpEvents.Padding = new Padding(12, 12, 12, 12);
            grpEvents.Margin = new Padding(0, 0, 8, 0);
            grpEvents.Controls.Add(eventPanel);

            eventPanel.Dock = DockStyle.Fill;
            eventPanel.AutoScroll = true;
            eventPanel.FlowDirection = FlowDirection.TopDown;
            eventPanel.WrapContents = false;
            eventPanel.Padding = new Padding(5, 6, 8, 8);
            eventPanel.BackColor = Color.FromArgb(245, 247, 250);
            eventPanel.SizeChanged += eventPanel_SizeChanged;

            // Right rail
            tblSide.Dock = DockStyle.Fill;
            tblSide.ColumnCount = 1;
            tblSide.RowCount = 2;
            tblSide.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblSide.RowStyles.Add(new RowStyle(SizeType.Percent, 54F));
            tblSide.RowStyles.Add(new RowStyle(SizeType.Percent, 46F));
            tblSide.Padding = new Padding(10, 0, 0, 0);
            tblSide.Controls.Add(grpRecommendations, 0, 0);
            tblSide.Controls.Add(grpRecentlyViewed, 0, 1);

            grpRecommendations.Dock = DockStyle.Fill;
            grpRecommendations.Text = "  ✦  FOR YOU";
            grpRecommendations.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            grpRecommendations.ForeColor = Color.FromArgb(31, 52, 73);
            grpRecommendations.BackColor = Color.White;
            grpRecommendations.Padding = new Padding(12, 12, 12, 12);
            grpRecommendations.Margin = new Padding(0, 0, 0, 10);
            grpRecommendations.Controls.Add(lstRecommendations);
            grpRecommendations.Controls.Add(lblRecommendationHint);

            lblRecommendationHint.Text = "Suggestions based on your searches";
            lblRecommendationHint.Font = new Font("Segoe UI", 8.5F);
            lblRecommendationHint.ForeColor = Color.FromArgb(116, 130, 145);
            lblRecommendationHint.Dock = DockStyle.Top;
            lblRecommendationHint.Height = 30;
            lblRecommendationHint.TextAlign = ContentAlignment.MiddleLeft;

            lstRecommendations.Dock = DockStyle.Fill;
            lstRecommendations.BorderStyle = BorderStyle.None;
            lstRecommendations.Font = new Font("Segoe UI", 9F);
            lstRecommendations.ForeColor = Color.FromArgb(54, 69, 84);
            lstRecommendations.BackColor = Color.White;
            lstRecommendations.ItemHeight = 31;
            lstRecommendations.IntegralHeight = false;
            lstRecommendations.DoubleClick += lstRecommendations_DoubleClick;

            grpRecentlyViewed.Dock = DockStyle.Fill;
            grpRecentlyViewed.Text = "  ◷  RECENTLY VIEWED";
            grpRecentlyViewed.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            grpRecentlyViewed.ForeColor = Color.FromArgb(31, 52, 73);
            grpRecentlyViewed.BackColor = Color.White;
            grpRecentlyViewed.Padding = new Padding(12, 12, 12, 12);
            grpRecentlyViewed.Controls.Add(lstRecentlyViewed);

            lstRecentlyViewed.Dock = DockStyle.Fill;
            lstRecentlyViewed.BorderStyle = BorderStyle.None;
            lstRecentlyViewed.Font = new Font("Segoe UI", 9F);
            lstRecentlyViewed.ForeColor = Color.FromArgb(54, 69, 84);
            lstRecentlyViewed.BackColor = Color.White;
            lstRecentlyViewed.ItemHeight = 29;
            lstRecentlyViewed.IntegralHeight = false;

            // Add docked panels in this order so the header and filters remain at the top.
            Controls.Add(pnlMain);
            Controls.Add(pnlFilters);
            Controls.Add(pnlHeader);

            ResumeLayout(false);
        }
    }
}
