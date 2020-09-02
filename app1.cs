using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SocketClient
{
    public partial class app1 : Form
    {
        List<Socket> ClientProxSocketList = new List<Socket>();
        public Socket ClientSocket { get; set; }
        public app1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f2 = new Form1();
            f2.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = passport.Text.Trim();//获取账号用户名
            string userpass = password.Text.Trim();//获取密码
            string plaindata = username + ";" + userpass;
            string aespassword = funcsum.AESEnKeyGener();
            string message = funcsum.AESEncry("2" + "," + plaindata + "," + "0", aespassword);
            string signvalue = funcsum.messagesign(plaindata);
            string passwordcipher = funcsum.RSAEncry(aespassword);
            string sendpackage = message + "," + passwordcipher + "," + signvalue;
            byte[] senddata = Encoding.UTF8.GetBytes(sendpackage);

            Socket sendsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            int Port = int.Parse("8888");
            string ipaddress = "127.0.0.1";
            sendsocket.Connect(ipaddress, Port);
            sendsocket.Send(senddata, 0, senddata.Length, SocketFlags.None);
            sendsocket.Close();

            //Form f3 = new MainFrm1();
            //f3.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //创建Socket
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //绑定端口ip
            socket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), int.Parse("3333")));

            //开启监听
            socket.Listen(10);
            //等待链接的队列：同时来了100个链接请求，只能处理一个链接，队列中放10个等待链接的客户端，其他的返回错误消息

            //开始接受客户端的链接
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.AcceptClientConnect), socket);
        }
        public void AcceptClientConnect(object socket)
        {
            var serverSocket = socket as Socket;

            while (true)
            {
                var proxSocket = serverSocket.Accept();

                //this.AppendTextToTxtLog(string.Format("客户端:{0}链接上了", proxSocket.RemoteEndPoint.ToString()));

                ClientProxSocketList.Add(proxSocket);

                //不停的接受当前链接的客户端发送的消息
                //proxSocket.Receive()
                ThreadPool.QueueUserWorkItem(new WaitCallback(ReceiveData), proxSocket);

            }

        }
        public void ReceiveData(object socket)
        {
            var proxSocket = socket as Socket;
            byte[] data = new byte[1024 * 1024];
            while (true)
            {
                int len = 0;
                try
                {
                    len = proxSocket.Receive(data, 0, data.Length, SocketFlags.None);
                }
                catch (Exception)
                {
                    //异常退出
                    //AppendTextToTxtLog(string.Format("客户端:{0}非正常退出", proxSocket.RemoteEndPoint.ToString()));
                    ClientProxSocketList.Remove(proxSocket);

                    StopConntect(proxSocket);

                    return;
                }

                if (len <= 0)
                {
                    //接收服务器段消息
                    // AppendTextToTxtLog(string.Format("客户端:{0}正常退出", proxSocket.RemoteEndPoint.ToString()));

                    ClientProxSocketList.Remove(proxSocket);

                    StopConntect(proxSocket);
                    return;//让方法结束，终结当前客户端数据的异步线程。

                }
                //把接收到的数据放到文本框上去
                string str = Encoding.Default.GetString(data, 0, len);
                string[] packagediv = str.Split(',');//切割整个数据包
                string AESmessage = packagediv[0];//获取AES加密段
                string RSAmessage = packagediv[1];//获取RSA加密段
                string signmessage = packagediv[2];//得到加密的签名信息
                //string signvaluemessage = funcsum.RSADecry(ciphersignmessage);//解密得到签名value

                string AESkey = funcsum.RSADecry(RSAmessage);//解密RSA获得AESkey
                string AESmessagediv = funcsum.AESDecry(AESmessage, AESkey);//通过AESkey解密AES加密段
                string[] AESfundiv = AESmessagediv.Split(',');//切割AES数据包
                string Funid = AESfundiv[0];//获得功能编号
                string plainmessage = AESfundiv[1];//获得明文数据信息
                

                string funback = AESfundiv[2];//获得返回值判断信息
                //MessageBox.Show(Funid+";"+funback);
                string signdata = funcsum.messagesigncheck(plainmessage, signmessage);
                if (signdata != "1")
                {
                    MessageBox.Show("信息受到第三方篡改，客户端");
                    return;
                }
                if(Funid=="2" && funback=="1")
                {
                    Form loginform = new MainFrm1();
                    //this.Close();
                    new System.Threading.Thread(() =>
                    {
                        Application.Run(loginform);
                    }
                    ).Start();
                    
                    

                }
                else
                {
                    MessageBox.Show("客户端响应:登录失败，用户名或者密码错误");
                }


                //输出消息
                //AppendTextToTxtLog(string.Format("接收到服务器:{0}的回复消息是:{1}", proxSocket.RemoteEndPoint.ToString(), plainmessage));
            }
        }
        private void StopConntect(Socket proxSocket)
        {
            try
            {
                if (proxSocket.Connected)
                {
                    proxSocket.Shutdown(SocketShutdown.Both);
                    proxSocket.Close(100);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
