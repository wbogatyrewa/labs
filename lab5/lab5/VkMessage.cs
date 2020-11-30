using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace lab5
{
    public class VkMessage
    {
        public string Id { get; set; } = null;
        public string Text { get; set; } = null;
        public XmlNodeList Attachments { get; set; } = null;

        public string Important = "0";

        public VkMessage()
        {

        }
        
        public VkMessage(string id, string text, XmlNodeList attachments, string important)
        {
            Id = id;
            Text = text;
            Attachments = attachments;
            Important = important;
        }
    }

}
