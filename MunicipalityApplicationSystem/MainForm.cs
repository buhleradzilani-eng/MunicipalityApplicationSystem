namespace MunicipalityApplicationSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnIssueReport_Click(object sender, EventArgs e)
        {
            ReportIssueForm reportIssueForm = new ReportIssueForm();
            reportIssueForm.Show();
        }

        private void btnAnnouncement_Click(object sender, EventArgs e)
        {
            AnnouncementForm announcementForm = new AnnouncementForm();
            announcementForm.Show();
        }

        private void btnReqeustService_Click(object sender, EventArgs e)
        {
            ServiceStatus serviceRequestForm = new ServiceStatus();
            serviceRequestForm.ShowDialog();
        }
    }
}
