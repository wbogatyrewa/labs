/*
 Отображение важных сообщений.
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Xml;


namespace lab5
{
    public partial class ImportantMessageForm : Form
    {
        public VkUser user = new VkUser();
        private List<VkMessage> ImportantMessages = new List<VkMessage>();
        private int locationMessage;

        public ImportantMessageForm()
        {
            InitializeComponent();
        }

        private void ImportantMessageForm_Load(object sender, EventArgs e)
        {
            XmlNodeList itemsMessages = GetImportantMessages();

            VkMessage vkMessage = new VkMessage();

            foreach (XmlElement item in itemsMessages.Item(0))
            {
                vkMessage.Important = "1";
                if (item.Name == "id")
                {
                    vkMessage.Id = item.InnerText;
                }
                else if (item.Name == "text")
                {
                    vkMessage.Text = item.InnerText;
                } 
                else if (item.Name == "attachments")
                {                  
                    vkMessage.Attachments = item.SelectNodes("attachment");
                    
                    ImportantMessages.Add(vkMessage);

                    if (vkMessage.Attachments.Count != 0)
                    {
                        ImportantMsgListBox.Items.Add(vkMessage.Text + "(RIGHT-CLICK TO SEE ATTACHMENT)");
                    }
                    else
                    {
                        ImportantMsgListBox.Items.Add(vkMessage.Text);
                    }
                    vkMessage = new VkMessage();
                }
            }
         
        }

        private XmlNodeList GetImportantMessages()
        {
            NameValueCollection qs = new NameValueCollection();
            qs["count"] = "200";

            XmlDocument importantMessages = ExecuteCommandXml("messages.getImportantMessages", qs);
            XmlNodeList itemsMessages = importantMessages.SelectNodes("response/messages/items");


            //importantMessages.Save("C:/Users/veron/source/repos/lab5/lab5/importantMessages.xml");

            return itemsMessages;
        }


        private XmlDocument ExecuteCommandXml(string methodName, NameValueCollection qs)
        {
            XmlDocument result = new XmlDocument();
            try
            {
                result.Load(String.Format("https://api.vk.com/method/{0}.xml?access_token={1}&{2}&v=5.62",
                    methodName, user.AccessToken, String.Join("&", from item in qs.AllKeys select item + "=" + qs[item])));
            } catch (XmlException e)
            {
                //MessageBox.Show(e.Message);
            }

            return result;
        }

        private void ImportantMsgListBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(ImportantMsgListBox.Items[e.Index].ToString(), ImportantMsgListBox.Font, ImportantMsgListBox.Width).Height + 10;
        }

        private void ImportantMsgListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (ImportantMsgListBox.Items.Count > 0)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                e.Graphics.DrawString(ImportantMsgListBox.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
        }

        private void ImportantMsgListBox_MouseUp(object sender, MouseEventArgs e)
        {
            locationMessage = ImportantMsgListBox.IndexFromPoint(e.Location);
            if (e.Button == MouseButtons.Right)
            {
                ImportantMsgListBox.SelectedIndex = locationMessage;
                contextMenuStripImportantMessage.Show(PointToScreen(e.Location));
            }

        }

        private void showAttachmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttachmentsForm imageForm = new AttachmentsForm();
            imageForm.Message = ImportantMessages[locationMessage];
            imageForm.Show();
        }

        private void deleteImportantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NameValueCollection qs = new NameValueCollection();
            qs["message_ids"] = ImportantMessages[locationMessage].Id;
            qs["important"] = "0";
            ExecuteCommandXml("messages.markAsImportant", qs);
            ImportantMsgListBox.Items.RemoveAt(locationMessage);
        }
    }
}
