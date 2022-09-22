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
            this.SuspendLayout();
            // 
            // outputList
            // 
            this.outputList.FormattingEnabled = true;
            this.outputList.ItemHeight = 15;
            this.outputList.Location = new System.Drawing.Point(12, 13);
            this.outputList.Name = "outputList";
            this.outputList.Size = new System.Drawing.Size(659, 319);
            this.outputList.TabIndex = 0;
            // 
            // OutputLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 344);
            this.Controls.Add(this.outputList);
            this.Name = "OutputLog";
            this.Text = "Output Log";
            this.Load += new System.EventHandler(this.OutputLog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox outputList;
    }
}