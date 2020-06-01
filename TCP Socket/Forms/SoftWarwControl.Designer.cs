namespace TCP_Socket.Forms
{
    partial class SoftWarwControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoftWarwControl));
            this.panelDown = new System.Windows.Forms.Panel();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.panelBelow = new System.Windows.Forms.Panel();
            this.buttonError = new System.Windows.Forms.Button();
            this.comboBoxMachine = new System.Windows.Forms.ComboBox();
            this.buttonOpenDoor = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonDeleteTextbox = new System.Windows.Forms.Button();
            this.buttonCloseControl = new System.Windows.Forms.Button();
            this.buttonOpenControls = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.panelDown.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.panelBelow.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDown
            // 
            this.panelDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDown.Controls.Add(this.panelContainer);
            this.panelDown.Controls.Add(this.panelBelow);
            this.panelDown.Controls.Add(this.panel1);
            this.panelDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDown.Location = new System.Drawing.Point(0, 0);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(800, 450);
            this.panelDown.TabIndex = 0;
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.textBoxLog);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 33);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(798, 380);
            this.panelContainer.TabIndex = 2;
            // 
            // textBoxLog
            // 
            this.textBoxLog.AllowDrop = true;
            this.textBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLog.Location = new System.Drawing.Point(0, 0);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.Size = new System.Drawing.Size(798, 380);
            this.textBoxLog.TabIndex = 0;
            // 
            // panelBelow
            // 
            this.panelBelow.Controls.Add(this.buttonError);
            this.panelBelow.Controls.Add(this.comboBoxMachine);
            this.panelBelow.Controls.Add(this.buttonOpenDoor);
            this.panelBelow.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBelow.Location = new System.Drawing.Point(0, 413);
            this.panelBelow.Name = "panelBelow";
            this.panelBelow.Size = new System.Drawing.Size(798, 35);
            this.panelBelow.TabIndex = 1;
            // 
            // buttonError
            // 
            this.buttonError.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.buttonError.FlatAppearance.BorderSize = 0;
            this.buttonError.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.buttonError.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.buttonError.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonError.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonError.Image = ((System.Drawing.Image)(resources.GetObject("buttonError.Image")));
            this.buttonError.Location = new System.Drawing.Point(256, 5);
            this.buttonError.Name = "buttonError";
            this.buttonError.Size = new System.Drawing.Size(78, 25);
            this.buttonError.TabIndex = 4;
            this.buttonError.Text = "未選擇";
            this.buttonError.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonError.UseVisualStyleBackColor = true;
            this.buttonError.Visible = false;
            // 
            // comboBoxMachine
            // 
            this.comboBoxMachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMachine.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBoxMachine.FormattingEnabled = true;
            this.comboBoxMachine.Location = new System.Drawing.Point(65, 6);
            this.comboBoxMachine.Name = "comboBoxMachine";
            this.comboBoxMachine.Size = new System.Drawing.Size(185, 23);
            this.comboBoxMachine.TabIndex = 3;
            // 
            // buttonOpenDoor
            // 
            this.buttonOpenDoor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOpenDoor.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonOpenDoor.FlatAppearance.BorderSize = 0;
            this.buttonOpenDoor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenDoor.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonOpenDoor.Image = ((System.Drawing.Image)(resources.GetObject("buttonOpenDoor.Image")));
            this.buttonOpenDoor.Location = new System.Drawing.Point(0, 0);
            this.buttonOpenDoor.Name = "buttonOpenDoor";
            this.buttonOpenDoor.Size = new System.Drawing.Size(60, 35);
            this.buttonOpenDoor.TabIndex = 2;
            this.buttonOpenDoor.Text = "開門";
            this.buttonOpenDoor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOpenDoor.UseVisualStyleBackColor = true;
            this.buttonOpenDoor.Click += new System.EventHandler(this.buttonOpenDoor_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelError);
            this.panel1.Controls.Add(this.buttonDeleteTextbox);
            this.panel1.Controls.Add(this.buttonCloseControl);
            this.panel1.Controls.Add(this.buttonOpenControls);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 33);
            this.panel1.TabIndex = 0;
            // 
            // buttonDeleteTextbox
            // 
            this.buttonDeleteTextbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDeleteTextbox.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonDeleteTextbox.FlatAppearance.BorderSize = 0;
            this.buttonDeleteTextbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteTextbox.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonDeleteTextbox.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeleteTextbox.Image")));
            this.buttonDeleteTextbox.Location = new System.Drawing.Point(211, 0);
            this.buttonDeleteTextbox.Name = "buttonDeleteTextbox";
            this.buttonDeleteTextbox.Size = new System.Drawing.Size(59, 33);
            this.buttonDeleteTextbox.TabIndex = 2;
            this.buttonDeleteTextbox.Text = "刪除";
            this.buttonDeleteTextbox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDeleteTextbox.UseVisualStyleBackColor = true;
            this.buttonDeleteTextbox.Click += new System.EventHandler(this.buttonDeleteTextbox_Click);
            // 
            // buttonCloseControl
            // 
            this.buttonCloseControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCloseControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonCloseControl.Enabled = false;
            this.buttonCloseControl.FlatAppearance.BorderSize = 0;
            this.buttonCloseControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCloseControl.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonCloseControl.Image = ((System.Drawing.Image)(resources.GetObject("buttonCloseControl.Image")));
            this.buttonCloseControl.Location = new System.Drawing.Point(108, 0);
            this.buttonCloseControl.Name = "buttonCloseControl";
            this.buttonCloseControl.Size = new System.Drawing.Size(103, 33);
            this.buttonCloseControl.TabIndex = 1;
            this.buttonCloseControl.Text = "關閉軟體控制";
            this.buttonCloseControl.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCloseControl.UseVisualStyleBackColor = true;
            this.buttonCloseControl.Click += new System.EventHandler(this.buttonCloseControl_Click);
            // 
            // buttonOpenControls
            // 
            this.buttonOpenControls.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOpenControls.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonOpenControls.FlatAppearance.BorderSize = 0;
            this.buttonOpenControls.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenControls.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonOpenControls.Image = ((System.Drawing.Image)(resources.GetObject("buttonOpenControls.Image")));
            this.buttonOpenControls.Location = new System.Drawing.Point(0, 0);
            this.buttonOpenControls.Name = "buttonOpenControls";
            this.buttonOpenControls.Size = new System.Drawing.Size(108, 33);
            this.buttonOpenControls.TabIndex = 0;
            this.buttonOpenControls.Text = "開啟軟體控制";
            this.buttonOpenControls.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOpenControls.UseVisualStyleBackColor = true;
            this.buttonOpenControls.Click += new System.EventHandler(this.buttonOpenControls_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(276, 8);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(99, 17);
            this.labelError.TabIndex = 4;
            this.labelError.Text = "無符合的設備。";
            this.labelError.Visible = false;
            // 
            // SoftWarwControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelDown);
            this.Name = "SoftWarwControl";
            this.Text = "SoftWarwControl";
            this.panelDown.ResumeLayout(false);
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.panelBelow.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDown;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCloseControl;
        private System.Windows.Forms.Button buttonOpenControls;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panelBelow;
        private System.Windows.Forms.Button buttonOpenDoor;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button buttonDeleteTextbox;
        private System.Windows.Forms.ComboBox comboBoxMachine;
        private System.Windows.Forms.Button buttonError;
        private System.Windows.Forms.Label labelError;
    }
}