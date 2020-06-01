namespace TCP_Socket.Usercontrol_Form
{
    partial class DeviceManagement_MachineInfo_Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceManagement_MachineInfo_Setting));
            this.panelDown = new System.Windows.Forms.Panel();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelTop1 = new System.Windows.Forms.Panel();
            this.buttonTime = new System.Windows.Forms.Button();
            this.buttonAccessControl = new System.Windows.Forms.Button();
            this.buttonModifyUser = new System.Windows.Forms.Button();
            this.buttonModifyNet = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelMachine = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelDown.SuspendLayout();
            this.panelTop1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDown
            // 
            this.panelDown.BackColor = System.Drawing.Color.White;
            this.panelDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDown.Controls.Add(this.panelContainer);
            this.panelDown.Controls.Add(this.panelTop1);
            this.panelDown.Controls.Add(this.panelTop);
            this.panelDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDown.Location = new System.Drawing.Point(0, 0);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(454, 375);
            this.panelDown.TabIndex = 0;
            // 
            // panelContainer
            // 
            this.panelContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 68);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(452, 305);
            this.panelContainer.TabIndex = 2;
            // 
            // panelTop1
            // 
            this.panelTop1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop1.Controls.Add(this.buttonTime);
            this.panelTop1.Controls.Add(this.buttonAccessControl);
            this.panelTop1.Controls.Add(this.buttonModifyUser);
            this.panelTop1.Controls.Add(this.buttonModifyNet);
            this.panelTop1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop1.Location = new System.Drawing.Point(0, 30);
            this.panelTop1.Name = "panelTop1";
            this.panelTop1.Size = new System.Drawing.Size(452, 38);
            this.panelTop1.TabIndex = 1;
            // 
            // buttonTime
            // 
            this.buttonTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonTime.FlatAppearance.BorderSize = 0;
            this.buttonTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTime.Image = ((System.Drawing.Image)(resources.GetObject("buttonTime.Image")));
            this.buttonTime.Location = new System.Drawing.Point(248, 0);
            this.buttonTime.Name = "buttonTime";
            this.buttonTime.Size = new System.Drawing.Size(57, 36);
            this.buttonTime.TabIndex = 3;
            this.buttonTime.Text = "校時";
            this.buttonTime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonTime.UseVisualStyleBackColor = true;
            this.buttonTime.Visible = false;
            this.buttonTime.Click += new System.EventHandler(this.buttonTime_Click);
            // 
            // buttonAccessControl
            // 
            this.buttonAccessControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAccessControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonAccessControl.FlatAppearance.BorderSize = 0;
            this.buttonAccessControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAccessControl.Image = ((System.Drawing.Image)(resources.GetObject("buttonAccessControl.Image")));
            this.buttonAccessControl.Location = new System.Drawing.Point(156, 0);
            this.buttonAccessControl.Name = "buttonAccessControl";
            this.buttonAccessControl.Size = new System.Drawing.Size(92, 36);
            this.buttonAccessControl.TabIndex = 2;
            this.buttonAccessControl.Text = "控制器管理";
            this.buttonAccessControl.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAccessControl.UseVisualStyleBackColor = true;
            this.buttonAccessControl.Click += new System.EventHandler(this.buttonAccessControl_Click);
            // 
            // buttonModifyUser
            // 
            this.buttonModifyUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonModifyUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonModifyUser.FlatAppearance.BorderSize = 0;
            this.buttonModifyUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModifyUser.Image = ((System.Drawing.Image)(resources.GetObject("buttonModifyUser.Image")));
            this.buttonModifyUser.Location = new System.Drawing.Point(78, 0);
            this.buttonModifyUser.Name = "buttonModifyUser";
            this.buttonModifyUser.Size = new System.Drawing.Size(78, 36);
            this.buttonModifyUser.TabIndex = 1;
            this.buttonModifyUser.Text = "名單管理";
            this.buttonModifyUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonModifyUser.UseVisualStyleBackColor = true;
            this.buttonModifyUser.Visible = false;
            this.buttonModifyUser.Click += new System.EventHandler(this.buttonModifyUser_Click);
            // 
            // buttonModifyNet
            // 
            this.buttonModifyNet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonModifyNet.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonModifyNet.FlatAppearance.BorderSize = 0;
            this.buttonModifyNet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModifyNet.Image = ((System.Drawing.Image)(resources.GetObject("buttonModifyNet.Image")));
            this.buttonModifyNet.Location = new System.Drawing.Point(0, 0);
            this.buttonModifyNet.Name = "buttonModifyNet";
            this.buttonModifyNet.Size = new System.Drawing.Size(78, 36);
            this.buttonModifyNet.TabIndex = 0;
            this.buttonModifyNet.Text = "網路管理";
            this.buttonModifyNet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonModifyNet.UseVisualStyleBackColor = true;
            this.buttonModifyNet.Click += new System.EventHandler(this.buttonModifyNet_Click);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.panelTop.Controls.Add(this.labelAddress);
            this.panelTop.Controls.Add(this.labelMachine);
            this.panelTop.Controls.Add(this.buttonClose);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(452, 30);
            this.panelTop.TabIndex = 0;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDown);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseMove);
            this.panelTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseUp);
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelAddress.ForeColor = System.Drawing.Color.White;
            this.labelAddress.Location = new System.Drawing.Point(77, 9);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(31, 12);
            this.labelAddress.TabIndex = 6;
            this.labelAddress.Text = "設定";
            // 
            // labelMachine
            // 
            this.labelMachine.AutoSize = true;
            this.labelMachine.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelMachine.ForeColor = System.Drawing.Color.White;
            this.labelMachine.Location = new System.Drawing.Point(10, 9);
            this.labelMachine.Name = "labelMachine";
            this.labelMachine.Size = new System.Drawing.Size(31, 12);
            this.labelMachine.TabIndex = 5;
            this.labelMachine.Text = "設定";
            // 
            // buttonClose
            // 
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(419, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(33, 30);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // DeviceManagement_MachineInfo_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 375);
            this.Controls.Add(this.panelDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeviceManagement_MachineInfo_Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "設定";
            this.panelDown.ResumeLayout(false);
            this.panelTop1.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDown;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelMachine;
        private System.Windows.Forms.Panel panelTop1;
        private System.Windows.Forms.Button buttonModifyNet;
        private System.Windows.Forms.Button buttonModifyUser;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button buttonTime;
        private System.Windows.Forms.Button buttonAccessControl;
        private System.Windows.Forms.Label labelAddress;
    }
}