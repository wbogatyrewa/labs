/*
Разработать программу-клиент для социальной сети (на выбор студента). Программа должна
представлять многооконное приложение (минимум 2 окна). Функциональность и графический
интерфейс на усмотрение студента. Взаимодействие с социальной сетью через REST API.
Предусмотреть минимум 3 разнотипных запроса к социальной сети через REST API.


Приложение VkClient, которое обеспечивает пользователя доступом только к личным сообщениям 
с самим собой и его важным сообщениям. Существует возможность отправлять текстовые сообщения и удалять их,
а также отмечать сообщения как важные и снимать эту отметку. 

Как все происходит: в главном окне приложения VkClient проходит авторизация через форму WinForms WebView. 
Устанавливается режим "оффлайн". Затем появляется личная информация о пользователе (его имя, фамилия и фото),
его текущий статус (в сети или не в сети), личная переписка пользователя и кнопка "Важные сообщения".
При переходе по кнопке "Важные сообщения" появляется окно с этими сообщениями. 
При нажатии правой кнопкой мыши по сообщению возникает меню: удалить, отметить как важное, 
снять отметку, посмотреть вложение. 
Если пользователь нажимает на "Посмотреть вложение", то он переходит в новое окно. 
Если вложение - фото, видео или ссылка, то оно отобразится в новом окне "Вложения", 
в остальных случаях вложение считается некорректным. Если сообщение задано серией фотографий, 
будет показано только первое изображение.
Отправка сообщения может быть только в виде текста. Осуществляется как по кнопке "Send", так и клавишей Enter.

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
using System.Text.RegularExpressions;
using System.Xml;
using System.Collections.Specialized;
using System.Web;
using System.Net;
using System.IO;

namespace lab5
{
    public partial class VkClient : Form
    {
        private int appId = 7652326;
        private string scope = "account,messages";
        private VkUser user = new VkUser();
        private List<VkMessage> vkMessages = new List<VkMessage>();
        private int locationMessage;


        public VkClient()
        {
            InitializeComponent();
        }
        private void VkClient_Load(object sender, EventArgs e)
        {
            VkClientIsVisible(false);
            webViewAuth.Navigate(String.Format("http://api.vkontakte.ru/oauth/authorize?client_id={0}&scope={1}&display=popup&response_type=token&v=5.126", appId, scope));
        }

        private void webViewAuth_DOMContentLoaded(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlDOMContentLoadedEventArgs e)
        {
            // получить токен, распарсив Uri
            if (e.Uri.ToString().IndexOf("access_token") != -1)
            {
                Regex uri = new Regex(@"(?<name>[\w\d\x5f]+)=(?<value>[^\x26\s]+)",
                    RegexOptions.IgnoreCase | RegexOptions.Singleline);
                foreach (Match m in uri.Matches(e.Uri.ToString()))
                {
                    if (m.Groups["name"].Value == "access_token")
                    {
                        user.AccessToken = m.Groups["value"].Value;
                    }
                    else if (m.Groups["name"].Value == "user_id")
                    {
                        user.UserId = m.Groups["value"].Value;
                    }
                }
            }

            VkClientShow();
        }

        private void VkClientShow()
        {
            if (user.AccessToken != null && user.UserId != null)
            {
                VkClientIsVisible(true);
                SetOffline();

                GetUserData();
                nameLabel.Text = user.Name + " " + user.Surname;

                HistoryMessagesShow();

                LastActivityShow();
            }
        }
        private void VkClientIsVisible(bool visible)
        {
            webViewAuth.Visible = !visible;
            messagesBox.Visible = visible;
            btnImportantMsg.Visible = visible;
        }

        private void GetUserData()
        {
            NameValueCollection qs = new NameValueCollection();
            qs["uid"] = user.UserId;
            qs["fields"] = "uid,first_name,last_name,photo";

            XmlDocument profile = ExecuteCommandXml("getProfiles", qs);
            user.Name = profile.SelectSingleNode("response/user/first_name").InnerText;
            user.Surname = profile.SelectSingleNode("response/user/last_name").InnerText;
            user.Photo = profile.SelectSingleNode("response/user/photo").InnerText;

            if (profile.SelectSingleNode("response/user/photo") != null 
                && !String.IsNullOrEmpty(user.Photo))
            {
                WebClient wc = new WebClient();
                byte[] b = wc.DownloadData(user.Photo);
                MemoryStream m = new MemoryStream(b);
                photoUserBox.Image = Image.FromStream(m);

            }
        }

        private void HistoryMessagesShow()
        {
            XmlNodeList itemsMessages = GetHistoryMessages();

            foreach (XmlElement msg in itemsMessages.Item(0))
            {
                VkMessage message = new VkMessage();

                message.Id = msg.SelectSingleNode("id").InnerText;
                message.Text = msg.SelectSingleNode("body").InnerText;

                if (msg.SelectNodes("attachments").Item(0) != null)
                {
                    message.Attachments = msg.SelectNodes("attachments");
                    messagesListBox.Items.Insert(0, message.Text + "(RIGHT-CLICK TO SEE ATTACHMENT)");
                }
                else
                {
                    messagesListBox.Items.Insert(0, message.Text);
                }
                vkMessages.Insert(0, message);

            }

        }

        private void GetNewMessage()
        {
            NameValueCollection qs = new NameValueCollection();
            qs["user_id"] = user.UserId;
            qs["count"] = "1";


            XmlDocument historyMessages = ExecuteCommandXml("messages.getHistory", qs);
            XmlNodeList itemsMessages = historyMessages.SelectNodes("response/items");

            foreach (XmlElement msg in itemsMessages.Item(0))
            {
                VkMessage message = new VkMessage();

                message.Id = msg.SelectSingleNode("id").InnerText;
                message.Text = msg.SelectSingleNode("body").InnerText;

                vkMessages.Insert(0, message);
                messagesListBox.Items.Add(message.Text);
              
            }
            
        }
        private void LastActivityShow()
        {
            XmlDocument lastActivity = GetLastActivity();
            string online = lastActivity.SelectSingleNode("response/online").InnerText;
            if (online == "0")
            {
                labelLastActivity.Text = "не в сети";
            }
            else
            {
                labelLastActivity.Text = "в сети";
            }
        }

        private XmlNodeList GetHistoryMessages()
        {
            NameValueCollection qs = new NameValueCollection();
            qs["user_id"] = user.UserId;
            qs["count"] = "200";

            
            XmlDocument historyMessages = ExecuteCommandXml("messages.getHistory", qs);
            XmlNodeList itemsMessages = historyMessages.SelectNodes("response/items");

            //historyMessages.Save("C:/Users/veron/source/repos/lab5/lab5/historyMessages.xml");
            return itemsMessages;
        }
        
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            NameValueCollection qs = new NameValueCollection();
            qs["user_id"] = user.UserId;
            qs["message"] = txtMessage.Text;

            ExecuteCommandXml("messages.send", qs);
            GetNewMessage();
            

            txtMessage.Text = "Напишите сообщение...";
        }

        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                NameValueCollection qs = new NameValueCollection();
                qs["user_id"] = user.UserId;
                qs["message"] = txtMessage.Text;

                ExecuteCommandXml("messages.send", qs);
                GetNewMessage();

                txtMessage.Text = "";
            }
        }

        private void SetOffline()
        {
            NameValueCollection qs = new NameValueCollection();
            ExecuteCommandXml("account.setOffline", qs);
        }

        private XmlDocument GetLastActivity()
        {
            NameValueCollection qs = new NameValueCollection();
            qs["user_id"] = user.UserId;

            XmlDocument lastActivity = ExecuteCommandXml("messages.getLastActivity", qs);
            return lastActivity;
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

        private void btnImportantMsg_Click(object sender, EventArgs e)
        {
            ImportantMessageForm importantMsgForm = new ImportantMessageForm();
            importantMsgForm.user = new VkUser(user.AccessToken, user.UserId);
            importantMsgForm.Show();
        }

        private void txtMessage_Enter(object sender, EventArgs e)
        {
            if (txtMessage.Text == "Напишите сообщение...")
            {
                txtMessage.Text = "";
            }
        }
        private void txtMessage_Leave(object sender, EventArgs e)
        {
            if (txtMessage.Text == "")
            {
                txtMessage.Text = "Напишите сообщение...";
            }
        }

        private void messagesListBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(messagesListBox.Items[e.Index].ToString(), messagesListBox.Font, messagesListBox.Width).Height + 10;
        }

        private void messagesListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (messagesListBox.Items.Count > 0)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                e.Graphics.DrawString(messagesListBox.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
        }

        private void messagesListBox_MouseUp(object sender, MouseEventArgs e)
        {
            locationMessage = messagesListBox.IndexFromPoint(e.Location);
            if (e.Button == MouseButtons.Right)
            {
                messagesListBox.SelectedIndex = locationMessage;                
                contextMenuStripMessage.Show(PointToScreen(e.Location));  
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NameValueCollection qs = new NameValueCollection();
            qs["message_ids"] = vkMessages[locationMessage].Id;

            ExecuteCommandXml("messages.delete", qs);
            messagesListBox.Items.RemoveAt(locationMessage);
        }

        private void addImportantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NameValueCollection qs = new NameValueCollection();
            qs["message_ids"] = vkMessages[locationMessage].Id;
            qs["important"] = "1";

            ExecuteCommandXml("messages.markAsImportant", qs);
        }

        private void showAttachmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttachmentsForm imageForm = new AttachmentsForm();
            imageForm.Message = vkMessages[locationMessage];
            
            imageForm.Show();
            
        }
    }
}
