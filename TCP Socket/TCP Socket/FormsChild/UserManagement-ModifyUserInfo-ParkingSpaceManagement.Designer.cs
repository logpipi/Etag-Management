namespace TCP_Socket.FormsChild
{
    partial class UserManagement_ModifyUserInfo_ParkingSpaceManagement
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManagement_ModifyUserInfo_ParkingSpaceManagement));
            this.panelModifyArea = new System.Windows.Forms.Panel();
            this.listViewShow = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RightClickUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClickDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTop = new System.Windows.Forms.Panel();
            this.buttonRe = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.labelEmptyTextbox = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSearchText = new System.Windows.Forms.TextBox();
            this.comboBoxSelection = new System.Windows.Forms.ComboBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panelModifyArea.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelModifyArea
            // 
            this.panelModifyArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelModifyArea.Controls.Add(this.listViewShow);
            this.panelModifyArea.Controls.Add(this.panelTop);
            this.panelModifyArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelModifyArea.Location = new System.Drawing.Point(0, 0);
            this.panelModifyArea.Name = "panelModifyArea";
            this.panelModifyArea.Size = new System.Drawing.Size(800, 450);
            this.panelModifyArea.TabIndex = 1;
            // 
            // listViewShow
            // 
            this.listViewShow.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewShow.HideSelection = false;
            this.listViewShow.Location = new System.Drawing.Point(0, 34);
            this.listViewShow.Name = "listViewShow";
            this.listViewShow.Size = new System.Drawing.Size(798, 414);
            this.listViewShow.TabIndex = 1;
            this.listViewShow.UseCompatibleStateImageBehavior = false;
            this.listViewShow.View = System.Windows.Forms.View.Details;
            this.listViewShow.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewShow_ItemSelectionChanged);
            this.listViewShow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewShow_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RightClickUpdate,
            this.RightClickDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 48);
            // 
            // RightClickUpdate
            // 
            this.RightClickUpdate.Image = ((System.Drawing.Image)(resources.GetObject("RightClickUpdate.Image")));
            this.RightClickUpdate.Name = "RightClickUpdate";
            this.RightClickUpdate.Size = new System.Drawing.Size(98, 22);
            this.RightClickUpdate.Text = "修改";
            this.RightClickUpdate.Click += new System.EventHandler(this.RightClickUpdate_Click);
            // 
            // RightClickDelete
            // 
            this.RightClickDelete.Image = ((System.Drawing.Image)(resources.GetObject("RightClickDelete.Image")));
            this.RightClickDelete.Name = "RightClickDelete";
            this.RightClickDelete.Size = new System.Drawing.Size(98, 22);
            this.RightClickDelete.Text = "刪除";
            this.RightClickDelete.Click += new System.EventHandler(this.RightClickDelete_Click);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.buttonRe);
            this.panelTop.Controls.Add(this.panel1);
            this.panelTop.Controls.Add(this.buttonAdd);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(798, 34);
            this.panelTop.TabIndex = 0;
            // 
            // buttonRe
            // 
            this.buttonRe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRe.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonRe.FlatAppearance.BorderSize = 0;
            this.buttonRe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRe.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonRe.Image = ((System.Drawing.Image)(resources.GetObject("buttonRe.Image")));
            this.buttonRe.Location = new System.Drawing.Point(63, 0);
            this.buttonRe.Name = "buttonRe";
            this.buttonRe.Size = new System.Drawing.Size(63, 34);
            this.buttonRe.TabIndex = 4;
            this.buttonRe.Text = "重整";
            this.buttonRe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonRe.UseVisualStyleBackColor = true;
            this.buttonRe.Click += new System.EventHandler(this.buttonRe_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSearch);
            this.panel1.Controls.Add(this.labelEmptyTextbox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxSearchText);
            this.panel1.Controls.Add(this.comboBoxSelection);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(340, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(458, 34);
            this.panel1.TabIndex = 3;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSearch.FlatAppearance.BorderSize = 0;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearch.Image")));
            this.buttonSearch.Location = new System.Drawing.Point(436, 0);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(22, 34);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // labelEmptyTextbox
            // 
            this.labelEmptyTextbox.AutoSize = true;
            this.labelEmptyTextbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEmptyTextbox.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelEmptyTextbox.Location = new System.Drawing.Point(413, 9);
            this.labelEmptyTextbox.Name = "labelEmptyTextbox";
            this.labelEmptyTextbox.Size = new System.Drawing.Size(17, 17);
            this.labelEmptyTextbox.TabIndex = 4;
            this.labelEmptyTextbox.Text = "X";
            this.labelEmptyTextbox.Click += new System.EventHandler(this.labelEmptyTextbox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "搜尋：";
            // 
            // textBoxSearchText
            // 
            this.textBoxSearchText.BackColor = System.Drawing.Color.White;
            this.textBoxSearchText.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxSearchText.Location = new System.Drawing.Point(153, 6);
            this.textBoxSearchText.Name = "textBoxSearchText";
            this.textBoxSearchText.Size = new System.Drawing.Size(278, 23);
            this.textBoxSearchText.TabIndex = 2;
            this.textBoxSearchText.TextChanged += new System.EventHandler(this.textBoxSearchText_TextChanged);
            this.textBoxSearchText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearchText_KeyDown);
            // 
            // comboBoxSelection
            // 
            this.comboBoxSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelection.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBoxSelection.FormattingEnabled = true;
            this.comboBoxSelection.Items.AddRange(new object[] {
            "卡號",
            "車牌",
            "車主",
            "車位族群"});
            this.comboBoxSelection.Location = new System.Drawing.Point(66, 6);
            this.comboBoxSelection.Name = "comboBoxSelection";
            this.comboBoxSelection.Size = new System.Drawing.Size(81, 23);
            this.comboBoxSelection.TabIndex = 1;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonAdd.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdd.Image")));
            this.buttonAdd.Location = new System.Drawing.Point(0, 0);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(63, 34);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "新增";
            this.buttonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // UserManagement_ModifyUserInfo_ParkingSpaceManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelModifyArea);
            this.Name = "UserManagement_ModifyUserInfo_ParkingSpaceManagement";
            this.Text = "UserManagement_ModifyUserInfo_ParkingSpaceManagement";
            this.Load += new System.EventHandler(this.UserManagement_ModifyUserInfo_ParkingSpaceManagement_Load);
            this.panelModifyArea.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelModifyArea;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label labelEmptyTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSearchText;
        private System.Windows.Forms.ComboBox comboBoxSelection;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ListView listViewShow;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem RightClickUpdate;
        private System.Windows.Forms.ToolStripMenuItem RightClickDelete;
        private System.Windows.Forms.Button buttonRe;
    }
}