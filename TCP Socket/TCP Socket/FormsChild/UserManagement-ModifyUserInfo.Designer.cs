namespace TCP_Socket.FormsChild
{
    partial class UserManagement_ModifyUserInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManagement_ModifyUserInfo));
            this.panelDown = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.buttonLP = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelDown.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDown
            // 
            this.panelDown.Controls.Add(this.panelContainer);
            this.panelDown.Controls.Add(this.panelTop);
            this.panelDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDown.Location = new System.Drawing.Point(0, 0);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(800, 450);
            this.panelDown.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.button1);
            this.panelTop.Controls.Add(this.buttonLP);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 31);
            this.panelTop.TabIndex = 0;
            // 
            // buttonLP
            // 
            this.buttonLP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLP.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonLP.FlatAppearance.BorderSize = 0;
            this.buttonLP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLP.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonLP.Image = ((System.Drawing.Image)(resources.GetObject("buttonLP.Image")));
            this.buttonLP.Location = new System.Drawing.Point(0, 0);
            this.buttonLP.Name = "buttonLP";
            this.buttonLP.Size = new System.Drawing.Size(84, 31);
            this.buttonLP.TabIndex = 0;
            this.buttonLP.Text = "車牌管理";
            this.buttonLP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonLP.UseVisualStyleBackColor = true;
            this.buttonLP.Click += new System.EventHandler(this.buttonLP_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(84, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "車位管理";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 31);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(800, 419);
            this.panelContainer.TabIndex = 1;
            // 
            // UserManagement_ModifyUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelDown);
            this.Name = "UserManagement_ModifyUserInfo";
            this.Text = "UserManagement_ModifyUserInfo";
            this.Load += new System.EventHandler(this.UserManagement_ModifyUserInfo_Load);
            this.panelDown.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDown;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button buttonLP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelContainer;
    }
}