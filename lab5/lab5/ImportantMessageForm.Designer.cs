namespace lab5
{
    partial class ImportantMessageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportantMessageForm));
            this.ImportantMsgListBox = new System.Windows.Forms.ListBox();
            this.contextMenuStripImportantMessage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteImportantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAttachmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripImportantMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImportantMsgListBox
            // 
            this.ImportantMsgListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ImportantMsgListBox.FormattingEnabled = true;
            this.ImportantMsgListBox.Location = new System.Drawing.Point(-1, -1);
            this.ImportantMsgListBox.Name = "ImportantMsgListBox";
            this.ImportantMsgListBox.Size = new System.Drawing.Size(385, 420);
            this.ImportantMsgListBox.TabIndex = 0;
            this.ImportantMsgListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ImportantMsgListBox_DrawItem);
            this.ImportantMsgListBox.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ImportantMsgListBox_MeasureItem);
            this.ImportantMsgListBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImportantMsgListBox_MouseUp);
            // 
            // contextMenuStripImportantMessage
            // 
            this.contextMenuStripImportantMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteImportantToolStripMenuItem,
            this.showAttachmentsToolStripMenuItem});
            this.contextMenuStripImportantMessage.Name = "contextMenuStripImportantMessage";
            this.contextMenuStripImportantMessage.Size = new System.Drawing.Size(181, 70);
            // 
            // deleteImportantToolStripMenuItem
            // 
            this.deleteImportantToolStripMenuItem.Name = "deleteImportantToolStripMenuItem";
            this.deleteImportantToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteImportantToolStripMenuItem.Text = "Снять отметку";
            this.deleteImportantToolStripMenuItem.Click += new System.EventHandler(this.deleteImportantToolStripMenuItem_Click);
            // 
            // showAttachmentsToolStripMenuItem
            // 
            this.showAttachmentsToolStripMenuItem.Name = "showAttachmentsToolStripMenuItem";
            this.showAttachmentsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showAttachmentsToolStripMenuItem.Text = "Открыть вложение";
            this.showAttachmentsToolStripMenuItem.Click += new System.EventHandler(this.showAttachmentsToolStripMenuItem_Click);
            // 
            // ImportantMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 417);
            this.Controls.Add(this.ImportantMsgListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportantMessageForm";
            this.Text = "Важные сообщения";
            this.Load += new System.EventHandler(this.ImportantMessageForm_Load);
            this.contextMenuStripImportantMessage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ImportantMsgListBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripImportantMessage;
        private System.Windows.Forms.ToolStripMenuItem deleteImportantToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAttachmentsToolStripMenuItem;
    }
}