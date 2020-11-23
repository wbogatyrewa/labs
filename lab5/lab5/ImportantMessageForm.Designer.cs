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
            this.ImportantMsgListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ImportantMsgListBox
            // 
            this.ImportantMsgListBox.FormattingEnabled = true;
            this.ImportantMsgListBox.Location = new System.Drawing.Point(-1, -1);
            this.ImportantMsgListBox.Name = "ImportantMsgListBox";
            this.ImportantMsgListBox.Size = new System.Drawing.Size(385, 420);
            this.ImportantMsgListBox.TabIndex = 0;
            // 
            // ImportantMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 411);
            this.Controls.Add(this.ImportantMsgListBox);
            this.Name = "ImportantMessageForm";
            this.Text = "Важные сообщения";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ImportantMsgListBox;
    }
}