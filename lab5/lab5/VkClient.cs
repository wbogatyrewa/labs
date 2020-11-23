/*
Разработать программу-клиент для социальной сети (на выбор студента). Программа должна
представлять многооконное приложение (минимум 2 окна). Функциональность и графический
интерфейс на усмотрение студента. Взаимодействие с социальной сетью через REST API.
Предусмотреть минимум 3 разнотипных запроса к социальной сети через REST API.

клиент ВК (экономия времени; чтобы никто не отвлекал):
- авторизация (1е окно),
- доступ важным сообщениям (2е окно),
- единственная доступная переписка - личка с собой (поиск по сообщениям,
возможность написать себе, редактировать сообщение) (1е окно),
- находиться в оффлайн режиме (кроме момента отправки сообщений, авторизации)

окно важных сообщений и личка:
создать отдельную форму для отдельного сообщения, можно удалять, восстанавливать,
редактировать в течении 24 часов

получать историю сообщений
фигачить их в месседжФорм, чтобы она отражала их в листБокс
добавить в месседжФорм кнопку удаления сообщения
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
        private string scope = "photos,account,messages,users";
        private VkUser user = new VkUser();

        public VkClient()
        {
            InitializeComponent();
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
                GetUserData();
                nameLabel.Text = user.Name + " " + user.Surname;
                GetHistoryMessages();
                
            }
        }
        private void VkClientIsVisible(bool visible)
        {
            webViewAuth.Visible = !visible;
            messagesBox.Visible = visible;
            nameLabel.Visible = visible;
            btnImportantMsg.Visible = visible;
            txtMessage.Visible = visible;
            btnSendMessage.Visible = visible;
            photoUserBox.Visible = visible;

        }

        private void GetUserData()
        {
            NameValueCollection qs = new NameValueCollection();
            qs["uid"] = user.UserId;
            qs["fields"] = "uid,first_name,last_name,photo";

            XmlDocument profile = ExecuteCommandXml("getProfiles", qs, "5.62");
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
        private XmlDocument GetHistoryMessages()
        {
            NameValueCollection qs = new NameValueCollection();
            qs["user_id"] = user.UserId;
            qs["count"] = "20";
            
            XmlDocument historyMessages = ExecuteCommandXml("messages.getHistory", qs, "5.62");
            //List<string> messages = historyMessages.SelectSingleNode("response/items")
            XmlNodeList itemsMessages = historyMessages.GetElementsByTagName("items");
            

            return historyMessages;
        }

        private XmlDocument ExecuteCommandXml(string methodName, NameValueCollection qs, string version)
        {
            XmlDocument result = new XmlDocument();
            result.Load(String.Format("https://api.vk.com/method/{0}.xml?access_token={1}&{2}&v={3}",
                methodName, user.AccessToken, String.Join("&", from item in qs.AllKeys select item + "=" + qs[item]),
                version));
            return result;
        }

        
        private void btnImportantMsg_Click(object sender, EventArgs e)
        {
            ImportantMessageForm importantMsgForm = new ImportantMessageForm();
            importantMsgForm.Show();
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            NameValueCollection qs = new NameValueCollection();
            qs["uid"] = user.UserId;
            string SendMessage = txtMessage.Text;

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
    }
}
