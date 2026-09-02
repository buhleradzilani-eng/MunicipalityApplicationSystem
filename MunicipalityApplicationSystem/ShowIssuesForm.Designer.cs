namespace MunicipalityApplicationSystem
{
    partial class ShowIssuesForm
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
            btnDisplay = new Button();
            btnClear = new Button();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Book Antiqua", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(207, 42);
            label1.Name = "label1";
            label1.Size = new Size(642, 56);
            label1.TabIndex = 0;
            label1.Text = "Reported Community Issues";
            // 
            // btnDisplay
            // 
            btnDisplay.Location = new Point(60, 133);
            btnDisplay.Name = "btnDisplay";
            btnDisplay.Size = new Size(208, 46);
            btnDisplay.TabIndex = 1;
            btnDisplay.Text = "Display Reported Issues";
            btnDisplay.UseVisualStyleBackColor = true;
            btnDisplay.Click += btnDisplay_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(311, 133);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(208, 46);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear List";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(60, 194);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(922, 444);
            listBox1.TabIndex = 3;
            // 
            // ShowIssuesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Moccasin;
            ClientSize = new Size(1021, 671);
            Controls.Add(listBox1);
            Controls.Add(btnClear);
            Controls.Add(btnDisplay);
            Controls.Add(label1);
            Name = "ShowIssuesForm";
            Text = "Clear List";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnDisplay;
        private Button btnClear;
        private ListBox listBox1;
    }
}