using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using BusinessLogic;
using BusinessObjects;

namespace PopotosKitchenV2
{
    /// <summary>
    /// Interaction logic for Message.xaml
    /// </summary>
    public partial class SendMessage : MetroWindow
    {
        private Cook _c;
        private Message _m;
        private CookManager _myCookManager = new CookManager();
        private bool _send = false;

        public SendMessage(Cook c, bool send, Message m)
        {
            _send = send;
            InitializeComponent();
            _c = c;
            _m = m;

            if(send == false)
            {
                txtMessageSubject.Text = _m.MessageSubject;
                txtMessageText.Text = _m.MessageText;
            }
        }

        private void btnSendMessage_Click(object sender, RoutedEventArgs e)
        {
            if(_send == true)
            {
                SendMessageToCook();
            }
            else
            {
                MarkAsRead();
            }
        }

        private void SendMessageToCook()
        {
            var m = new Message();
            m.CookID = _c.CookID;
            m.MessageSubject = txtMessageSubject.Text;
            m.MessageText = txtMessageText.Text;

            if (m.MessageSubject.Length < 1000)
            {
                try
                {
                    if (_myCookManager.SendCookMessage(m) == true)
                    {
                        MessageBox.Show("Success! Message sent.");
                        this.Close();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Message could not be sent. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Please keep message under 1000 characters.");
            }
        }

        private void MarkAsRead()
        {
            _m.HasRead = true;

            try
            {
                if(_myCookManager.EditMessage(_m) == true)
                {
                    DialogResult = true;
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not mark message as read.");
            }
        }
    }
}
