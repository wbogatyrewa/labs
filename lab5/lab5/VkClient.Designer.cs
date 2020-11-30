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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VkClient));
            this.webViewAuth = new Microsoft.Toolkit.Forms.UI.Controls.WebView();
            this.btnImportantMsg = new System.Windows.Forms.Button();
            this.messagesBox = new System.Windows.Forms.GroupBox();
            this.messagesListBox = new System.Windows.Forms.ListBox();
            this.labelLastActivity = new System.Windows.Forms.Label();
            this.photoUserBox = new System.Windows.Forms.PictureBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.imageListAttachments = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStripMessage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addImportantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.webViewAuth)).BeginInit();
            this.messagesBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoUserBox)).BeginInit();
            this.contextMenuStripMessage.SuspendLayout();
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
            this.messagesBox.Controls.Add(this.messagesListBox);
            this.messagesBox.Controls.Add(this.labelLastActivity);
            this.messagesBox.Controls.Add(this.photoUserBox);
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
            // messagesListBox
            // 
            this.messagesListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.messagesListBox.FormattingEnabled = true;
            this.messagesListBox.IntegralHeight = false;
            this.messagesListBox.ItemHeight = 20;
            this.messagesListBox.Location = new System.Drawing.Point(6, 53);
            this.messagesListBox.Name = "messagesListBox";
            this.messagesListBox.ScrollAlwaysVisible = true;
            this.messagesListBox.Size = new System.Drawing.Size(357, 314);
            this.messagesListBox.TabIndex = 5;
            this.messagesListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.messagesListBox_DrawItem);
            this.messagesListBox.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.messagesListBox_MeasureItem);
            this.messagesListBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.messagesListBox_MouseUp);
            // 
            // labelLastActivity
            // 
            this.labelLastActivity.AutoSize = true;
            this.labelLastActivity.Location = new System.Drawing.Point(162, 32);
            this.labelLastActivity.Name = "labelLastActivity";
            this.labelLastActivity.Size = new System.Drawing.Size(41, 13);
            this.labelLastActivity.TabIndex = 6;
            this.labelLastActivity.Text = "Статус";
            // 
            // photoUserBox
            // 
            this.photoUserBox.Location = new System.Drawing.Point(315, 9);
            this.photoUserBox.Name = "photoUserBox";
            this.photoUserBox.Size = new System.Drawing.Size(38, 36);
            this.photoUserBox.TabIndex = 4;
            this.photoUserBox.TabStop = false;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(337, 372);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(26, 20);
            this.btnSendMessage.TabIndex = 2;
            this.btnSendMessage.Text = "S";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(6, 373);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(324, 20);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.Text = "Напишите сообщение...";
            this.txtMessage.Enter += new System.EventHandler(this.txtMessage_Enter);
            this.txtMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessage_KeyPress);
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
            // imageListAttachments
            // 
            this.imageListAttachments.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListAttachments.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListAttachments.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextMenuStripMessage
            // 
            this.contextMenuStripMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.addImportantToolStripMenuItem,
            this.showImageToolStripMenuItem});
            this.contextMenuStripMessage.Name = "contextMenuStripMessage";
            this.contextMenuStripMessage.Size = new System.Drawing.Size(192, 92);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.deleteToolStripMenuItem.Text = "Удалить";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // addImportantToolStripMenuItem
            // 
            this.addImportantToolStripMenuItem.Name = "addImportantToolStripMenuItem";
            this.addImportantToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.addImportantToolStripMenuItem.Text = "Отметить как важное";
            this.addImportantToolStripMenuItem.Click += new System.EventHandler(this.addImportantToolStripMenuItem_Click);
            // 
            // showImageToolStripMenuItem
            // 
            this.showImageToolStripMenuItem.Name = "showImageToolStripMenuItem";
            this.showImageToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.showImageToolStripMenuItem.Text = "Открыть вложение";
            this.showImageToolStripMenuItem.Click += new System.EventHandler(this.showAttachmentsToolStripMenuItem_Click);
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
            this.Load += new System.EventHandler(this.VkClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webViewAuth)).EndInit();
            this.messagesBox.ResumeLayout(false);
            this.messagesBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoUserBox)).EndInit();
            this.contextMenuStripMessage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Toolkit.Forms.UI.Controls.WebView webViewAuth;
        private System.Windows.Forms.Button btnImportantMsg;
        private System.Windows.Forms.GroupBox messagesBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.PictureBox photoUserBox;
        private System.Windows.Forms.ListBox messagesListBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMessage;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addImportantToolStripMenuItem;
        private System.Windows.Forms.Label labelLastActivity;
        private System.Windows.Forms.ImageList imageListAttachments;
        private System.Windows.Forms.ToolStripMenuItem showImageToolStripMenuItem;
    }
}

