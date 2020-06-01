namespace TCP_Socket.Forms
{
    partial class UserManagement
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
            this.panelLeft = new System.Windows.Forms.Panel();
            this.buttonCarManagement = new System.Windows.Forms.Button();
            this.buttonUserInfo = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeft.Controls.Add(this.buttonCarManagement);
            this.panelLeft.Controls.Add(this.buttonUserInfo);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(126, 450);
            this.panelLeft.TabIndex = 1;
            // 
            // buttonCarManagement
            // 
            this.buttonCarManagement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCarManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCarManagement.FlatAppearance.BorderSize = 0;
            this.buttonCarManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCarManagement.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonCarManagement.Location = new System.Drawing.Point(0, 28);
            this.buttonCarManagement.Name = "buttonCarManagement";
            this.buttonCarManagement.Size = new System.Drawing.Size(124, 28);
            this.buttonCarManagement.TabIndex = 1;
            this.buttonCarManagement.Text = "人車管理";
            this.buttonCarManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCarManagement.UseVisualStyleBackColor = true;
            this.buttonCarManagement.Click += new System.EventHandler(this.buttonCarManagement_Click);
            // 
            // buttonUserInfo
            // 
            this.buttonUserInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonUserInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUserInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonUserInfo.FlatAppearance.BorderSize = 0;
            this.buttonUserInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUserInfo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonUserInfo.Location = new System.Drawing.Point(0, 0);
            this.buttonUserInfo.Name = "buttonUserInfo";
            this.buttonUserInfo.Size = new System.Drawing.Size(124, 28);
            this.buttonUserInfo.TabIndex = 0;
            this.buttonUserInfo.Text = "及時進出紀錄";
            this.buttonUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUserInfo.UseVisualStyleBackColor = false;
            this.buttonUserInfo.Click += new System.EventHandler(this.buttonUserInfo_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(126, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(674, 450);
            this.panelContainer.TabIndex = 2;
            // 
            // UserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelLeft);
            this.Name = "UserManagement";
            this.Text = "UserManagement";
            this.Load += new System.EventHandler(this.UserManagement_Load);
            this.panelLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button buttonCarManagement;
        private System.Windows.Forms.Button buttonUserInfo;
        private System.Windows.Forms.Panel panelContainer;
    }
}