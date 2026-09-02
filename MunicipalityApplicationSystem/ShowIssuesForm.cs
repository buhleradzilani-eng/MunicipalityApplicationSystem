using ApplicationClassLibrary;


namespace MunicipalityApplicationSystem
{
    public partial class ShowIssuesForm : Form
    {
        public List<Issue> reports = new List<Issue>();

        public ShowIssuesForm()
        {
            InitializeComponent();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            // Clear existing display to prevent duplicate entries if clicked multiple times
            listBox1.Items.Clear();

            // Check if there are any reports to show
            if (reports == null || reports.Count == 0)
            {
                MessageBox.Show(
                    "No reported issues available to display.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            // Loop through each issue and format the details cleanly
            for (int i = 0; i < reports.Count; i++)
            {
                Issue issue = reports[i];

                listBox1.Items.Add($"=============== ISSUE #{i + 1} ===============");
                listBox1.Items.Add($"  Title       : {issue.Title}");
                listBox1.Items.Add($"  Category    : {issue.Category}");
                listBox1.Items.Add($"  Location    : {issue.Location}");
                listBox1.Items.Add($"  Description : {issue.Description}");
                listBox1.Items.Add($"  Attachment  : {(string.IsNullOrEmpty(issue.FilePath) ? "None" : Path.GetFileName(issue.FilePath))}");
                listBox1.Items.Add("==========================================");
                listBox1.Items.Add(""); // Blank line spacing between issues
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("The list is already empty.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            listBox1.Items.Clear();
            MessageBox.Show("List has been cleared.", "List Cleared Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}