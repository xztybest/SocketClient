using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketClient
{
    public partial class MainFrm1 : Form
    {
        List<Socket> ClientProxSocketList = new List<Socket>();
        public Socket ClientSocket { get; set; }
        public MainFrm1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            //创建Socket
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //绑定端口ip
            socket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), int.Parse("2222")));

            //开启监听
            socket.Listen(10);
            //等待链接的队列：同时来了100个链接请求，只能处理一个链接，队列中放10个等待链接的客户端，其他的返回错误消息

            //开始接受客户端的链接
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.AcceptClientConnect), socket);
            Listenserve.Text= "正在监听来自服务器的消息";
            txtLog.Text = txtLog.Text + "\n" + "正在接收来自服务器的消息";
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
                //MessageBox.Show(plainmessage + "," + signmessage + "客户端系统");
                string signdata = funcsum.messagesigncheck(plainmessage, signmessage);
                if (signdata != "1")
                {
                    MessageBox.Show("信息受到第三方篡改，客户端");
                    return;
                }

                


                AppendTextToTxtLog(string.Format("接收到服务器:{0}的回复消息是:{1}", proxSocket.RemoteEndPoint.ToString(), plainmessage));
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
        public void AppendTextToTxtLog(string txt)
        {


            if (txtLog.InvokeRequired)
            {
                txtLog.BeginInvoke(new Action<string>(s =>
                {
                    this.txtLog.Text = string.Format("{0}\r\n{1}", txt, txtLog.Text);
                }), txt);


            }
            else
            {
                this.txtLog.Text = string.Format("{0}\r\n{1}", txt, txtLog.Text);
            }
        }


        private void btbSendMsg_Click(object sender, EventArgs e)
        {
            //************以下为包封装过程
            string passwd = funcsum.AESEnKeyGener();//产生AES加密密钥
            string message = funcsum.AESEncry("0" + "," + txtMsg.Text + "," + "0", passwd);//AES-256加密data数据包
            string signvalue = funcsum.messagesign(txtMsg.Text);//对明文信息进行hash签名
            //string ciphersigvlue = funcsum.RSAEncry(signvalue);//对签名进行信息进行RSA-4096加密
            string passwdcipher = funcsum.RSAEncry(passwd);//对AES解密密钥进行RSA加密
            //string sendpackage = message+","+ passwdcipher+","+ciphersigvlue;//组装发送数据包
            string sendpackage = message + "," + passwdcipher + "," + signvalue;//
            byte[] data = Encoding.UTF8.GetBytes(sendpackage);//将数据包转换成为byte类型，方便传输

            //向服务器端发送返回信息
            Socket sendtoserve= new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            int Port = int.Parse("8888");
            sendtoserve.Connect("127.0.0.1",Port);
            sendtoserve.Send(data, 0, data.Length, SocketFlags.None);//发送数据包
            sendtoserve.Dispose();//释放资源
            sendtoserve.Close();//关闭连接

        }
        

        /*private void StopContnet()
        {
            try
            {
                if (ClientSocket.Connected)
                {
                    ClientSocket.Shutdown(SocketShutdown.Both);
                    ClientSocket.Close(100);
                }
            }
            catch (Exception)
            {

            }
        }*/

        private void MainFrm1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //判断是否已经连接，如果连接那就关闭
            // StopContnet();
            return;
        }
    }
}
