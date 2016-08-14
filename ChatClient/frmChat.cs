﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class frmChat : Form
    {
        public frmChat()
        {
            InitializeComponent();
        }

       

        private void btnEnter_Click(object sender, EventArgs e)
        { 
            Api.ChatService chatService = new Api.ChatService();
            List<Api.Model.Messages> messages = chatService.EnterRoom(txtRoom.Text);

            RefreshMessages(messages);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Api.ChatService chatService = new Api.ChatService();
            List<Api.Model.Messages> messages = chatService.EnterRoom(txtRoom.Text);

            RefreshMessages(messages);
        }

        private void btnPostMessage_Click(object sender, EventArgs e)
        {
            Api.ChatService chatService = new Api.ChatService();
            chatService.PostMessages(txtRoom.Text, txtUser.Text, txtMessage.Text);
        }



        private void RefreshMessages(List<Api.Model.Messages> messages)
        {
            foreach (var message in messages)
            {
                listBox1.Items.Add($"{message.User}: {message.Message}, às {message.Inclusion}");
            }
        }


    }
}
