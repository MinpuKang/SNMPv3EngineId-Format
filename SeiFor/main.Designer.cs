namespace SeiFor
{
    partial class main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.label_version = new System.Windows.Forms.Label();
            this.textBox_version = new System.Windows.Forms.TextBox();
            this.menuStrip_main = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_pen = new System.Windows.Forms.Label();
            this.textBox_pen = new System.Windows.Forms.TextBox();
            this.label_engineIDFormat = new System.Windows.Forms.Label();
            this.textBox_engineIDData = new System.Windows.Forms.TextBox();
            this.label_engineIDData = new System.Windows.Forms.Label();
            this.textBox_engineIDresult = new System.Windows.Forms.TextBox();
            this.label_engineIDresult = new System.Windows.Forms.Label();
            this.comboBox_engineIDFormat = new System.Windows.Forms.ComboBox();
            this.toolTip_main = new System.Windows.Forms.ToolTip(this.components);
            this.linkLabel_iana = new System.Windows.Forms.LinkLabel();
            this.menuStrip_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_version
            // 
            this.label_version.AutoSize = true;
            this.label_version.Location = new System.Drawing.Point(10, 16);
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(81, 15);
            this.label_version.TabIndex = 0;
            this.label_version.Text = "SNMP Version";
            // 
            // textBox_version
            // 
            this.textBox_version.Location = new System.Drawing.Point(10, 33);
            this.textBox_version.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_version.Name = "textBox_version";
            this.textBox_version.ReadOnly = true;
            this.textBox_version.Size = new System.Drawing.Size(89, 23);
            this.textBox_version.TabIndex = 10;
            this.textBox_version.Text = "v3";
            // 
            // menuStrip_main
            // 
            this.menuStrip_main.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip_main.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip_main.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip_main.Location = new System.Drawing.Point(466, 0);
            this.menuStrip_main.Name = "menuStrip_main";
            this.menuStrip_main.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip_main.Size = new System.Drawing.Size(59, 24);
            this.menuStrip_main.TabIndex = 2;
            this.menuStrip_main.Text = "menuStrip_main";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // label_pen
            // 
            this.label_pen.AutoSize = true;
            this.label_pen.Location = new System.Drawing.Point(116, 16);
            this.label_pen.Name = "label_pen";
            this.label_pen.Size = new System.Drawing.Size(121, 15);
            this.label_pen.TabIndex = 3;
            this.label_pen.Text = "Private Enterprice No.";
            // 
            // textBox_pen
            // 
            this.textBox_pen.Location = new System.Drawing.Point(116, 33);
            this.textBox_pen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_pen.Name = "textBox_pen";
            this.textBox_pen.Size = new System.Drawing.Size(64, 23);
            this.textBox_pen.TabIndex = 4;
            this.toolTip_main.SetToolTip(this.textBox_pen, "The private enterprise number as assigned by IANA(https://www.iana.org/assignment" +
        "s/enterprise-numbers/)");
            this.textBox_pen.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_pen_KeyUp);
            // 
            // label_engineIDFormat
            // 
            this.label_engineIDFormat.AutoSize = true;
            this.label_engineIDFormat.Location = new System.Drawing.Point(264, 16);
            this.label_engineIDFormat.Name = "label_engineIDFormat";
            this.label_engineIDFormat.Size = new System.Drawing.Size(98, 15);
            this.label_engineIDFormat.TabIndex = 5;
            this.label_engineIDFormat.Text = "Engine ID Format";
            // 
            // textBox_engineIDData
            // 
            this.textBox_engineIDData.Location = new System.Drawing.Point(10, 83);
            this.textBox_engineIDData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_engineIDData.Multiline = true;
            this.textBox_engineIDData.Name = "textBox_engineIDData";
            this.textBox_engineIDData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_engineIDData.Size = new System.Drawing.Size(152, 130);
            this.textBox_engineIDData.TabIndex = 1;
            this.textBox_engineIDData.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_engineIDData_KeyUp);
            // 
            // label_engineIDData
            // 
            this.label_engineIDData.AutoSize = true;
            this.label_engineIDData.Location = new System.Drawing.Point(10, 66);
            this.label_engineIDData.Name = "label_engineIDData";
            this.label_engineIDData.Size = new System.Drawing.Size(84, 15);
            this.label_engineIDData.TabIndex = 7;
            this.label_engineIDData.Text = "Engine ID Data";
            // 
            // textBox_engineIDresult
            // 
            this.textBox_engineIDresult.Location = new System.Drawing.Point(180, 83);
            this.textBox_engineIDresult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_engineIDresult.Multiline = true;
            this.textBox_engineIDresult.Name = "textBox_engineIDresult";
            this.textBox_engineIDresult.ReadOnly = true;
            this.textBox_engineIDresult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_engineIDresult.Size = new System.Drawing.Size(334, 130);
            this.textBox_engineIDresult.TabIndex = 8;
            // 
            // label_engineIDresult
            // 
            this.label_engineIDresult.AutoSize = true;
            this.label_engineIDresult.Location = new System.Drawing.Point(180, 66);
            this.label_engineIDresult.Name = "label_engineIDresult";
            this.label_engineIDresult.Size = new System.Drawing.Size(92, 15);
            this.label_engineIDresult.TabIndex = 9;
            this.label_engineIDresult.Text = "Engine ID Result";
            // 
            // comboBox_engineIDFormat
            // 
            this.comboBox_engineIDFormat.FormattingEnabled = true;
            this.comboBox_engineIDFormat.Items.AddRange(new object[] {
            "1(IPv4 for Engine ID Data)"});
            this.comboBox_engineIDFormat.Location = new System.Drawing.Point(264, 34);
            this.comboBox_engineIDFormat.Name = "comboBox_engineIDFormat";
            this.comboBox_engineIDFormat.Size = new System.Drawing.Size(191, 23);
            this.comboBox_engineIDFormat.TabIndex = 6;
            this.comboBox_engineIDFormat.SelectedIndexChanged += new System.EventHandler(this.comboBox_engineIDFormat_SelectedIndexChanged);
            // 
            // linkLabel_iana
            // 
            this.linkLabel_iana.AutoSize = true;
            this.linkLabel_iana.Location = new System.Drawing.Point(181, 40);
            this.linkLabel_iana.Name = "linkLabel_iana";
            this.linkLabel_iana.Size = new System.Drawing.Size(60, 15);
            this.linkLabel_iana.TabIndex = 11;
            this.linkLabel_iana.TabStop = true;
            this.linkLabel_iana.Text = "IANA PEN";
            this.linkLabel_iana.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_iana_LinkClicked);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 223);
            this.Controls.Add(this.linkLabel_iana);
            this.Controls.Add(this.comboBox_engineIDFormat);
            this.Controls.Add(this.textBox_engineIDresult);
            this.Controls.Add(this.label_engineIDresult);
            this.Controls.Add(this.textBox_engineIDData);
            this.Controls.Add(this.label_engineIDData);
            this.Controls.Add(this.label_engineIDFormat);
            this.Controls.Add(this.textBox_pen);
            this.Controls.Add(this.label_pen);
            this.Controls.Add(this.textBox_version);
            this.Controls.Add(this.label_version);
            this.Controls.Add(this.menuStrip_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip_main;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "main";
            this.Text = "SeiFor - SnmpEngineId Format";
            this.menuStrip_main.ResumeLayout(false);
            this.menuStrip_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label_version;
        private TextBox textBox_version;
        private MenuStrip menuStrip_main;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Label label_pen;
        private TextBox textBox_pen;
        private Label label_engineIDFormat;
        private TextBox textBox_engineIDData;
        private Label label_engineIDData;
        private TextBox textBox_engineIDresult;
        private Label label_engineIDresult;
        private ComboBox comboBox_engineIDFormat;
        private ToolTip toolTip_main;
        private LinkLabel linkLabel_iana;
    }
}