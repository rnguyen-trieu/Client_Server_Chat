using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using Microsoft.VisualBasic;
using System.Collections;


namespace P4_Server
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private TcpListener server;
        
        private Thread newThread;

        private List<TcpClient> clients = new List<TcpClient>();
        private ArrayList clientArray = new ArrayList();
        private ArrayList threadsArray = new ArrayList();

        private StreamReader reader;
        private StreamWriter writer;

        public String UserName = "";
        public String UserList = "";

        byte[] bytesFrom = new byte[10025];

        public bool IsServer = false;

        public delegate void ChangedEventHandler(object sender, EventArgs e);
        public event ChangedEventHandler Changed;
        public delegate void SetListBoxItem(String str, String type);
        
        readonly object o = new object();
        
        public Form1()
        {
            InitializeComponent();

            Changed += new ChangedEventHandler(ClientAdded);
            TreeNode node = tvClientList.Nodes.Add("Connected Clients");
            //tvClientList
        }

        public void StartServer()
        {
            newThread = new Thread(new ThreadStart(StartListen));
            newThread.Start();
        }

        public void StartListen()
        {
            server = new TcpListener(IPAddress.Any, 51111);

            server.Start();
            while (true)
            {
                client = server.AcceptTcpClient();
                Thread t = new Thread(new ParameterizedThreadStart(NewClient));
                t.Start(client);
                if (server.Pending())
                {
                    new Thread(UpdateClientChat).Start();
                }
            }
        }

        public void UpdateClientChat()
        {
            Socket socket = server.AcceptSocket();
            Stream stream = new NetworkStream(socket);
            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);
            writer.AutoFlush = true;
            bool client = false;
        }
        
        public void NewClient(Object obj)
        {
            ClientAdded(this, new MyEventArgs((TcpClient)obj));
        }

        public void ClientAdded(object sender, EventArgs e)
        {
            client = ((MyEventArgs)e).clientSock;
            String remoteIP = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
            String remotePort = ((IPEndPoint)client.Client.RemoteEndPoint).Port.ToString();
            UpdateClientList(remoteIP + " : " + remotePort, "Add");
            // Add to the array list here
            clients.Add(client);
            clientArray.Add(client);
            threadsArray.Add(Thread.CurrentThread);
            //Start newC = new Start(client, clients);
            
            Thread thread = new Thread(() => Start.chat(client, clients));
            thread.Start();
        }

        private void UpdateClientList(string str, string type)
        {
            if (this.tvClientList.InvokeRequired)
            {
                SetListBoxItem d = new SetListBoxItem(UpdateClientList);
                this.Invoke(d, new object[] { str, type });
            }
            else
            {
                if (type.Equals("Add"))
                {
                    this.tvClientList.Nodes[0].Nodes.Add(str);
                }
                else
                {
                    foreach (TreeNode n in this.tvClientList.Nodes[0].Nodes)
                    {
                        if (n.Text.Equals(str))
                            this.tvClientList.Nodes.Remove(n);
                    }
                }
            }
        }

        private void ServerStart_Click(object sender, EventArgs e)
        {
            TcpClient client = default(TcpClient);
            StartServer();
        }
    }

    public class MyEventArgs : EventArgs
    {
        private TcpClient sock;
        public TcpClient clientSock
        {
            get { return sock; }
            set { sock = value; }
        }

        public MyEventArgs(TcpClient tcpClient)
        {
            sock = tcpClient;
        }
    }

    public class Start
    {
        public static void chat(TcpClient client, List<TcpClient> clients)
        {
            NetworkStream netStream = client.GetStream();
            BinaryReader binreader = new BinaryReader(netStream);
            while (true)
            {
                string text = binreader.ReadString();
                for (int i = 0; i < clients.Count; i++)
                {
                    BinaryWriter binwriter = new BinaryWriter(clients[i].GetStream());
                    binwriter.Write(text);
                    binwriter.Flush();
                }
            }
        }
    }
}

