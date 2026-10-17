
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalityApplicationSystem
{
    partial class AnnouncementDetails
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Panel pnlBody;
        private Panel pnlFooter;
        private Panel pnlTitleIcon;
        private Panel pnlDateCard;
        private Panel pnlTimeCard;
        private Panel pnlLocationCard;
        private Panel pnlDescription;
        private TableLayoutPanel tblInfo;

        private Label lblHeaderIcon;
        private Label lblPageHeading;
        private Label lblSubtitle;
        private Label lblTitle;
        private Label lblCategory;
        private Label lblDateIcon;
        private Label lblDateCaption;
        private Label lblDate;
        private Label lblTimeIcon;
        private Label lblTimeCaption;
        private Label lblTime;
        private Label lblLocationIcon;
        private Label lblLocationCaption;
        private Label lblLocation;
        private Label lblDescriptionHeading;

        private TextBox txtDescription;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            pnlHeader = new Panel();
            pnlTitleIcon = new Panel();
            lblHeaderIcon = new Label();
            lblPageHeading = new Label();
            lblSubtitle = new Label();

            pnlBody = new Panel();
            lblTitle = new Label();
            lblCategory = new Label();

            tblInfo = new TableLayoutPanel();

            pnlDateCard = new Panel();
            lblDateIcon = new Label();
            lblDateCaption = new Label();
            lblDate = new Label();

            pnlTimeCard = new Panel();
            lblTimeIcon = new Label();
            lblTimeCaption = new Label();
            lblTime = new Label();

            pnlLocationCard = new Panel();
            lblLocationIcon = new Label();
            lblLocationCaption = new Label();
            lblLocation = new Label();

            pnlDescription = new Panel();
            lblDescriptionHeading = new Label();
            txtDescription = new TextBox();

            pnlFooter = new Panel();
            btnClose = new Button();

            SuspendLayout();

            // FORM
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 246, 243);
            ClientSize = new Size(900, 690);
            MinimumSize = new Size(720, 580);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Announcement Details";
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = false;

            // HEADER
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 120;
            pnlHeader.BackColor = Color.FromArgb(91, 57, 38);
            pnlHeader.Padding = new Padding(26, 18, 24, 18);

            pnlTitleIcon.Location = new Point(26, 26);
            pnlTitleIcon.Size = new Size(58, 58);
            pnlTitleIcon.BackColor = Color.FromArgb(113, 72, 45);

            lblHeaderIcon.Text = "▤";
            lblHeaderIcon.Font = new Font("Segoe UI Symbol", 25F, FontStyle.Bold);
            lblHeaderIcon.ForeColor = Color.FromArgb(255, 180, 105);
            lblHeaderIcon.Dock = DockStyle.Fill;
            lblHeaderIcon.TextAlign = ContentAlignment.MiddleCenter;
            pnlTitleIcon.Controls.Add(lblHeaderIcon);

            lblPageHeading.Text = "Announcement Details";
            lblPageHeading.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
            lblPageHeading.ForeColor = Color.White;
            lblPageHeading.Location = new Point(102, 25);
            lblPageHeading.Size = new Size(620, 38);
            lblPageHeading.Anchor = AnchorStyles.Top | AnchorStyles.Left |
                                    AnchorStyles.Right;

            lblSubtitle.Text = "Everything you need to know about this event.";
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.FromArgb(235, 220, 207);
            lblSubtitle.Location = new Point(105, 66);
            lblSubtitle.Size = new Size(620, 24);
            lblSubtitle.Anchor = AnchorStyles.Top | AnchorStyles.Left |
                                 AnchorStyles.Right;

            pnlHeader.Controls.Add(pnlTitleIcon);
            pnlHeader.Controls.Add(lblPageHeading);
            pnlHeader.Controls.Add(lblSubtitle);

            // MAIN BODY
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Padding = new Padding(28, 22, 28, 18);
            pnlBody.BackColor = Color.FromArgb(248, 246, 243);

            lblTitle.Text = "Announcement title";
            lblTitle.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(64, 45, 33);
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 65;
            lblTitle.AutoEllipsis = true;
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            lblCategory.Text = "●  COMMUNITY EVENT";
            lblCategory.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCategory.ForeColor = Color.FromArgb(164, 88, 42);
            lblCategory.BackColor = Color.FromArgb(250, 232, 215);
            lblCategory.Dock = DockStyle.Top;
            lblCategory.Height = 34;
            lblCategory.Padding = new Padding(10, 7, 8, 5);
            lblCategory.Margin = new Padding(0, 0, 0, 14);

            // INFORMATION CARDS
            tblInfo.Dock = DockStyle.Top;
            tblInfo.Height = 116;
            tblInfo.ColumnCount = 3;
            tblInfo.RowCount = 1;
            tblInfo.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 34F));
            tblInfo.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 27F));
            tblInfo.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 39F));
            tblInfo.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));
            tblInfo.BackColor = pnlBody.BackColor;
            tblInfo.Padding = new Padding(0, 8, 0, 8);

            // DATE CARD
            ConfigureInfoCard(pnlDateCard);

            lblDateIcon.Text = "▦";
            ConfigureInfoIcon(lblDateIcon);

            lblDateCaption.Text = "EVENT DATE";
            ConfigureInfoCaption(lblDateCaption);

            lblDate.Text = "Date not available";
            ConfigureInfoValue(lblDate, 12F);

            pnlDateCard.Controls.Add(lblDate);
            pnlDateCard.Controls.Add(lblDateCaption);
            pnlDateCard.Controls.Add(lblDateIcon);

            // TIME CARD
            ConfigureInfoCard(pnlTimeCard);

            lblTimeIcon.Text = "◷";
            ConfigureInfoIcon(lblTimeIcon);

            lblTimeCaption.Text = "START TIME";
            ConfigureInfoCaption(lblTimeCaption);

            lblTime.Text = "--:--";
            ConfigureInfoValue(lblTime, 13F);

            pnlTimeCard.Controls.Add(lblTime);
            pnlTimeCard.Controls.Add(lblTimeCaption);
            pnlTimeCard.Controls.Add(lblTimeIcon);

            // LOCATION CARD
            ConfigureInfoCard(pnlLocationCard);

            lblLocationIcon.Text = "⌖";
            ConfigureInfoIcon(lblLocationIcon);

            lblLocationCaption.Text = "LOCATION";
            ConfigureInfoCaption(lblLocationCaption);

            lblLocation.Text = "Location not available";
            ConfigureInfoValue(lblLocation, 10.5F);
            lblLocation.AutoEllipsis = true;

            pnlLocationCard.Controls.Add(lblLocation);
            pnlLocationCard.Controls.Add(lblLocationCaption);
            pnlLocationCard.Controls.Add(lblLocationIcon);

            tblInfo.Controls.Add(pnlDateCard, 0, 0);
            tblInfo.Controls.Add(pnlTimeCard, 1, 0);
            tblInfo.Controls.Add(pnlLocationCard, 2, 0);

            // DESCRIPTION PANEL
            pnlDescription.Dock = DockStyle.Fill;
            pnlDescription.BackColor = Color.White;
            pnlDescription.Padding = new Padding(18, 14, 18, 14);
            pnlDescription.Margin = new Padding(0, 12, 0, 0);

            lblDescriptionHeading.Text = "☰   ABOUT THIS ANNOUNCEMENT";
            lblDescriptionHeading.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDescriptionHeading.ForeColor =
                Color.FromArgb(91, 57, 38);
            lblDescriptionHeading.Dock = DockStyle.Top;
            lblDescriptionHeading.Height = 34;
            lblDescriptionHeading.TextAlign =
                ContentAlignment.MiddleLeft;

            txtDescription.Multiline = true;
            txtDescription.ReadOnly = true;
            txtDescription.BorderStyle = BorderStyle.None;
            txtDescription.BackColor = Color.White;
            txtDescription.ForeColor = Color.FromArgb(79, 76, 72);
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Dock = DockStyle.Fill;
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.WordWrap = true;
            txtDescription.TabStop = false;
            txtDescription.Text = "Announcement description";

            pnlDescription.Controls.Add(txtDescription);
            pnlDescription.Controls.Add(lblDescriptionHeading);

            // ADD BODY CONTROLS IN DOCKING ORDER
            pnlBody.Controls.Add(pnlDescription);
            pnlBody.Controls.Add(tblInfo);
            pnlBody.Controls.Add(lblCategory);
            pnlBody.Controls.Add(lblTitle);

            // FOOTER
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Height = 76;
            pnlFooter.BackColor = Color.White;
            pnlFooter.Padding = new Padding(24, 14, 28, 14);

            btnClose.Text = "✕   Close";
            btnClose.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnClose.BackColor = Color.FromArgb(104, 67, 44);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Size = new Size(125, 42);
            btnClose.Dock = DockStyle.Right;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Click += btnClose_Click;
            btnClose.DialogResult = DialogResult.Cancel;

            pnlFooter.Controls.Add(btnClose);

            CancelButton = btnClose;

            // ADD DOCKED PANELS
            Controls.Add(pnlBody);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);

            ResumeLayout(false);
        }

        private void ConfigureInfoCard(Panel panel)
        {
            panel.Dock = DockStyle.Fill;
            panel.Margin = new Padding(0, 0, 8, 0);
            panel.Padding = new Padding(10, 8, 8, 8);
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;
        }

        private void ConfigureInfoIcon(Label label)
        {
            label.Font = new Font("Segoe UI Symbol", 17F, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(190, 105, 54);
            label.Location = new Point(10, 9);
            label.Size = new Size(32, 32);
            label.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void ConfigureInfoCaption(Label label)
        {
            label.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(133, 119, 107);
            label.Location = new Point(48, 10);
            label.Size = new Size(130, 20);
            label.AutoEllipsis = true;
        }

        private void ConfigureInfoValue(Label label, float fontSize)
        {
            label.Font = new Font("Segoe UI", fontSize, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(64, 45, 33);
            label.Location = new Point(48, 34);
            label.Size = new Size(180, 45);
            label.AutoEllipsis = true;
        }
    }
}
