namespace WalkieTalkie
{
    partial class wndPrivateChat
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
            this.rTxtChatText = new System.Windows.Forms.RichTextBox();
            this.rTxtUserText = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnFont = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rTxtChatText
            // 
            this.rTxtChatText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtChatText.Location = new System.Drawing.Point(12, 12);
            this.rTxtChatText.Name = "rTxtChatText";
            this.rTxtChatText.Size = new System.Drawing.Size(597, 271);
            this.rTxtChatText.TabIndex = 0;
            this.rTxtChatText.Text = "";
            // 
            // rTxtUserText
            // 
            this.rTxtUserText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtUserText.Location = new System.Drawing.Point(12, 322);
            this.rTxtUserText.Name = "rTxtUserText";
            this.rTxtUserText.Size = new System.Drawing.Size(516, 44);
            this.rTxtUserText.TabIndex = 1;
            this.rTxtUserText.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(534, 322);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 44);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // btnColor
            // 
            this.btnColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnColor.Enabled = false;
            this.btnColor.Location = new System.Drawing.Point(226, 289);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(92, 27);
            this.btnColor.TabIndex = 11;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = true;
            // 
            // btnFont
            // 
            this.btnFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFont.Enabled = false;
            this.btnFont.Location = new System.Drawing.Point(12, 289);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(208, 27);
            this.btnFont.TabIndex = 12;
            this.btnFont.Text = "Font";
            this.btnFont.UseVisualStyleBackColor = true;
            // 
            // wndPrivateChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 378);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnFont);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.rTxtUserText);
            this.Controls.Add(this.rTxtChatText);
            this.Name = "wndPrivateChat";
            this.Text = "UserName";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rTxtChatText;
        private System.Windows.Forms.RichTextBox rTxtUserText;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnFont;
    }
}