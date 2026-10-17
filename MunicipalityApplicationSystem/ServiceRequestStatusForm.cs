using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Windows.Forms;

namespace MunicipalityApplicationSystem
{
    public partial class ServiceRequestStatusForm : Form
    {
        private readonly List<ServiceRequestRow> requests = new List<ServiceRequestRow>
        {
            new ServiceRequestRow { RequestNumber = "SR-1001", Service = "Water leak", Submitted = DateTime.Today.AddDays(-4), Status = "In Progress", Ward = "Ward 2" },
            new ServiceRequestRow { RequestNumber = "SR-1002", Service = "Pothole repair", Submitted = DateTime.Today.AddDays(-2), Status = "Pending", Ward = "Ward 5" },
            new ServiceRequestRow { RequestNumber = "SR-1003", Service = "Streetlight fault", Submitted = DateTime.Today.AddDays(-8), Status = "Completed", Ward = "Ward 1" },
            new ServiceRequestRow { RequestNumber = "SR-1004", Service = "Waste collection", Submitted = DateTime.Today.AddDays(-1), Status = "Pending", Ward = "Ward 3" }
        };

        public ServiceRequestStatusForm()
        {
            InitializeComponent();
            MunicipalityTheme.StyleForm(this);
            MunicipalityTheme.StyleButton(btnTrack, true);
            MunicipalityTheme.StyleButton(btnShowAll, false);
            MunicipalityTheme.StyleInput(txtRequestId);

            pnlHeader.BackColor = MunicipalityTheme.DarkBrown;

            dgvRequests.EnableHeadersVisualStyles = false;
            dgvRequests.ColumnHeadersDefaultCellStyle.BackColor = MunicipalityTheme.Orange;
            dgvRequests.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvRequests.ColumnHeadersDefaultCellStyle.Font = MunicipalityTheme.MakeFont(9.5f, System.Drawing.FontStyle.Bold);
            dgvRequests.DefaultCellStyle.Font = MunicipalityTheme.MakeFont(9.5f);
            dgvRequests.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 226, 204);
            dgvRequests.DefaultCellStyle.SelectionForeColor = MunicipalityTheme.DarkBrown;
            dgvRequests.GridColor = MunicipalityTheme.Border;
            dgvRequests.RowHeadersVisible = false;

            ShowRequests(requests);
        }

        private void btnTrack_Click(object sender, EventArgs e)
        {
            string query = txtRequestId.Text.Trim();

            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Enter a request number to track.", "Request number required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRequestId.Focus();
                return;
            }

            var found = requests.Where(r =>
                r.RequestNumber.Equals(query, StringComparison.OrdinalIgnoreCase)).ToList();

            ShowRequests(found);

            if (found.Count == 0)
                MessageBox.Show("No matching request was found in the sample data.",
                    "No request found", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtRequestId.Clear();
            ShowRequests(requests);
        }

        private void ShowRequests(List<ServiceRequestRow> rows)
        {
            dgvRequests.DataSource = null;
            dgvRequests.DataSource = rows.Select(r => new
            {
                r.RequestNumber,
                r.Service,
                SubmittedDate = r.Submitted.ToString("dd MMM yyyy"),
                r.Status,
                r.Ward
            }).ToList();

            if (dgvRequests.Columns["RequestNumber"] != null)
                dgvRequests.Columns["RequestNumber"].HeaderText = "Request Number";
            if (dgvRequests.Columns["SubmittedDate"] != null)
                dgvRequests.Columns["SubmittedDate"].HeaderText = "Submitted";
        }

        private sealed class ServiceRequestRow
        {
            public string RequestNumber { get; set; }
            public string Service { get; set; }
            public DateTime Submitted { get; set; }
            public string Status { get; set; }
            public string Ward { get; set; }
        }
    }
}
