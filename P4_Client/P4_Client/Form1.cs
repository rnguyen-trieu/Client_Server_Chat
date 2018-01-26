using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Microsoft.VisualBasic;
using System.Collections;
using System.Threading;

namespace P4_Client
{
    public partial class Form1 : Form
    {
        TcpClient client = new TcpClient();
        private String textToSend;
        private bool HasName = false;
        public String UserName = "";
        public String UserList = "";
        public bool IsServer = false;
        
        List<TcpClient> clientList = new List<TcpClient>(); 
    
        static protected ArrayList arrClients = new ArrayList();
        static protected ArrayList arrMsgs = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Send_button_Click(object sender, EventArgs e)
        {
            if (SendChat_box.Text != "")
            {
                if (client.Connected)
                {
                    if (SendChat_box.Text != "")
                    {
                        textToSend = UserName + ": " + SendChat_box.Text;

                        if (textToSend != null)
                        {
                            NetworkStream stream = client.GetStream();
                            BinaryWriter writer = new BinaryWriter(stream);

                            try
                            {
                                writer.Write(textToSend);
                                writer.Flush();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                        }
                    }
                    SendChat_box.Text = "";
                }
            }
        }

        private void Client_Start_Click(object sender, EventArgs e)
        {
            client = new System.Net.Sockets.TcpClient();
            IPEndPoint DefaultIpEnd = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 51111);

            string address;
            try
            {
                while (!client.Connected)
                {
                    address = "";

                    if (address == "")
                    {
                        address = Microsoft.VisualBasic.Interaction.InputBox("Enter the server IP: (Defaults to 127.0.0.1 if no input or fails) ", "Address Prompt", "", -1, -1);
                        client.Connect(address, 51111);
                        if (!client.Connected)
                        {
                            client.Connect(DefaultIpEnd);
                        }
                    }
                    if (!client.Connected)
                    {
                        client.Connect(DefaultIpEnd);
                    }

                }

                if (client.Connected)
                {
                    MessageBox.Show("(Client) Connection Successful!");

                    while (HasName == false)
                    {
                        string input = Microsoft.VisualBasic.Interaction.InputBox("(Client) Enter a Username", "Username Prompt", "Rookie", -1, -1);

                        UserName = input;
                        HasName = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("(Client [Click]) " + ex.Message);
            }
            NetworkStream serverStream = client.GetStream();
            Thread receiver = new Thread((() => { receiveText(serverStream); }));
            receiver.Start();
        }

        private void receiveText(NetworkStream netStream)
        {
            BinaryReader reader = new BinaryReader(netStream);
            string text;
            while (true)
            {
                    text = reader.ReadString();

                    ChatLog_textbox.Invoke(new MethodInvoker(delegate ()
                    {
                        ChatLog_textbox.AppendText(text + "\r\n");
                    }));
            }
        }
    } // end of form partial class
} // end of program
