using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketClient
{
    public partial class app1 : Form
    {
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
            string message1 = passport.Text.Trim();//获取账号用户名
            string message2 = password.Text.Trim();//获取密码
            Form f3 = new MainFrm1();
            f3.Show();

        }
    }
}
