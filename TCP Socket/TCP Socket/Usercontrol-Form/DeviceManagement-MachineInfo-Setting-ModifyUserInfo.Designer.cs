namespace TCP_Socket.Usercontrol_Form
{
    partial class DeviceManagement_MachineInfo_Setting_ModifyUserInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceManagement_MachineInfo_Setting_ModifyUserInfo));
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelListCount = new System.Windows.Forms.Label();
            this.buttonDeleteAll = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelActive = new System.Windows.Forms.Label();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonDo = new System.Windows.Forms.Button();
            this.panelDo = new System.Windows.Forms.Panel();
            this.labelIp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelDo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.labelListCount);
            this.panelTop.Controls.Add(this.buttonDeleteAll);
            this.panelTop.Controls.Add(this.buttonSearch);
            this.panelTop.Controls.Add(this.buttonDelete);
            this.panelTop.Controls.Add(this.buttonAdd);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(420, 29);
            this.panelTop.TabIndex = 0;
            // 
            // labelListCount
            // 
            this.labelListCount.AutoSize = true;
            this.labelListCount.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelListCount.Location = new System.Drawing.Point(296, 7);
            this.labelListCount.Name = "labelListCount";
            this.labelListCount.Size = new System.Drawing.Size(67, 15);
            this.labelListCount.TabIndex = 28;
            this.labelListCount.Text = "名單總數：";
            // 
            // buttonDeleteAll
            // 
            this.buttonDeleteAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDeleteAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonDeleteAll.FlatAppearance.BorderSize = 0;
            this.buttonDeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteAll.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonDeleteAll.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeleteAll.Image")));
            this.buttonDeleteAll.Location = new System.Drawing.Point(180, 0);
            this.buttonDeleteAll.Name = "buttonDeleteAll";
            this.buttonDeleteAll.Size = new System.Drawing.Size(84, 27);
            this.buttonDeleteAll.TabIndex = 3;
            this.buttonDeleteAll.Text = "刪除全部";
            this.buttonDeleteAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDeleteAll.UseVisualStyleBackColor = true;
            this.buttonDeleteAll.Click += new System.EventHandler(this.buttonDeleteAll_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonSearch.FlatAppearance.BorderSize = 0;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonSearch.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearch.Image")));
            this.buttonSearch.Location = new System.Drawing.Point(120, 0);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(60, 27);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "搜尋";
            this.buttonSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Visible = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonDelete.Image = ((System.Drawing.Image)(resources.GetObject("buttonDelete.Image")));
            this.buttonDelete.Location = new System.Drawing.Point(60, 0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(60, 27);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.Text = "刪除";
            this.buttonDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonAdd.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdd.Image")));
            this.buttonAdd.Location = new System.Drawing.Point(0, 0);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(60, 27);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "新增";
            this.buttonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelTitle.Location = new System.Drawing.Point(27, 25);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(38, 19);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "title";
            // 
            // labelActive
            // 
            this.labelActive.AutoSize = true;
            this.labelActive.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelActive.Location = new System.Drawing.Point(28, 104);
            this.labelActive.Name = "labelActive";
            this.labelActive.Size = new System.Drawing.Size(41, 15);
            this.labelActive.TabIndex = 2;
            this.labelActive.Text = "Active";
            // 
            // textBoxInput
            // 
            this.textBoxInput.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxInput.Location = new System.Drawing.Point(31, 131);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(353, 23);
            this.textBoxInput.TabIndex = 3;
            // 
            // buttonDo
            // 
            this.buttonDo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDo.FlatAppearance.BorderSize = 0;
            this.buttonDo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonDo.Location = new System.Drawing.Point(362, 244);
            this.buttonDo.Name = "buttonDo";
            this.buttonDo.Size = new System.Drawing.Size(46, 28);
            this.buttonDo.TabIndex = 27;
            this.buttonDo.Text = "修改";
            this.buttonDo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDo.UseVisualStyleBackColor = true;
            this.buttonDo.Click += new System.EventHandler(this.buttonDo_Click);
            // 
            // panelDo
            // 
            this.panelDo.Controls.Add(this.labelIp);
            this.panelDo.Controls.Add(this.label1);
            this.panelDo.Controls.Add(this.buttonDo);
            this.panelDo.Controls.Add(this.labelTitle);
            this.panelDo.Controls.Add(this.textBoxInput);
            this.panelDo.Controls.Add(this.labelActive);
            this.panelDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDo.Location = new System.Drawing.Point(0, 29);
            this.panelDo.Name = "panelDo";
            this.panelDo.Size = new System.Drawing.Size(420, 284);
            this.panelDo.TabIndex = 28;
            this.panelDo.Visible = false;
            // 
            // labelIp
            // 
            this.labelIp.AutoSize = true;
            this.labelIp.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelIp.Location = new System.Drawing.Point(58, 60);
            this.labelIp.Name = "labelIp";
            this.labelIp.Size = new System.Drawing.Size(100, 15);
            this.labelIp.TabIndex = 29;
            this.labelIp.Text = "000.000.000.000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(32, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 28;
            this.label1.Text = "IP：";
            // 
            // DeviceManagement_MachineInfo_Setting_ModifyUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(420, 313);
            this.Controls.Add(this.panelDo);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeviceManagement_MachineInfo_Setting_ModifyUserInfo";
            this.Text = "DeviceManagement_MachineInfo_Setting_ModifyUserInfo";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelDo.ResumeLayout(false);
            this.panelDo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDeleteAll;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelActive;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonDo;
        private System.Windows.Forms.Panel panelDo;
        private System.Windows.Forms.Label labelListCount;
        private System.Windows.Forms.Label labelIp;
        private System.Windows.Forms.Label label1;
    }
}