/*  
 Отображение вложений: фото, видео (ссылка на youtube) и ссылок.
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
using System.Xml;
using System.Net;
using System.IO;

namespace lab5
{
    public partial class AttachmentsForm : Form
    {
        public VkMessage Message = new VkMessage();

        public AttachmentsForm()
        {
            InitializeComponent();
        }

        private void AttachmentsForm_Load(object sender, EventArgs e)
        {
            
            if (Message.Attachments != null)
            {
                string type; 
                if (Message.Important == "0")
                {
                    type = Message.Attachments.Item(0).FirstChild.SelectSingleNode("type").InnerText;
                    if (type == "photo")
                    {
                        ImageIsVisible(true);
                        ImageShow(Message.Attachments.Item(0).FirstChild.SelectNodes("photo").Item(0).SelectSingleNode("photo_604").InnerText);

                    }
                    else if (type == "link")
                    {
                        ImageIsVisible(false);
                        LinkShow(Message.Attachments.Item(0).FirstChild.SelectNodes("link").Item(0).SelectSingleNode("url").InnerText);
                    }
                    else if (type == "video")
                    {
                        ImageIsVisible(false);
                        LinkShow(Message.Text);
                    }
                } else
                {
                    type = Message.Attachments.Item(0).SelectSingleNode("type").InnerText;
                    if (type == "photo")
                    {
                        ImageIsVisible(true);
                        ImageShow(Message.Attachments.Item(0).SelectNodes("photo").Item(0).SelectSingleNode("photo_604").InnerText);

                    }
                    else if (type == "link")
                    {
                        ImageIsVisible(false);
                        LinkShow(Message.Attachments.Item(0).SelectNodes("link").Item(0).SelectSingleNode("url").InnerText);
                    }
                    else if (type == "video")
                    {
                        ImageIsVisible(false);
                        LinkShow(Message.Text);
                    }
                }

                

            } else
            {
                MessageBox.Show("Невозможно просмотреть вложения");
            }

        }

        private void ImageIsVisible(bool visible)
        {
            pictureBox.Visible = visible;
            webBrowser.Visible = !visible;
        }

        private void ImageShow(string imageUrl)
        {
            WebClient wc = new WebClient();
            byte[] b = wc.DownloadData(imageUrl);
            MemoryStream m = new MemoryStream(b);
            pictureBox.Image = Image.FromStream(m);

        }

        private void LinkShow(string linkUrl)
        {
            webBrowser.Navigate(linkUrl);

        }
    }
}
