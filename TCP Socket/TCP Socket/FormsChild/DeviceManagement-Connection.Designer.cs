namespace TCP_Socket.FormsChild
{
    partial class DeviceManagement_Connection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceManagement_Connection));
            this.panelDown = new System.Windows.Forms.Panel();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelLog = new System.Windows.Forms.Panel();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.buttonSearchIP = new System.Windows.Forms.Button();
            this.buttonSchoolTime = new System.Windows.Forms.Button();
            this.panelDown.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.panelLog.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDown
            // 
            this.panelDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDown.Controls.Add(this.panelContainer);
            this.panelDown.Controls.Add(this.panelTop);
            this.panelDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDown.Location = new System.Drawing.Point(0, 0);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(800, 450);
            this.panelDown.TabIndex = 0;
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.panelLog);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 50);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(798, 398);
            this.panelContainer.TabIndex = 1;
            // 
            // panelLog
            // 
            this.panelLog.Controls.Add(this.textBoxLog);
            this.panelLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLog.Location = new System.Drawing.Point(0, 376);
            this.panelLog.Name = "panelLog";
            this.panelLog.Size = new System.Drawing.Size(798, 22);
            this.panelLog.TabIndex = 0;
            // 
            // textBoxLog
            // 
            this.textBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLog.Location = new System.Drawing.Point(0, 0);
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(798, 22);
            this.textBoxLog.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.buttonSchoolTime);
            this.panelTop.Controls.Add(this.buttonSearchIP);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(798, 50);
            this.panelTop.TabIndex = 0;
            // 
            // buttonSearchIP
            // 
            this.buttonSearchIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSearchIP.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonSearchIP.FlatAppearance.BorderSize = 0;
            this.buttonSearchIP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchIP.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonSearchIP.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearchIP.Image")));
            this.buttonSearchIP.Location = new System.Drawing.Point(0, 0);
            this.buttonSearchIP.Name = "buttonSearchIP";
            this.buttonSearchIP.Size = new System.Drawing.Size(62, 50);
            this.buttonSearchIP.TabIndex = 0;
            this.buttonSearchIP.Text = "搜尋裝置";
            this.buttonSearchIP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSearchIP.UseVisualStyleBackColor = true;
            this.buttonSearchIP.Click += new System.EventHandler(this.buttonSearchIP_Click);
            // 
            // buttonSchoolTime
            // 
            this.buttonSchoolTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSchoolTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonSchoolTime.FlatAppearance.BorderSize = 0;
            this.buttonSchoolTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSchoolTime.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonSchoolTime.Image = ((System.Drawing.Image)(resources.GetObject("buttonSchoolTime.Image")));
            this.buttonSchoolTime.Location = new System.Drawing.Point(62, 0);
            this.buttonSchoolTime.Name = "buttonSchoolTime";
            this.buttonSchoolTime.Size = new System.Drawing.Size(62, 50);
            this.buttonSchoolTime.TabIndex = 1;
            this.buttonSchoolTime.Text = "調教時間";
            this.buttonSchoolTime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSchoolTime.UseVisualStyleBackColor = true;
            this.buttonSchoolTime.Click += new System.EventHandler(this.buttonSchoolTime_Click);
            // 
            // DeviceManagement_Connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelDown);
            this.Name = "DeviceManagement_Connection";
            this.Text = "DeviceManagement_Connection";
            this.panelDown.ResumeLayout(false);
            this.panelContainer.ResumeLayout(false);
            this.panelLog.ResumeLayout(false);
            this.panelLog.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDown;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button buttonSearchIP;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panelLog;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button buttonSchoolTime;
    }
}