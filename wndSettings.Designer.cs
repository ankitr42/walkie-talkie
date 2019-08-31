namespace WalkieTalkie
{
    partial class wndSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wndSettings));
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.chkStartMinimized = new System.Windows.Forms.CheckBox();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkShowGroupNotification = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.grpSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.txtIPAddress);
            this.grpSettings.Controls.Add(this.chkShowGroupNotification);
            this.grpSettings.Controls.Add(this.chkStartMinimized);
            this.grpSettings.Controls.Add(this.chkAutoStart);
            this.grpSettings.Controls.Add(this.btnCancel);
            this.grpSettings.Controls.Add(this.btnOK);
            this.grpSettings.Controls.Add(this.txtUserName);
            this.grpSettings.Controls.Add(this.label2);
            this.grpSettings.Controls.Add(this.label1);
            this.grpSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSettings.Location = new System.Drawing.Point(0, 0);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(372, 181);
            this.grpSettings.TabIndex = 0;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Settings";
            // 
            // chkStartMinimized
            // 
            this.chkStartMinimized.AutoSize = true;
            this.chkStartMinimized.Location = new System.Drawing.Point(76, 98);
            this.chkStartMinimized.Name = "chkStartMinimized";
            this.chkStartMinimized.Size = new System.Drawing.Size(99, 17);
            this.chkStartMinimized.TabIndex = 3;
            this.chkStartMinimized.Text = "Start minimized.";
            this.chkStartMinimized.UseVisualStyleBackColor = true;
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Location = new System.Drawing.Point(76, 75);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(218, 17);
            this.chkAutoStart.TabIndex = 2;
            this.chkAutoStart.Text = "Automatically start when Windows starts.";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(288, 147);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(207, 147);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(76, 19);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(287, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "My Name: ";
            // 
            // chkShowGroupNotification
            // 
            this.chkShowGroupNotification.AutoSize = true;
            this.chkShowGroupNotification.Location = new System.Drawing.Point(76, 121);
            this.chkShowGroupNotification.Name = "chkShowGroupNotification";
            this.chkShowGroupNotification.Size = new System.Drawing.Size(222, 17);
            this.chkShowGroupNotification.TabIndex = 6;
            this.chkShowGroupNotification.Text = "Show notification for chatroom messages.";
            this.chkShowGroupNotification.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "LAN IP:";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(76, 45);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(287, 20);
            this.txtIPAddress.TabIndex = 7;
            // 
            // wndSettings
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(372, 181);
            this.Controls.Add(this.grpSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wndSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "WalkieTalkie Settings";
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.CheckBox chkStartMinimized;
        private System.Windows.Forms.CheckBox chkShowGroupNotification;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIPAddress;

    }
}