namespace GameUsageTracker
{
    partial class SessionViewer
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
            this.sessionGridView = new System.Windows.Forms.DataGridView();
            this.SessionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExitTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalRuntime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sessionGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // sessionGridView
            // 
            this.sessionGridView.AllowUserToAddRows = false;
            this.sessionGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sessionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sessionGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SessionDate,
            this.StartTime,
            this.ExitTime,
            this.TotalRuntime});
            this.sessionGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sessionGridView.Location = new System.Drawing.Point(0, 0);
            this.sessionGridView.Name = "sessionGridView";
            this.sessionGridView.RowHeadersVisible = false;
            this.sessionGridView.Size = new System.Drawing.Size(1125, 354);
            this.sessionGridView.TabIndex = 0;
            // 
            // SessionDate
            // 
            this.SessionDate.HeaderText = "Date";
            this.SessionDate.Name = "SessionDate";
            this.SessionDate.ReadOnly = true;
            // 
            // StartTime
            // 
            this.StartTime.HeaderText = "Start time";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            // 
            // ExitTime
            // 
            this.ExitTime.HeaderText = "Exit time";
            this.ExitTime.Name = "ExitTime";
            this.ExitTime.ReadOnly = true;
            // 
            // TotalRuntime
            // 
            this.TotalRuntime.HeaderText = "Total Runtime";
            this.TotalRuntime.Name = "TotalRuntime";
            this.TotalRuntime.ReadOnly = true;
            // 
            // SessionViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 354);
            this.Controls.Add(this.sessionGridView);
            this.Name = "SessionViewer";
            this.Text = "Session Viewer";
            this.Load += new System.EventHandler(this.SessionViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sessionGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView sessionGridView;
        private DataGridViewTextBoxColumn StartTime;
        private DataGridViewTextBoxColumn ExitTime;
        private DataGridViewTextBoxColumn TotalRuntime;
        private DataGridViewTextBoxColumn SessionDate;
    }
}