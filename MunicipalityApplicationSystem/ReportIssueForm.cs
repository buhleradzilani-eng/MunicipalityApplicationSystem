using ApplicationClassLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MunicipalityApplicationSystem
{
    public partial class ReportIssueForm : Form
    {
        public string currentFilePath = string.Empty;
        public List<Issue> issues = new List<Issue>();

        // Gamification tracking variables
        private int totalXP = 0;
        private int totalIssuesReported = 0;

        public ReportIssueForm()
        {
            InitializeComponent();
            UpdateGamificationUI();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Validate Input Fields
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a title for the issue.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please specify the location of the issue.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Focus();
                return;
            }

            if (comboCategory.SelectedIndex == -1 || string.IsNullOrWhiteSpace(comboCategory.Text))
            {
                MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboCategory.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(rtxDescription.Text))
            {
                MessageBox.Show("Please provide a description of the issue.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtxDescription.Focus();
                return;
            }

            // 2. Create and Add New Issue
            Issue newIssue = new Issue
            {
                Title = txtTitle.Text.Trim(),
                Location = txtLocation.Text.Trim(),
                Category = comboCategory.Text,
                Description = rtxDescription.Text.Trim(),
                FilePath = currentFilePath
            };

            issues.Add(newIssue);

            // 3. Award Gamification Points (XP)
            int xpEarned = CalculateXP(newIssue);
            totalXP += xpEarned;
            totalIssuesReported++;

            // 4. Update UI & Feedback
            UpdateGamificationUI();

            MessageBox.Show(
                $"Issue submitted successfully!\n\n" +
                $"🏆 Gamification Reward:\n" +
                $" +{xpEarned} XP Earned!\n" +
                $" Total XP: {totalXP}",
                "Report Submitted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // 5. Reset fields for next report
            ClearForm();
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "Supported Files|*.doc;*.docx;*.pdf;*.txt;*.jpg;*.jpeg;*.png|" +
                                  "Documents (*.doc;*.docx;*.pdf;*.txt)|*.doc;*.docx;*.pdf;*.txt|" +
                                  "Images (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = openFile.FileName;
                    labelFileName.Text = Path.GetFileName(currentFilePath);

                    string extension = Path.GetExtension(currentFilePath).ToLower();

                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                    {
                        pictureBox1.Image = Image.FromFile(currentFilePath);
                    }
                    else
                    {
                        pictureBox1.Image = null;
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearForm()
        {
            txtTitle.Clear();
            txtLocation.Clear();
            rtxDescription.Clear();
            comboCategory.SelectedIndex = -1;
            labelFileName.Text = "No file selected";
            currentFilePath = string.Empty;

            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
        }

        #region Gamification System Logic

        private int CalculateXP(Issue issue)
        {
            int baseXP = 50; // Base points for reporting an issue

            // Bonus points for attached evidence (images/documents)
            if (!string.IsNullOrEmpty(issue.FilePath))
            {
                baseXP += 25;
            }

            // Bonus points for detailed descriptions (> 50 chars)
            if (issue.Description.Length > 50)
            {
                baseXP += 15;
            }

            return baseXP;
        }

        private void UpdateGamificationUI()
        {
            int currentLevel = (totalXP / 100) + 1;
            int progressToNextLevel = totalXP % 100;

         
        }
       

        #endregion

        private void btnShowIssues_Click(object sender, EventArgs e)
        {
            ShowIssuesForm showIssuesForm = new ShowIssuesForm();
            showIssuesForm.reports = issues;
            showIssuesForm.Show();
        }
    }
}