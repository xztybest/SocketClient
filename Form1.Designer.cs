namespace SocketClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.submit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.passport = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.passwordconf = new System.Windows.Forms.TextBox();
            this.listenserve = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // submit
            // 
            this.submit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.submit.Location = new System.Drawing.Point(203, 281);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(89, 31);
            this.submit.TabIndex = 0;
            this.submit.Text = "确认";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(104, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "账号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(104, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(104, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "确认密码";
            // 
            // passport
            // 
            this.passport.Location = new System.Drawing.Point(192, 77);
            this.passport.Name = "passport";
            this.passport.Size = new System.Drawing.Size(143, 21);
            this.passport.TabIndex = 6;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(192, 149);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(143, 21);
            this.password.TabIndex = 8;
            // 
            // passwordconf
            // 
            this.passwordconf.Location = new System.Drawing.Point(192, 213);
            this.passwordconf.Name = "passwordconf";
            this.passwordconf.Size = new System.Drawing.Size(143, 21);
            this.passwordconf.TabIndex = 9;
            // 
            // listenserve
            // 
            this.listenserve.Location = new System.Drawing.Point(81, 281);
            this.listenserve.Name = "listenserve";
            this.listenserve.Size = new System.Drawing.Size(99, 29);
            this.listenserve.TabIndex = 10;
            this.listenserve.Text = "监听服务器消息";
            this.listenserve.UseVisualStyleBackColor = true;
            this.listenserve.Click += new System.EventHandler(this.listenserve_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SocketClient.Properties.Resources.timg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(450, 354);
            this.Controls.Add(this.listenserve);
            this.Controls.Add(this.passwordconf);
            this.Controls.Add(this.password);
            this.Controls.Add(this.passport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.submit);
            this.Name = "Form1";
            this.Text = "客户端";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox passport;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox passwordconf;
        private System.Windows.Forms.Button listenserve;
    }
}