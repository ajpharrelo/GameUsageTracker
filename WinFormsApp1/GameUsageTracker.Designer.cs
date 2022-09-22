namespace WinFormsApp1
{
    partial class GameUsageTracker
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        //#region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameUsageTracker));
            this.BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnAddGame = new System.Windows.Forms.Button();
            this.BtnFindExecutable = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtGameExec = new System.Windows.Forms.TextBox();
            this.TxtGameTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GameTitle = new System.Windows.Forms.ColumnHeader();
            this.GameExec = new System.Windows.Forms.ColumnHeader();
            this.GameStatus = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.listView2 = new System.Windows.Forms.ListView();
            this.Title = new System.Windows.Forms.ColumnHeader();
            this.Exec = new System.Windows.Forms.ColumnHeader();
            this.Runtime = new System.Windows.Forms.ColumnHeader();
            this.listViewMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.appMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.appMenuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.changeCheckFrequencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewOutputLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.lblFrequency = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.listViewMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BackgroundWorker
            // 
            this.BackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.BtnAddGame);
            this.groupBox1.Controls.Add(this.BtnFindExecutable);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtGameExec);
            this.groupBox1.Controls.Add(this.TxtGameTitle);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1056, 210);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Game to Track";
            // 
            // BtnAddGame
            // 
            this.BtnAddGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAddGame.Location = new System.Drawing.Point(6, 136);
            this.BtnAddGame.Name = "BtnAddGame";
            this.BtnAddGame.Size = new System.Drawing.Size(1044, 68);
            this.BtnAddGame.TabIndex = 2;
            this.BtnAddGame.Text = "Add Game";
            this.BtnAddGame.UseVisualStyleBackColor = true;
            this.BtnAddGame.Click += new System.EventHandler(this.BtnAddGame_Click);
            // 
            // BtnFindExecutable
            // 
            this.BtnFindExecutable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnFindExecutable.Location = new System.Drawing.Point(877, 103);
            this.BtnFindExecutable.Name = "BtnFindExecutable";
            this.BtnFindExecutable.Size = new System.Drawing.Size(173, 27);
            this.BtnFindExecutable.TabIndex = 2;
            this.BtnFindExecutable.Text = "Locate Executable";
            this.BtnFindExecutable.UseVisualStyleBackColor = true;
            this.BtnFindExecutable.Click += new System.EventHandler(this.BtnFindExecutable_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Executable Location";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Game Title";
            // 
            // TxtGameExec
            // 
            this.TxtGameExec.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtGameExec.Location = new System.Drawing.Point(6, 103);
            this.TxtGameExec.Name = "TxtGameExec";
            this.TxtGameExec.ReadOnly = true;
            this.TxtGameExec.Size = new System.Drawing.Size(865, 27);
            this.TxtGameExec.TabIndex = 0;
            // 
            // TxtGameTitle
            // 
            this.TxtGameTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtGameTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtGameTitle.Location = new System.Drawing.Point(6, 46);
            this.TxtGameTitle.Name = "TxtGameTitle";
            this.TxtGameTitle.Size = new System.Drawing.Size(1050, 27);
            this.TxtGameTitle.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Game Watchlist";
            // 
            // GameTitle
            // 
            this.GameTitle.Text = "Game Title";
            // 
            // GameExec
            // 
            this.GameExec.Text = "Game Executable";
            // 
            // GameStatus
            // 
            this.GameStatus.Text = "Status";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Game Title";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Game Executable Path";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Game Status";
            // 
            // listView2
            // 
            this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.Exec,
            this.Runtime});
            this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView2.Location = new System.Drawing.Point(18, 243);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(1048, 352);
            this.listView2.TabIndex = 2;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // Title
            // 
            this.Title.Text = "Title";
            // 
            // Exec
            // 
            this.Exec.Text = "Executable";
            // 
            // Runtime
            // 
            this.Runtime.Text = "Total Runtime";
            // 
            // listViewMenu
            // 
            this.listViewMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeGameToolStripMenuItem});
            this.listViewMenu.Name = "contextMenuStrip1";
            this.listViewMenu.Size = new System.Drawing.Size(151, 26);
            // 
            // removeGameToolStripMenuItem
            // 
            this.removeGameToolStripMenuItem.Name = "removeGameToolStripMenuItem";
            this.removeGameToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.removeGameToolStripMenuItem.Text = "Remove game";
            this.removeGameToolStripMenuItem.Click += new System.EventHandler(this.removeGameToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appMenu,
            this.lblFrequency});
            this.statusStrip1.Location = new System.Drawing.Point(0, 608);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1080, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // appMenu
            // 
            this.appMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.appMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appMenuSettings,
            this.viewOutputLogs});
            this.appMenu.Image = ((System.Drawing.Image)(resources.GetObject("appMenu.Image")));
            this.appMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.appMenu.Name = "appMenu";
            this.appMenu.Size = new System.Drawing.Size(51, 20);
            this.appMenu.Text = "Menu";
            // 
            // appMenuSettings
            // 
            this.appMenuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeCheckFrequencyToolStripMenuItem});
            this.appMenuSettings.Name = "appMenuSettings";
            this.appMenuSettings.Size = new System.Drawing.Size(180, 22);
            this.appMenuSettings.Text = "Settings";
            // 
            // changeCheckFrequencyToolStripMenuItem
            // 
            this.changeCheckFrequencyToolStripMenuItem.Name = "changeCheckFrequencyToolStripMenuItem";
            this.changeCheckFrequencyToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.changeCheckFrequencyToolStripMenuItem.Text = "Change check frequency";
            this.changeCheckFrequencyToolStripMenuItem.Click += new System.EventHandler(this.changeCheckFrequencyToolStripMenuItem_Click);
            // 
            // viewOutputLogs
            // 
            this.viewOutputLogs.Name = "viewOutputLogs";
            this.viewOutputLogs.Size = new System.Drawing.Size(180, 22);
            this.viewOutputLogs.Text = "Output logs";
            // 
            // lblFrequency
            // 
            this.lblFrequency.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(114, 17);
            this.lblFrequency.Text = "Refresh frequency: 1";
            // 
            // GameUsageTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 630);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Name = "GameUsageTracker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Usage Tracker";
            this.Load += new System.EventHandler(this.GameUsageTracker_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.listViewMenu.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        private System.ComponentModel.BackgroundWorker BackgroundWorker;
        private GroupBox groupBox1;
        private TextBox TxtGameTitle;
        private Button BtnFindExecutable;
        private Label label2;
        private Label label1;
        private TextBox TxtGameExec;
        private Button BtnAddGame;
        private Label label3;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader GameTitle;
        private ColumnHeader GameExec;
        private ColumnHeader GameStatus;
        private ListView listView2;
        private ColumnHeader Title;
        private ColumnHeader Exec;
        private ColumnHeader Runtime;
        private ContextMenuStrip listViewMenu;
        private ToolStripMenuItem removeGameToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripDropDownButton appMenu;
        private ToolStripMenuItem appMenuSettings;
        private ToolStripMenuItem changeCheckFrequencyToolStripMenuItem;
        private ToolStripMenuItem viewOutputLogs;
        private ToolStripStatusLabel lblFrequency;
    }
}