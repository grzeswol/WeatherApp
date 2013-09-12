namespace WeatherApp
{
    partial class WeatherApp
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.setCityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.coampsTab = new System.Windows.Forms.TabPage();
            this.umModel = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.umPicture = new System.Windows.Forms.PictureBox();
            this.coampsPicture = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.coampsTab.SuspendLayout();
            this.umModel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.umPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coampsPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setCityToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // setCityToolStripMenuItem
            // 
            this.setCityToolStripMenuItem.Name = "setCityToolStripMenuItem";
            this.setCityToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.setCityToolStripMenuItem.Text = "Set city";
            this.setCityToolStripMenuItem.Click += new System.EventHandler(this.setCityToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.coampsTab);
            this.tabControl1.Controls.Add(this.umModel);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(284, 238);
            this.tabControl1.TabIndex = 5;
            // 
            // coampsTab
            // 
            this.coampsTab.AutoScroll = true;
            this.coampsTab.Controls.Add(this.groupBox1);
            this.coampsTab.Controls.Add(this.coampsPicture);
            this.coampsTab.Location = new System.Drawing.Point(4, 22);
            this.coampsTab.Name = "coampsTab";
            this.coampsTab.Padding = new System.Windows.Forms.Padding(3);
            this.coampsTab.Size = new System.Drawing.Size(276, 212);
            this.coampsTab.TabIndex = 0;
            this.coampsTab.Text = "Coamps model";
            this.coampsTab.UseVisualStyleBackColor = true;
            // 
            // umModel
            // 
            this.umModel.AutoScroll = true;
            this.umModel.Controls.Add(this.umPicture);
            this.umModel.Location = new System.Drawing.Point(4, 22);
            this.umModel.Name = "umModel";
            this.umModel.Padding = new System.Windows.Forms.Padding(3);
            this.umModel.Size = new System.Drawing.Size(276, 212);
            this.umModel.TabIndex = 1;
            this.umModel.Text = "Um model";
            this.umModel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(20, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 97);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set City";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 32);
            this.textBox1.MaxLength = 21;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(248, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(82, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Set city";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please specitfy city name";
            // 
            // umPicture
            // 
            this.umPicture.Location = new System.Drawing.Point(22, 41);
            this.umPicture.Name = "umPicture";
            this.umPicture.Size = new System.Drawing.Size(100, 50);
            this.umPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.umPicture.TabIndex = 0;
            this.umPicture.TabStop = false;
            // 
            // coampsPicture
            // 
            this.coampsPicture.Location = new System.Drawing.Point(113, 26);
            this.coampsPicture.Name = "coampsPicture";
            this.coampsPicture.Size = new System.Drawing.Size(100, 50);
            this.coampsPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.coampsPicture.TabIndex = 3;
            this.coampsPicture.TabStop = false;
            // 
            // WeatherApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "WeatherApp";
            this.Text = "WeatherApp";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.coampsTab.ResumeLayout(false);
            this.coampsTab.PerformLayout();
            this.umModel.ResumeLayout(false);
            this.umModel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.umPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coampsPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem setCityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage coampsTab;
        private System.Windows.Forms.TabPage umModel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox umPicture;
        private System.Windows.Forms.PictureBox coampsPicture;
    }
}

