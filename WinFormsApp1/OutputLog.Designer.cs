namespace GameUsageTracker
{
    partial class OutputLog
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
            this.outputList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // outputList
            // 
            this.outputList.FormattingEnabled = true;
            this.outputList.ItemHeight = 15;
            this.outputList.Location = new System.Drawing.Point(12, 28);
            this.outputList.Name = "outputList";
            this.outputList.Size = new System.Drawing.Size(659, 304);
            this.outputList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Output Log";
            // 
            // OutputLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 344);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputList);
            this.Name = "OutputLog";
            this.Text = "Output Log";
            this.Load += new System.EventHandler(this.OutputLog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox outputList;
        private Label label1;
    }
}