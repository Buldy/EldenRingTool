
namespace Elden_Ring_Tool {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.xMark = new System.Windows.Forms.PictureBox();
            this.mapBox = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvBossList = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvWpn = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvFlask = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.cbMonitor = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBossList)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWpn)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlask)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.xMark);
            this.panel1.Controls.Add(this.mapBox);
            this.panel1.Location = new System.Drawing.Point(793, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1115, 1056);
            this.panel1.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1037, 1030);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Quit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // xMark
            // 
            this.xMark.BackColor = System.Drawing.Color.Transparent;
            this.xMark.Location = new System.Drawing.Point(253, 644);
            this.xMark.Name = "xMark";
            this.xMark.Size = new System.Drawing.Size(32, 32);
            this.xMark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.xMark.TabIndex = 1;
            this.xMark.TabStop = false;
            this.xMark.MouseDown += new System.Windows.Forms.MouseEventHandler(this.xMark_MouseDown);
            this.xMark.MouseMove += new System.Windows.Forms.MouseEventHandler(this.xMark_MouseMove);
            // 
            // mapBox
            // 
            this.mapBox.Location = new System.Drawing.Point(0, 0);
            this.mapBox.Name = "mapBox";
            this.mapBox.Size = new System.Drawing.Size(512, 512);
            this.mapBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mapBox.TabIndex = 0;
            this.mapBox.TabStop = false;
            this.mapBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapBox_MouseDown);
            this.mapBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapBox_MouseMove);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(775, 1027);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvBossList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(767, 1001);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bosses";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvBossList
            // 
            this.dgvBossList.AllowUserToAddRows = false;
            this.dgvBossList.AllowUserToDeleteRows = false;
            this.dgvBossList.AllowUserToResizeColumns = false;
            this.dgvBossList.AllowUserToResizeRows = false;
            this.dgvBossList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBossList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBossList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvBossList.Location = new System.Drawing.Point(6, 6);
            this.dgvBossList.MultiSelect = false;
            this.dgvBossList.Name = "dgvBossList";
            this.dgvBossList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBossList.Size = new System.Drawing.Size(755, 989);
            this.dgvBossList.TabIndex = 0;
            this.dgvBossList.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBossList_CellClick);
            this.dgvBossList.Sorted += new System.EventHandler(this.dgvBossList_Sorted);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvWpn);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(767, 1001);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Weapon Upgrades";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvWpn
            // 
            this.dgvWpn.AllowUserToAddRows = false;
            this.dgvWpn.AllowUserToDeleteRows = false;
            this.dgvWpn.AllowUserToResizeColumns = false;
            this.dgvWpn.AllowUserToResizeRows = false;
            this.dgvWpn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvWpn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWpn.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvWpn.Location = new System.Drawing.Point(6, 6);
            this.dgvWpn.MultiSelect = false;
            this.dgvWpn.Name = "dgvWpn";
            this.dgvWpn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWpn.Size = new System.Drawing.Size(755, 989);
            this.dgvWpn.TabIndex = 0;
            this.dgvWpn.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWpn_CellClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvFlask);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(767, 1001);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Flask Upgrades";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvFlask
            // 
            this.dgvFlask.AllowUserToAddRows = false;
            this.dgvFlask.AllowUserToDeleteRows = false;
            this.dgvFlask.AllowUserToResizeColumns = false;
            this.dgvFlask.AllowUserToResizeRows = false;
            this.dgvFlask.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFlask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFlask.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvFlask.Location = new System.Drawing.Point(6, 6);
            this.dgvFlask.MultiSelect = false;
            this.dgvFlask.Name = "dgvFlask";
            this.dgvFlask.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFlask.Size = new System.Drawing.Size(755, 989);
            this.dgvFlask.TabIndex = 1;
            this.dgvFlask.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFlask_CellClick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(22, 1045);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(702, 1045);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 2;
            this.btnAbout.Text = "About...";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // cbMonitor
            // 
            this.cbMonitor.BackColor = System.Drawing.SystemColors.Control;
            this.cbMonitor.FormattingEnabled = true;
            this.cbMonitor.Location = new System.Drawing.Point(315, 1047);
            this.cbMonitor.Name = "cbMonitor";
            this.cbMonitor.Size = new System.Drawing.Size(121, 21);
            this.cbMonitor.TabIndex = 5;
            this.cbMonitor.SelectionChangeCommitted += new System.EventHandler(this.cbMonitor_SelectionChangeCommitted);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(521, 1045);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 1050);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Monitor:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.cbMonitor);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapBox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBossList)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWpn)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlask)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mapBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox xMark;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvBossList;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvWpn;
        private System.Windows.Forms.DataGridView dgvFlask;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.ComboBox cbMonitor;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label1;
    }
}

