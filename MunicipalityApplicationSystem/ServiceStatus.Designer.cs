
namespace MunicipalityApplicationSystem
{
    partial class ServiceStatus
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Panel pnlTable;
        private System.Windows.Forms.Panel pnlFooter;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Label lblCount;

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox cmbStatus;

        private System.Windows.Forms.DataGridView dgvRequests;

        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Label lblRequestId;
        private System.Windows.Forms.Label lblRequestStatus;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblHistoryTitle;
        private System.Windows.Forms.ListBox lstHistory;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components =
                new System.ComponentModel.Container();

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.pnlTable = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();

            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();

            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();

            this.dgvRequests = new System.Windows.Forms.DataGridView();

            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.lblRequestId = new System.Windows.Forms.Label();
            this.lblRequestStatus = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblHistoryTitle = new System.Windows.Forms.Label();
            this.lstHistory = new System.Windows.Forms.ListBox();

            this.pnlHeader.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlTable.SuspendLayout();
            this.pnlFooter.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvRequests)).BeginInit();

            this.grpDetails.SuspendLayout();
            this.SuspendLayout();

            // ==========================================
            // COLOUR PALETTE
            // ==========================================
            // Dark brown: RGB(92, 56, 37)
            // Burnt orange: RGB(198, 93, 33)
            // Soft orange: RGB(232, 177, 122)
            // Cream: RGB(248, 241, 232)
            // Light cream: RGB(252, 246, 239)

            // ==========================================
            // MAIN FORM
            // ==========================================

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.FromArgb(248, 241, 232);

            this.ClientSize =
                new System.Drawing.Size(1150, 780);

            this.MinimumSize =
                new System.Drawing.Size(950, 680);

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "Municipal Services | Service Request Status";

            this.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            // ==========================================
            // HEADER PANEL
            // ==========================================

            this.pnlHeader.BackColor =
                System.Drawing.Color.FromArgb(92, 56, 37);

            this.pnlHeader.Dock =
                System.Windows.Forms.DockStyle.Top;

            this.pnlHeader.Height = 115;

            this.pnlHeader.Padding =
                new System.Windows.Forms.Padding(25, 15, 20, 10);

            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            // Title
            this.lblTitle.AutoSize = true;

            this.lblTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 23F,
                    System.Drawing.FontStyle.Bold);

            this.lblTitle.ForeColor =
                System.Drawing.Color.FromArgb(255, 255, 255);

            this.lblTitle.Location =
                new System.Drawing.Point(25, 12);

            this.lblTitle.Text =
                "Service Request Status";

            // Subtitle
            this.lblSubtitle.AutoSize = true;

            this.lblSubtitle.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.lblSubtitle.ForeColor =
                System.Drawing.Color.FromArgb(248, 214, 183);

            this.lblSubtitle.Location =
                new System.Drawing.Point(29, 68);

            this.lblSubtitle.Text =
                "Track municipal issues, monitor progress and view updates.";

            // ==========================================
            // SEARCH AND FILTER PANEL
            // ==========================================

            this.pnlSearch.BackColor =
                System.Drawing.Color.FromArgb(255, 255, 255);

            this.pnlSearch.Dock =
                System.Windows.Forms.DockStyle.Top;

            this.pnlSearch.Height = 115;

            this.pnlSearch.Padding =
                new System.Windows.Forms.Padding(25, 12, 20, 10);

            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.lblFilter);
            this.pnlSearch.Controls.Add(this.cmbStatus);
            this.pnlSearch.Controls.Add(this.btnRefresh);

            // Search label
            this.lblSearch.AutoSize = true;

            this.lblSearch.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);

            this.lblSearch.ForeColor =
                System.Drawing.Color.FromArgb(92, 56, 37);

            this.lblSearch.Location =
                new System.Drawing.Point(25, 10);

            this.lblSearch.Text = "TRACK A REQUEST";

            // Search textbox
            this.txtSearch.Location =
                new System.Drawing.Point(28, 37);

            this.txtSearch.Size =
                new System.Drawing.Size(245, 30);

            this.txtSearch.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.txtSearch.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtSearch.BackColor =
                System.Drawing.Color.FromArgb(252, 246, 239);

            this.txtSearch.ForeColor =
                System.Drawing.Color.FromArgb(72, 45, 30);

            this.txtSearch.PlaceholderText =
                "Enter request ID, e.g. SR-1001";

            // Track button
            this.btnSearch.Location =
                new System.Drawing.Point(285, 35);

            this.btnSearch.Size =
                new System.Drawing.Size(105, 34);

            this.btnSearch.Text = "Track";

            this.btnSearch.BackColor =
                System.Drawing.Color.FromArgb(198, 93, 33);

            this.btnSearch.ForeColor =
                System.Drawing.Color.White;

            this.btnSearch.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnSearch.FlatAppearance.BorderSize = 0;

            this.btnSearch.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);

            this.btnSearch.Cursor =
                System.Windows.Forms.Cursors.Hand;

            this.btnSearch.UseVisualStyleBackColor = false;

            this.btnSearch.Click +=
                new System.EventHandler(this.btnSearch_Click);

            // Filter label
            this.lblFilter.AutoSize = true;

            this.lblFilter.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);

            this.lblFilter.ForeColor =
                System.Drawing.Color.FromArgb(92, 56, 37);

            this.lblFilter.Location =
                new System.Drawing.Point(420, 10);

            this.lblFilter.Text = "FILTER BY STATUS";

            // Status dropdown
            this.cmbStatus.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbStatus.Location =
                new System.Drawing.Point(423, 37);

            this.cmbStatus.Size =
                new System.Drawing.Size(195, 30);

            this.cmbStatus.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.cmbStatus.BackColor =
                System.Drawing.Color.FromArgb(252, 246, 239);

            this.cmbStatus.ForeColor =
                System.Drawing.Color.FromArgb(72, 45, 30);

            this.cmbStatus.Items.AddRange(new object[]
            {
                "All",
                "Submitted",
                "In Progress",
                "Pending",
                "Completed",
                "Rejected"
            });

            this.cmbStatus.SelectedIndex = 0;

            this.cmbStatus.SelectedIndexChanged +=
                new System.EventHandler(
                    this.cmbStatus_SelectedIndexChanged);

            // Refresh button
            this.btnRefresh.Location =
                new System.Drawing.Point(645, 35);

            this.btnRefresh.Size =
                new System.Drawing.Size(110, 34);

            this.btnRefresh.Text = "Refresh";

            this.btnRefresh.BackColor =
                System.Drawing.Color.FromArgb(92, 56, 37);

            this.btnRefresh.ForeColor =
                System.Drawing.Color.White;

            this.btnRefresh.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnRefresh.FlatAppearance.BorderSize = 0;

            this.btnRefresh.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9.5F,
                    System.Drawing.FontStyle.Bold);

            this.btnRefresh.Cursor =
                System.Windows.Forms.Cursors.Hand;

            this.btnRefresh.UseVisualStyleBackColor = false;

            this.btnRefresh.Click +=
                new System.EventHandler(this.btnRefresh_Click);

            // ==========================================
            // REQUEST TABLE PANEL
            // ==========================================

            this.pnlTable.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.pnlTable.BackColor =
                System.Drawing.Color.FromArgb(248, 241, 232);

            this.pnlTable.Padding =
                new System.Windows.Forms.Padding(25, 15, 25, 15);

            this.pnlTable.Controls.Add(this.dgvRequests);
            this.pnlTable.Controls.Add(this.lblCount);

            // Request count
            this.lblCount.Dock =
                System.Windows.Forms.DockStyle.Top;

            this.lblCount.Height = 35;

            this.lblCount.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            this.lblCount.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);

            this.lblCount.ForeColor =
                System.Drawing.Color.FromArgb(92, 56, 37);

            this.lblCount.Text =
                "Requests displayed: 0";

            // Data grid
            this.dgvRequests.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.dgvRequests.ReadOnly = true;

            this.dgvRequests.AllowUserToAddRows = false;
            this.dgvRequests.AllowUserToDeleteRows = false;
            this.dgvRequests.AllowUserToResizeRows = false;

            this.dgvRequests.MultiSelect = false;

            this.dgvRequests.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvRequests.AutoGenerateColumns = false;

            this.dgvRequests.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvRequests.RowHeadersVisible = false;

            this.dgvRequests.BackgroundColor =
                System.Drawing.Color.White;

            this.dgvRequests.BorderStyle =
                System.Windows.Forms.BorderStyle.None;

            this.dgvRequests.CellBorderStyle =
                System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;

            this.dgvRequests.GridColor =
                System.Drawing.Color.FromArgb(232, 217, 200);

            this.dgvRequests.EnableHeadersVisualStyles = false;

            this.dgvRequests.ColumnHeadersHeight = 42;

            this.dgvRequests.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            this.dgvRequests.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(92, 56, 37);

            this.dgvRequests.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;

            this.dgvRequests.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);

            this.dgvRequests.ColumnHeadersDefaultCellStyle.Alignment =
                System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;

            this.dgvRequests.DefaultCellStyle.BackColor =
                System.Drawing.Color.White;

            this.dgvRequests.DefaultCellStyle.ForeColor =
                System.Drawing.Color.FromArgb(72, 45, 30);

            this.dgvRequests.DefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9.5F);

            this.dgvRequests.DefaultCellStyle.SelectionBackColor =
                System.Drawing.Color.FromArgb(248, 214, 183);

            this.dgvRequests.DefaultCellStyle.SelectionForeColor =
                System.Drawing.Color.FromArgb(72, 45, 30);

            this.dgvRequests.AlternatingRowsDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(252, 246, 239);

            this.dgvRequests.RowTemplate.Height = 35;

            this.dgvRequests.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvRequests_CellClick);

            // ==========================================
            // FOOTER PANEL
            // ==========================================

            this.pnlFooter.Dock =
                System.Windows.Forms.DockStyle.Bottom;

            this.pnlFooter.Height = 55;

            this.pnlFooter.BackColor =
                System.Drawing.Color.FromArgb(92, 56, 37);

            this.pnlFooter.Padding =
                new System.Windows.Forms.Padding(25, 8, 20, 8);

            this.pnlFooter.Controls.Add(this.btnBack);

            // Back button
            this.btnBack.Location =
                new System.Drawing.Point(25, 8);

            this.btnBack.Size =
                new System.Drawing.Size(110, 35);

            this.btnBack.Text = "< Back to Menu";

            this.btnBack.BackColor =
                System.Drawing.Color.FromArgb(232, 177, 122);

            this.btnBack.ForeColor =
                System.Drawing.Color.FromArgb(72, 45, 30);

            this.btnBack.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnBack.FlatAppearance.BorderSize = 0;

            this.btnBack.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);

            this.btnBack.Cursor =
                System.Windows.Forms.Cursors.Hand;

            this.btnBack.UseVisualStyleBackColor = false;

            this.btnBack.Click +=
                new System.EventHandler(this.btnBack_Click);

            // ==========================================
            // REQUEST DETAILS GROUP
            // ==========================================

            this.grpDetails.Dock =
                System.Windows.Forms.DockStyle.Bottom;

            this.grpDetails.Height = 205;

            this.grpDetails.Text = "Request Details & Progress";

            this.grpDetails.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);

            this.grpDetails.ForeColor =
                System.Drawing.Color.FromArgb(92, 56, 37);

            this.grpDetails.BackColor =
                System.Drawing.Color.White;

            this.grpDetails.Padding =
                new System.Windows.Forms.Padding(12);

            this.grpDetails.Controls.Add(this.lblRequestId);
            this.grpDetails.Controls.Add(this.lblRequestStatus);
            this.grpDetails.Controls.Add(this.lblDescription);
            this.grpDetails.Controls.Add(this.lblLocation);
            this.grpDetails.Controls.Add(this.lblPriority);
            this.grpDetails.Controls.Add(this.lblHistoryTitle);
            this.grpDetails.Controls.Add(this.lstHistory);

            // Request ID
            this.lblRequestId.AutoSize = true;

            this.lblRequestId.Location =
                new System.Drawing.Point(20, 35);

            this.lblRequestId.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);

            this.lblRequestId.ForeColor =
                System.Drawing.Color.FromArgb(92, 56, 37);

            this.lblRequestId.Text = "Request ID: -";

            // Status
            this.lblRequestStatus.AutoSize = true;

            this.lblRequestStatus.Location =
                new System.Drawing.Point(20, 65);

            this.lblRequestStatus.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);

            this.lblRequestStatus.ForeColor =
                System.Drawing.Color.FromArgb(198, 93, 33);

            this.lblRequestStatus.Text = "Status: -";

            // Description
            this.lblDescription.Location =
                new System.Drawing.Point(20, 95);

            this.lblDescription.Size =
                new System.Drawing.Size(430, 45);

            this.lblDescription.Font =
                new System.Drawing.Font("Segoe UI", 9.5F);

            this.lblDescription.ForeColor =
                System.Drawing.Color.FromArgb(72, 45, 30);

            this.lblDescription.Text = "Description: -";

            // Location
            this.lblLocation.AutoSize = true;

            this.lblLocation.Location =
                new System.Drawing.Point(20, 150);

            this.lblLocation.Font =
                new System.Drawing.Font("Segoe UI", 9.5F);

            this.lblLocation.ForeColor =
                System.Drawing.Color.FromArgb(72, 45, 30);

            this.lblLocation.Text = "Location: -";

            // Priority
            this.lblPriority.AutoSize = true;

            this.lblPriority.Location =
                new System.Drawing.Point(270, 35);

            this.lblPriority.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);

            this.lblPriority.ForeColor =
                System.Drawing.Color.FromArgb(198, 93, 33);

            this.lblPriority.Text = "Priority: -";

            // Progress history heading
            this.lblHistoryTitle.AutoSize = true;

            this.lblHistoryTitle.Location =
                new System.Drawing.Point(500, 28);

            this.lblHistoryTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);

            this.lblHistoryTitle.ForeColor =
                System.Drawing.Color.FromArgb(92, 56, 37);

            this.lblHistoryTitle.Text = "Progress History";

            // Progress history list
            this.lstHistory.Location =
                new System.Drawing.Point(500, 53);

            this.lstHistory.Size =
                new System.Drawing.Size(600, 120);

            this.lstHistory.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            this.lstHistory.Font =
                new System.Drawing.Font("Segoe UI", 9F);

            this.lstHistory.BackColor =
                System.Drawing.Color.FromArgb(252, 246, 239);

            this.lstHistory.ForeColor =
                System.Drawing.Color.FromArgb(72, 45, 30);

            this.lstHistory.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.lstHistory.HorizontalScrollbar = true;

            // ==========================================
            // ADD PANELS TO FORM
            // ==========================================

            this.Controls.Add(this.pnlTable);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlHeader);

            // Maintain intended docking order
            this.pnlHeader.SendToBack();
            this.pnlSearch.BringToFront();
            this.pnlTable.BringToFront();
            this.grpDetails.BringToFront();
            this.pnlFooter.BringToFront();

            // ==========================================
            // FINISH INITIALIZATION
            // ==========================================

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();

            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();

            this.pnlTable.ResumeLayout(false);
            this.pnlTable.PerformLayout();

            this.pnlFooter.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvRequests)).EndInit();

            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();

            this.ResumeLayout(false);
        }

        #endregion
    }
}
