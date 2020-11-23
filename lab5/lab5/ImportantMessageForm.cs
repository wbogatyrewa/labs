using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5
{
    public partial class ImportantMessageForm : Form
    {
        public ImportantMessageForm()
        {
            InitializeComponent();
            ImportantMsgListBox.Items.Add("Сообщение 1");
            ImportantMsgListBox.Items.Add("Сообщение 2");
            ImportantMsgListBox.Items.Add("Сообщение 3");
            ImportantMsgListBox.Items.Add("Сообщение 4");
        }
    }
}
