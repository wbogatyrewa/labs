namespace lab5
{
    partial class VkClient
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VkClient));
            this.webViewAuth = new Microsoft.Toolkit.Forms.UI.Controls.WebView();
            this.btnImportantMsg = new System.Windows.Forms.Button();
            this.messagesBox = new System.Windows.Forms.GroupBox();
            this.photoUserBox = new System.Windows.Forms.PictureBox();
            this.messageListBox = new System.Windows.Forms.ListBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.webViewAuth)).BeginInit();
            this.messagesBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoUserBox)).BeginInit();
            this.SuspendLayout();
            // 
            // webViewAuth
            // 
            this.webViewAuth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webViewAuth.Location = new System.Drawing.Point(0, 0);
            this.webViewAuth.MinimumSize = new System.Drawing.Size(20, 20);
            this.webViewAuth.Name = "webViewAuth";
            this.webViewAuth.Size = new System.Drawing.Size(584, 411);
            this.webViewAuth.TabIndex = 0;
            this.webViewAuth.DOMContentLoaded += new System.EventHandler<Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlDOMContentLoadedEventArgs>(this.webViewAuth_DOMContentLoaded);
            // 
            // btnImportantMsg
            // 
            this.btnImportantMsg.Location = new System.Drawing.Point(13, 13);
            this.btnImportantMsg.Name = "btnImportantMsg";
            this.btnImportantMsg.Size = new System.Drawing.Size(121, 23);
            this.btnImportantMsg.TabIndex = 1;
            this.btnImportantMsg.Text = "Важные сообщения";
            this.btnImportantMsg.UseVisualStyleBackColor = true;
            this.btnImportantMsg.Visible = false;
            this.btnImportantMsg.Click += new System.EventHandler(this.btnImportantMsg_Click);
            // 
            // messagesBox
            // 
            this.messagesBox.Controls.Add(this.photoUserBox);
            this.messagesBox.Controls.Add(this.messageListBox);
            this.messagesBox.Controls.Add(this.btnSendMessage);
            this.messagesBox.Controls.Add(this.txtMessage);
            this.messagesBox.Controls.Add(this.nameLabel);
            this.messagesBox.Location = new System.Drawing.Point(161, 0);
            this.messagesBox.Name = "messagesBox";
            this.messagesBox.Size = new System.Drawing.Size(369, 399);
            this.messagesBox.TabIndex = 2;
            this.messagesBox.TabStop = false;
            this.messagesBox.Visible = false;
            // 
            // photoUserBox
            // 
            this.photoUserBox.Location = new System.Drawing.Point(325, 5);
            this.photoUserBox.Name = "photoUserBox";
            this.photoUserBox.Size = new System.Drawing.Size(38, 36);
            this.photoUserBox.TabIndex = 4;
            this.photoUserBox.TabStop = false;
            // 
            // messageListBox
            // 
            this.messageListBox.FormattingEnabled = true;
            this.messageListBox.Location = new System.Drawing.Point(6, 47);
            this.messageListBox.Name = "messageListBox";
            this.messageListBox.Size = new System.Drawing.Size(357, 303);
            this.messageListBox.TabIndex = 3;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(337, 360);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(26, 20);
            this.btnSendMessage.TabIndex = 2;
            this.btnSendMessage.Text = "S";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(6, 360);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(324, 20);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.Text = "Напишите сообщение...";
            this.txtMessage.Enter += new System.EventHandler(this.txtMessage_Enter);
            this.txtMessage.Leave += new System.EventHandler(this.txtMessage_Leave);
            // 
            // nameLabel
            // 
            this.nameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.nameLabel.Location = new System.Drawing.Point(3, 16);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(363, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Имя Фамилия";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VkClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.messagesBox);
            this.Controls.Add(this.btnImportantMsg);
            this.Controls.Add(this.webViewAuth);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VkClient";
            this.Text = "VkClient";
            ((System.ComponentModel.ISupportInitialize)(this.webViewAuth)).EndInit();
            this.messagesBox.ResumeLayout(false);
            this.messagesBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoUserBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Toolkit.Forms.UI.Controls.WebView webViewAuth;
        private System.Windows.Forms.Button btnImportantMsg;
        private System.Windows.Forms.GroupBox messagesBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.ListBox messageListBox;
        private System.Windows.Forms.PictureBox photoUserBox;
    }
}

