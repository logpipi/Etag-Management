namespace TCP_Socket.Usercontrol_Form
{
    partial class DeviceManagement_MachineInfo_Setting_ModifyIP_M_G
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceManagement_MachineInfo_Setting_ModifyIP_M_G));
            this.buttonModify = new System.Windows.Forms.Button();
            this.textBoxmN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelIP = new System.Windows.Forms.Label();
            this.panelDown = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ipTextboxMask = new TCP_Socket.Usercontrol_Form.IpTextbox();
            this.ipTextboxGateway = new TCP_Socket.Usercontrol_Form.IpTextbox();
            this.ipTextboxIP = new TCP_Socket.Usercontrol_Form.IpTextbox();
            this.panelDown.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonModify
            // 
            this.buttonModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonModify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonModify.FlatAppearance.BorderSize = 0;
            this.buttonModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModify.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonModify.Location = new System.Drawing.Point(354, 273);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(54, 28);
            this.buttonModify.TabIndex = 26;
            this.buttonModify.Text = "修改";
            this.buttonModify.UseVisualStyleBackColor = true;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // textBoxmN
            // 
            this.textBoxmN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxmN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxmN.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxmN.Location = new System.Drawing.Point(159, 105);
            this.textBoxmN.Name = "textBoxmN";
            this.textBoxmN.Size = new System.Drawing.Size(64, 17);
            this.textBoxmN.TabIndex = 25;
            this.textBoxmN.Text = "0000";
            this.textBoxmN.TextChanged += new System.EventHandler(this.textBoxmN_TextChanged);
            this.textBoxmN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxmN_KeyPress);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(41, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 21;
            this.label6.Text = "更改機碼：";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(41, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "更改網路遮罩：";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(41, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "更改預設閘道：";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(41, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "更改IP：";
            // 
            // labelIP
            // 
            this.labelIP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelIP.AutoSize = true;
            this.labelIP.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelIP.ForeColor = System.Drawing.Color.Gray;
            this.labelIP.Location = new System.Drawing.Point(41, 61);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(17, 15);
            this.labelIP.TabIndex = 17;
            this.labelIP.Text = "IP";
            // 
            // panelDown
            // 
            this.panelDown.Controls.Add(this.label1);
            this.panelDown.Controls.Add(this.buttonModify);
            this.panelDown.Controls.Add(this.labelIP);
            this.panelDown.Controls.Add(this.textBoxmN);
            this.panelDown.Controls.Add(this.label3);
            this.panelDown.Controls.Add(this.ipTextboxMask);
            this.panelDown.Controls.Add(this.label4);
            this.panelDown.Controls.Add(this.ipTextboxGateway);
            this.panelDown.Controls.Add(this.label5);
            this.panelDown.Controls.Add(this.ipTextboxIP);
            this.panelDown.Controls.Add(this.label6);
            this.panelDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDown.Location = new System.Drawing.Point(0, 0);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(420, 313);
            this.panelDown.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(40, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 27;
            this.label1.Text = "網路設定：";
            // 
            // ipTextboxMask
            // 
            this.ipTextboxMask.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ipTextboxMask.BackColor = System.Drawing.Color.White;
            this.ipTextboxMask.Location = new System.Drawing.Point(156, 208);
            this.ipTextboxMask.Name = "ipTextboxMask";
            this.ipTextboxMask.Size = new System.Drawing.Size(212, 29);
            this.ipTextboxMask.TabIndex = 24;
            // 
            // ipTextboxGateway
            // 
            this.ipTextboxGateway.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ipTextboxGateway.BackColor = System.Drawing.Color.White;
            this.ipTextboxGateway.Location = new System.Drawing.Point(156, 171);
            this.ipTextboxGateway.Name = "ipTextboxGateway";
            this.ipTextboxGateway.Size = new System.Drawing.Size(212, 29);
            this.ipTextboxGateway.TabIndex = 23;
            // 
            // ipTextboxIP
            // 
            this.ipTextboxIP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ipTextboxIP.BackColor = System.Drawing.Color.White;
            this.ipTextboxIP.Location = new System.Drawing.Point(156, 134);
            this.ipTextboxIP.Name = "ipTextboxIP";
            this.ipTextboxIP.Size = new System.Drawing.Size(212, 29);
            this.ipTextboxIP.TabIndex = 22;
            // 
            // DeviceManagement_MachineInfo_Setting_ModifyIP_M_G
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(420, 313);
            this.Controls.Add(this.panelDown);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeviceManagement_MachineInfo_Setting_ModifyIP_M_G";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeviceManagement_MachineInfo_Setting_ModifyIP_M_G";
            this.panelDown.ResumeLayout(false);
            this.panelDown.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonModify;
        private System.Windows.Forms.TextBox textBoxmN;
        private IpTextbox ipTextboxMask;
        private IpTextbox ipTextboxGateway;
        private IpTextbox ipTextboxIP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Panel panelDown;
        private System.Windows.Forms.Label label1;
    }
}