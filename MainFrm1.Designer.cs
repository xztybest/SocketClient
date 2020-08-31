namespace SocketClient
{
    partial class MainFrm1
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
            this.btbSendMsg = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.Listenserve = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btbSendMsg
            // 
            this.btbSendMsg.Location = new System.Drawing.Point(405, 281);
            this.btbSendMsg.Margin = new System.Windows.Forms.Padding(2);
            this.btbSendMsg.Name = "btbSendMsg";
            this.btbSendMsg.Size = new System.Drawing.Size(80, 50);
            this.btbSendMsg.TabIndex = 16;
            this.btbSendMsg.Text = "发送";
            this.btbSendMsg.UseVisualStyleBackColor = true;
            this.btbSendMsg.Click += new System.EventHandler(this.btbSendMsg_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(30, 82);
            this.txtLog.Margin = new System.Windows.Forms.Padding(2);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(455, 181);
            this.txtLog.TabIndex = 14;
            // 
            // Listenserve
            // 
            this.Listenserve.Location = new System.Drawing.Point(134, 26);
            this.Listenserve.Margin = new System.Windows.Forms.Padding(2);
            this.Listenserve.Name = "Listenserve";
            this.Listenserve.Size = new System.Drawing.Size(233, 29);
            this.Listenserve.TabIndex = 9;
            this.Listenserve.Text = "监听服务器消息";
            this.Listenserve.UseVisualStyleBackColor = true;
            this.Listenserve.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(30, 281);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(370, 50);
            this.txtMsg.TabIndex = 17;
            this.txtMsg.Text = "";
            // 
            // MainFrm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SocketClient.Properties.Resources._120200805124327191561;
            this.ClientSize = new System.Drawing.Size(512, 367);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.btbSendMsg);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.Listenserve);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainFrm1";
            this.Text = "客户端";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFrm1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btbSendMsg;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button Listenserve;
        private System.Windows.Forms.RichTextBox txtMsg;
    }
}