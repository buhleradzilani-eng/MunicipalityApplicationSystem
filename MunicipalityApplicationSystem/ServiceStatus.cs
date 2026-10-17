
using System;
using System.Linq;
using System.Windows.Forms;
using ApplicationClassLibrary;

namespace MunicipalityApplicationSystem
{
    public partial class ServiceStatus : Form
    {
        private readonly ServiceRequestManager manager =
            new ServiceRequestManager();

        public ServiceStatus()
        {
            InitializeComponent();

            LoadSampleRequests();
            ConfigureGrid();
            RefreshRequests();
        }

        private void LoadSampleRequests()
        {
            manager.Add(new ServiceRequest(
                "SR-1001", "Thabo Mokoena", "Water",
                "Water leakage reported near the property.",
                "Pretoria Central", "In Progress", 1,
                DateTime.Now.AddDays(-5)));

            manager.Add(new ServiceRequest(
                "SR-1002", "Naledi Nkosi", "Electricity",
                "Streetlight is not functioning.",
                "Sunnyside", "Submitted", 2,
                DateTime.Now.AddDays(-3)));

            manager.Add(new ServiceRequest(
                "SR-1003", "Sipho Dlamini", "Roads",
                "Pothole reported on the main road.",
                "Hatfield", "Pending", 1,
                DateTime.Now.AddDays(-7)));

            manager.Add(new ServiceRequest(
                "SR-1004", "Lerato Molefe", "Waste",
                "Missed household refuse collection.",
                "Arcadia", "Completed", 3,
                DateTime.Now.AddDays(-10)));

            manager.Add(new ServiceRequest(
                "SR-1005", "Pieter Botha", "Electricity",
                "Damaged electrical infrastructure.",
                "Centurion", "In Progress", 1,
                DateTime.Now.AddDays(-2)));

            // Demonstrate relationships between service requests.
            manager.ConnectRequests("SR-1001", "SR-1003");
            manager.ConnectRequests("SR-1002", "SR-1005");
        }

        private void ConfigureGrid()
        {
            dgvRequests.AutoGenerateColumns = false;
            dgvRequests.Columns.Clear();

            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RequestId",
                HeaderText = "Request ID",
                DataPropertyName = "RequestId"
            });

            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Category",
                HeaderText = "Category",
                DataPropertyName = "Category"
            });

            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Location",
                HeaderText = "Location",
                DataPropertyName = "Location"
            });

            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Status",
                DataPropertyName = "Status"
            });

            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Priority",
                HeaderText = "Priority",
                DataPropertyName = "Priority"
            });

            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DateSubmitted",
                HeaderText = "Date Submitted",
                DataPropertyName = "DateSubmitted",
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd MMM yyyy"
                }
            });
        }

        private void RefreshRequests()
        {
            var filtered = manager.GetAll();

            string status = cmbStatus.SelectedItem?.ToString() ?? "All";

            if (status != "All")
            {
                filtered = filtered
                    .Where(r => string.Equals(
                        r.Status, status,
                        StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            dgvRequests.DataSource = null;
            dgvRequests.DataSource = filtered;

            lblCount.Text =
                $"Requests displayed: {filtered.Count}";

            ClearDetails();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string id = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show(
                    "Enter a service request ID.",
                    "Track Request",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            ServiceRequest request = manager.Find(id);

            if (request == null)
            {
                MessageBox.Show(
                    "No service request was found with ID: " + id,
                    "Request Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            cmbStatus.SelectedIndex = 0;

            dgvRequests.DataSource = null;
            dgvRequests.DataSource = new[]
            {
                request
            };

            lblCount.Text = "Matching requests: 1";
            DisplayDetails(request);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            RefreshRequests();
        }

        private void cmbStatus_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (manager != null && dgvRequests != null)
                RefreshRequests();
        }

        private void dgvRequests_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            ServiceRequest request =
                dgvRequests.Rows[e.RowIndex].DataBoundItem
                    as ServiceRequest;

            if (request != null)
                DisplayDetails(request);
        }

        private void DisplayDetails(ServiceRequest request)
        {
            lblRequestId.Text =
                "Request ID: " + request.RequestId;

            lblRequestStatus.Text =
                "Status: " + request.Status;

            lblDescription.Text =
                "Description: " + request.Description;

            lblLocation.Text =
                "Location: " + request.Location;

            lblPriority.Text =
                "Priority: " + PriorityText(request.Priority);

            lstHistory.Items.Clear();

            foreach (string item in request.ProgressHistory)
                lstHistory.Items.Add(item);

            if (lstHistory.Items.Count == 0)
                lstHistory.Items.Add("No progress history available.");
        }

        private string PriorityText(int priority)
        {
            switch (priority)
            {
                case 1: return "High";
                case 2: return "Medium";
                case 3: return "Low";
                default: return "Unspecified";
            }
        }

        private void ClearDetails()
        {
            lblRequestId.Text = "Request ID: -";
            lblRequestStatus.Text = "Status: -";
            lblDescription.Text = "Description: -";
            lblLocation.Text = "Location: -";
            lblPriority.Text = "Priority: -";
            lstHistory.Items.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
