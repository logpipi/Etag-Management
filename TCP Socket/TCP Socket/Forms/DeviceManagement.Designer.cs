namespace TCP_Socket.Forms
{
    partial class DeviceManagement
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
            this.buttonControl = new System.Windows.Forms.Button();
            this.buttonConnection = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeft.Controls.Add(this.buttonControl);
            this.panelLeft.Controls.Add(this.buttonConnection);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(126, 450);
            this.panelLeft.TabIndex = 0;
            // 
            // buttonControl
            // 
            this.buttonControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonControl.FlatAppearance.BorderSize = 0;
            this.buttonControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonControl.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonControl.Location = new System.Drawing.Point(0, 28);
            this.buttonControl.Name = "buttonControl";
            this.buttonControl.Size = new System.Drawing.Size(124, 28);
            this.buttonControl.TabIndex = 1;
            this.buttonControl.Text = "控制台";
            this.buttonControl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonControl.UseVisualStyleBackColor = true;
            this.buttonControl.Visible = false;
            this.buttonControl.Click += new System.EventHandler(this.buttonControl_Click);
            // 
            // buttonConnection
            // 
            this.buttonConnection.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonConnection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonConnection.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonConnection.FlatAppearance.BorderSize = 0;
            this.buttonConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConnection.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonConnection.Location = new System.Drawing.Point(0, 0);
            this.buttonConnection.Name = "buttonConnection";
            this.buttonConnection.Size = new System.Drawing.Size(124, 28);
            this.buttonConnection.TabIndex = 0;
            this.buttonConnection.Text = "裝置連線";
            this.buttonConnection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonConnection.UseVisualStyleBackColor = false;
            this.buttonConnection.Click += new System.EventHandler(this.buttonConnection_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(126, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(674, 450);
            this.panelContainer.TabIndex = 2;
            // 
            // DeviceManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelLeft);
            this.Name = "DeviceManagement";
            this.Text = "DeviceManagement";
            this.panelLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button buttonConnection;
        private System.Windows.Forms.Button buttonControl;
        private System.Windows.Forms.Panel panelContainer;
    }
}