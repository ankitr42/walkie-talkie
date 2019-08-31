namespace WalkieTalkie
{
    partial class wndMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wndMain));
            this.lstUsersOnline = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rTxtChatRoomText = new System.Windows.Forms.RichTextBox();
            this.rTxtUserText = new System.Windows.Forms.RichTextBox();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.saveChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBtnFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBtnAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblScanning = new System.Windows.Forms.Label();
            this.bgWUserFinder = new System.ComponentModel.BackgroundWorker();
            this.bgWDataCollector = new System.ComponentModel.BackgroundWorker();
            this.bgWDataSender = new System.ComponentModel.BackgroundWorker();
            this.dlgFontSelector = new System.Windows.Forms.FontDialog();
            this.btnFont = new System.Windows.Forms.Button();
            this.dlgColorPicker = new System.Windows.Forms.ColorDialog();
            this.btnColor = new System.Windows.Forms.Button();
            this.bgWUpdater = new System.ComponentModel.BackgroundWorker();
            this.sysTrayNotifier = new System.Windows.Forms.NotifyIcon(this.components);
            this.sysTrayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sysTrayMnuBtnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRefreshUserList = new System.Windows.Forms.Button();
            this.dlgSaveRtf = new System.Windows.Forms.SaveFileDialog();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtStatusMessage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mnuMain.SuspendLayout();
            this.sysTrayContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstUsersOnline
            // 
            this.lstUsersOnline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstUsersOnline.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstUsersOnline.FormattingEnabled = true;
            this.lstUsersOnline.IntegralHeight = false;
            this.lstUsersOnline.ItemHeight = 21;
            this.lstUsersOnline.Location = new System.Drawing.Point(505, 93);
            this.lstUsersOnline.Name = "lstUsersOnline";
            this.lstUsersOnline.Size = new System.Drawing.Size(264, 356);
            this.lstUsersOnline.Sorted = true;
            this.lstUsersOnline.TabIndex = 9;
            this.lstUsersOnline.DoubleClick += new System.EventHandler(this.lstUsersOnline_DoubleClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(502, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Online Users:";
            // 
            // rTxtChatRoomText
            // 
            this.rTxtChatRoomText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtChatRoomText.BackColor = System.Drawing.SystemColors.Window;
            this.rTxtChatRoomText.Cursor = System.Windows.Forms.Cursors.Default;
            this.rTxtChatRoomText.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTxtChatRoomText.Location = new System.Drawing.Point(7, 93);
            this.rTxtChatRoomText.Name = "rTxtChatRoomText";
            this.rTxtChatRoomText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rTxtChatRoomText.Size = new System.Drawing.Size(488, 273);
            this.rTxtChatRoomText.TabIndex = 4;
            this.rTxtChatRoomText.Text = "";
            this.rTxtChatRoomText.Enter += new System.EventHandler(this.rTxtChatRoomText_Enter);
            this.rTxtChatRoomText.TextChanged += new System.EventHandler(this.rTxtChatRoomText_TextChanged);
            // 
            // rTxtUserText
            // 
            this.rTxtUserText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtUserText.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTxtUserText.Location = new System.Drawing.Point(7, 405);
            this.rTxtUserText.MaxLength = 512;
            this.rTxtUserText.Name = "rTxtUserText";
            this.rTxtUserText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rTxtUserText.Size = new System.Drawing.Size(407, 44);
            this.rTxtUserText.TabIndex = 7;
            this.rTxtUserText.Text = "";
            this.rTxtUserText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rTxtUserText_KeyDown);
            this.rTxtUserText.TextChanged += new System.EventHandler(this.rTxtUserText_TextChanged);
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveChatToolStripMenuItem,
            this.mnuBtnFile,
            this.mnuBtnAbout,
            this.exitToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(777, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "Main Menu";
            // 
            // saveChatToolStripMenuItem
            // 
            this.saveChatToolStripMenuItem.Name = "saveChatToolStripMenuItem";
            this.saveChatToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveChatToolStripMenuItem.ShowShortcutKeys = false;
            this.saveChatToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.saveChatToolStripMenuItem.Text = "&Save Chat";
            this.saveChatToolStripMenuItem.Click += new System.EventHandler(this.btnSaveChat_Click);
            // 
            // mnuBtnFile
            // 
            this.mnuBtnFile.Name = "mnuBtnFile";
            this.mnuBtnFile.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                        | System.Windows.Forms.Keys.T)));
            this.mnuBtnFile.ShowShortcutKeys = false;
            this.mnuBtnFile.Size = new System.Drawing.Size(61, 20);
            this.mnuBtnFile.Text = "Se&ttings";
            this.mnuBtnFile.Click += new System.EventHandler(this.mnuBtnSettings_Click);
            // 
            // mnuBtnAbout
            // 
            this.mnuBtnAbout.Name = "mnuBtnAbout";
            this.mnuBtnAbout.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                        | System.Windows.Forms.Keys.A)));
            this.mnuBtnAbout.Size = new System.Drawing.Size(52, 20);
            this.mnuBtnAbout.Text = "&About";
            this.mnuBtnAbout.Click += new System.EventHandler(this.mnuBtnAbout_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                        | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.mnuBtnExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Chatroom Activity:";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(420, 403);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 46);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblScanning
            // 
            this.lblScanning.AutoSize = true;
            this.lblScanning.Location = new System.Drawing.Point(102, 77);
            this.lblScanning.Name = "lblScanning";
            this.lblScanning.Size = new System.Drawing.Size(10, 13);
            this.lblScanning.TabIndex = 4;
            this.lblScanning.Text = " ";
            // 
            // bgWUserFinder
            // 
            this.bgWUserFinder.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWUserFinder_DoWork);
            // 
            // bgWDataCollector
            // 
            this.bgWDataCollector.WorkerReportsProgress = true;
            this.bgWDataCollector.WorkerSupportsCancellation = true;
            this.bgWDataCollector.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWDataCollector_DoWork);
            // 
            // bgWDataSender
            // 
            this.bgWDataSender.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWDataSender_DoWork);
            // 
            // dlgFontSelector
            // 
            this.dlgFontSelector.ShowColor = true;
            this.dlgFontSelector.ShowEffects = false;
            // 
            // btnFont
            // 
            this.btnFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFont.Enabled = false;
            this.btnFont.Location = new System.Drawing.Point(7, 372);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(208, 27);
            this.btnFont.TabIndex = 5;
            this.btnFont.Text = "Font";
            this.btnFont.UseVisualStyleBackColor = true;
            // 
            // dlgColorPicker
            // 
            this.dlgColorPicker.AllowFullOpen = false;
            this.dlgColorPicker.AnyColor = true;
            // 
            // btnColor
            // 
            this.btnColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnColor.Enabled = false;
            this.btnColor.Location = new System.Drawing.Point(221, 372);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(92, 27);
            this.btnColor.TabIndex = 6;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = true;
            // 
            // bgWUpdater
            // 
            this.bgWUpdater.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWUpdater_DoWork);
            // 
            // sysTrayNotifier
            // 
            this.sysTrayNotifier.ContextMenuStrip = this.sysTrayContextMenu;
            this.sysTrayNotifier.Icon = ((System.Drawing.Icon)(resources.GetObject("sysTrayNotifier.Icon")));
            this.sysTrayNotifier.Text = "WalkieTalkie";
            this.sysTrayNotifier.Visible = true;
            this.sysTrayNotifier.DoubleClick += new System.EventHandler(this.sysTrayNotifier_DoubleClick);
            // 
            // sysTrayContextMenu
            // 
            this.sysTrayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sysTrayMnuBtnExit});
            this.sysTrayContextMenu.Name = "sysTrayContextMenu";
            this.sysTrayContextMenu.Size = new System.Drawing.Size(93, 26);
            // 
            // sysTrayMnuBtnExit
            // 
            this.sysTrayMnuBtnExit.Name = "sysTrayMnuBtnExit";
            this.sysTrayMnuBtnExit.Size = new System.Drawing.Size(92, 22);
            this.sysTrayMnuBtnExit.Text = "&Exit";
            this.sysTrayMnuBtnExit.Click += new System.EventHandler(this.sysTrayMnuBtnExit_Click);
            // 
            // btnRefreshUserList
            // 
            this.btnRefreshUserList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshUserList.Location = new System.Drawing.Point(627, 64);
            this.btnRefreshUserList.Name = "btnRefreshUserList";
            this.btnRefreshUserList.Size = new System.Drawing.Size(142, 23);
            this.btnRefreshUserList.TabIndex = 10;
            this.btnRefreshUserList.Text = "&Refresh Online Users";
            this.btnRefreshUserList.UseVisualStyleBackColor = true;
            this.btnRefreshUserList.Click += new System.EventHandler(this.btnRefreshUserList_Click);
            // 
            // dlgSaveRtf
            // 
            this.dlgSaveRtf.DefaultExt = "rtf";
            this.dlgSaveRtf.Filter = "Rich Text Format|*.rtf";
            this.dlgSaveRtf.RestoreDirectory = true;
            this.dlgSaveRtf.Title = "Save Chat Session";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(71, 30);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(78, 19);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "userName";
            // 
            // txtStatusMessage
            // 
            this.txtStatusMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatusMessage.BackColor = System.Drawing.SystemColors.Control;
            this.txtStatusMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStatusMessage.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatusMessage.Location = new System.Drawing.Point(505, 30);
            this.txtStatusMessage.MaxLength = 50;
            this.txtStatusMessage.Name = "txtStatusMessage";
            this.txtStatusMessage.Size = new System.Drawing.Size(264, 23);
            this.txtStatusMessage.TabIndex = 12;
            this.txtStatusMessage.Text = "Type here to set your status...";
            this.txtStatusMessage.Click += new System.EventHandler(this.txtStatusMessage_Click);
            this.txtStatusMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStatusMessage_KeyDown);
            this.txtStatusMessage.Leave += new System.EventHandler(this.txtStatusMessage_Leave);
            this.txtStatusMessage.Enter += new System.EventHandler(this.txtStatusMessage_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Welcome";
            // 
            // wndMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 454);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtStatusMessage);
            this.Controls.Add(this.btnRefreshUserList);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnFont);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lblScanning);
            this.Controls.Add(this.rTxtUserText);
            this.Controls.Add(this.rTxtChatRoomText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstUsersOnline);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(610, 265);
            this.Name = "wndMain";
            this.Text = "WalkieTalkie - For MCA Batch of 2012, NITT";
            this.Shown += new System.EventHandler(this.wndMain_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wndMain_FormClosing);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.sysTrayContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstUsersOnline;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rTxtChatRoomText;
        private System.Windows.Forms.RichTextBox rTxtUserText;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuBtnAbout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblScanning;
        private System.ComponentModel.BackgroundWorker bgWUserFinder;
        private System.ComponentModel.BackgroundWorker bgWDataCollector;
        private System.ComponentModel.BackgroundWorker bgWDataSender;
        private System.Windows.Forms.FontDialog dlgFontSelector;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.ColorDialog dlgColorPicker;
        private System.Windows.Forms.Button btnColor;
        private System.ComponentModel.BackgroundWorker bgWUpdater;
        private System.Windows.Forms.ToolStripMenuItem mnuBtnFile;
        private System.Windows.Forms.NotifyIcon sysTrayNotifier;
        private System.Windows.Forms.ContextMenuStrip sysTrayContextMenu;
        private System.Windows.Forms.ToolStripMenuItem sysTrayMnuBtnExit;
        private System.Windows.Forms.Button btnRefreshUserList;
        private System.Windows.Forms.SaveFileDialog dlgSaveRtf;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveChatToolStripMenuItem;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtStatusMessage;
        private System.Windows.Forms.Label label3;
    }
}

