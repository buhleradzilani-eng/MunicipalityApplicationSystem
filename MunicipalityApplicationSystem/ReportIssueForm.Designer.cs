namespace MunicipalityApplicationSystem
{
    partial class ReportIssueForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtTitle = new TextBox();
            txtLocation = new TextBox();
            label4 = new Label();
            comboCategory = new ComboBox();
            label5 = new Label();
            rtxDescription = new RichTextBox();
            label6 = new Label();
            pictureBox1 = new PictureBox();
            label7 = new Label();
            labelFileName = new Label();
            btnChooseFile = new Button();
            btnSave = new Button();
            btnClear = new Button();
            btnExit = new Button();
            btnShowIssues = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Book Antiqua", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(298, 27);
            label1.Name = "label1";
            label1.Size = new Size(420, 56);
            label1.TabIndex = 0;
            label1.Text = "Issue Report Form";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(346, 103);
            label2.Name = "label2";
            label2.Size = new Size(349, 25);
            label2.TabIndex = 1;
            label2.Text = "Fill in the following form to report an issue";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(77, 184);
            label3.Name = "label3";
            label3.Size = new Size(48, 25);
            label3.TabIndex = 2;
            label3.Text = "Title:";
            // 
            // txtTitle
            // 
            txtTitle.BackColor = Color.Cornsilk;
            txtTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTitle.Location = new Point(77, 212);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(252, 31);
            txtTitle.TabIndex = 3;
            // 
            // txtLocation
            // 
            txtLocation.BackColor = Color.Cornsilk;
            txtLocation.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLocation.Location = new Point(77, 296);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(252, 31);
            txtLocation.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(77, 268);
            label4.Name = "label4";
            label4.Size = new Size(83, 25);
            label4.TabIndex = 4;
            label4.Text = "Location:";
            // 
            // comboCategory
            // 
            comboCategory.BackColor = Color.Cornsilk;
            comboCategory.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboCategory.FormattingEnabled = true;
            comboCategory.Items.AddRange(new object[] { "Sanitation", "Roads", "Electricity" });
            comboCategory.Location = new Point(77, 374);
            comboCategory.Name = "comboCategory";
            comboCategory.Size = new Size(252, 33);
            comboCategory.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(77, 346);
            label5.Name = "label5";
            label5.Size = new Size(88, 25);
            label5.TabIndex = 7;
            label5.Text = "Category:";
            // 
            // rtxDescription
            // 
            rtxDescription.BackColor = Color.Cornsilk;
            rtxDescription.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtxDescription.Location = new Point(405, 212);
            rtxDescription.Name = "rtxDescription";
            rtxDescription.Size = new Size(252, 195);
            rtxDescription.TabIndex = 8;
            rtxDescription.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(405, 175);
            label6.Name = "label6";
            label6.Size = new Size(106, 25);
            label6.TabIndex = 9;
            label6.Text = "Description:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.inbox;
            pictureBox1.Location = new Point(740, 212);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(207, 195);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(740, 410);
            label7.Name = "label7";
            label7.Size = new Size(42, 25);
            label7.TabIndex = 11;
            label7.Text = "File:";
            // 
            // labelFileName
            // 
            labelFileName.AutoSize = true;
            labelFileName.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFileName.Location = new Point(788, 410);
            labelFileName.Name = "labelFileName";
            labelFileName.Size = new Size(138, 25);
            labelFileName.TabIndex = 12;
            labelFileName.Text = "No File Selected";
            // 
            // btnChooseFile
            // 
            btnChooseFile.BackColor = Color.DarkOrange;
            btnChooseFile.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnChooseFile.Location = new Point(777, 452);
            btnChooseFile.Name = "btnChooseFile";
            btnChooseFile.Size = new Size(138, 42);
            btnChooseFile.TabIndex = 13;
            btnChooseFile.Text = "Choose File";
            btnChooseFile.UseVisualStyleBackColor = false;
            btnChooseFile.Click += btnChooseFile_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.DarkOrange;
            btnSave.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(214, 452);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(138, 42);
            btnSave.TabIndex = 14;
            btnSave.Text = "Save Details";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Bisque;
            btnClear.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(376, 452);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(138, 42);
            btnClear.TabIndex = 15;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.OrangeRed;
            btnExit.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.ForeColor = SystemColors.ButtonHighlight;
            btnExit.Location = new Point(894, 592);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(138, 42);
            btnExit.TabIndex = 16;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnShowIssues
            // 
            btnShowIssues.BackColor = Color.DarkOrange;
            btnShowIssues.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnShowIssues.Location = new Point(698, 590);
            btnShowIssues.Name = "btnShowIssues";
            btnShowIssues.Size = new Size(180, 42);
            btnShowIssues.TabIndex = 17;
            btnShowIssues.Text = "Show Issue Reports";
            btnShowIssues.UseVisualStyleBackColor = false;
            btnShowIssues.Click += btnShowIssues_Click;
            // 
            // ReportIssueForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Moccasin;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1044, 644);
            Controls.Add(btnShowIssues);
            Controls.Add(btnExit);
            Controls.Add(btnClear);
            Controls.Add(btnSave);
            Controls.Add(btnChooseFile);
            Controls.Add(labelFileName);
            Controls.Add(label7);
            Controls.Add(pictureBox1);
            Controls.Add(label6);
            Controls.Add(rtxDescription);
            Controls.Add(label5);
            Controls.Add(comboCategory);
            Controls.Add(txtLocation);
            Controls.Add(label4);
            Controls.Add(txtTitle);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ReportIssueForm";
            Text = "d";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtTitle;
        private TextBox txtLocation;
        private Label label4;
        private ComboBox comboCategory;
        private Label label5;
        private RichTextBox rtxDescription;
        private Label label6;
        private PictureBox pictureBox1;
        private Label label7;
        private Label labelFileName;
        private Button btnChooseFile;
        private Button btnSave;
        private Button btnClear;
        private Button btnExit;
        private Button btnShowIssues;
    }
}