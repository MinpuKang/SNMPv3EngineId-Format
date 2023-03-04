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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            label_version = new Label();
            textBox_version = new TextBox();
            menuStrip_main = new MenuStrip();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            decodeToolStripMenuItem = new ToolStripMenuItem();
            label_pen = new Label();
            textBox_pen = new TextBox();
            label_engineIDFormat = new Label();
            textBox_engineIDData = new TextBox();
            label_engineIDData = new Label();
            textBox_engineIDresult = new TextBox();
            label_engineIDresult = new Label();
            comboBox_engineIDFormat = new ComboBox();
            toolTip_main = new ToolTip(components);
            linkLabel_iana = new LinkLabel();
            menuStrip_main.SuspendLayout();
            SuspendLayout();
            // 
            // label_version
            // 
            label_version.AutoSize = true;
            label_version.Location = new Point(11, 21);
            label_version.Name = "label_version";
            label_version.Size = new Size(101, 20);
            label_version.TabIndex = 0;
            label_version.Text = "SNMP Version";
            // 
            // textBox_version
            // 
            textBox_version.Location = new Point(11, 44);
            textBox_version.Name = "textBox_version";
            textBox_version.ReadOnly = true;
            textBox_version.Size = new Size(101, 27);
            textBox_version.TabIndex = 10;
            textBox_version.Text = "v3";
            toolTip_main.SetToolTip(textBox_version, "Fixed SNMP version to v3");
            // 
            // menuStrip_main
            // 
            menuStrip_main.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            menuStrip_main.Dock = DockStyle.None;
            menuStrip_main.ImageScalingSize = new Size(20, 20);
            menuStrip_main.Items.AddRange(new ToolStripItem[] { aboutToolStripMenuItem, decodeToolStripMenuItem });
            menuStrip_main.Location = new Point(303, 0);
            menuStrip_main.Name = "menuStrip_main";
            menuStrip_main.Padding = new Padding(6, 3, 0, 3);
            menuStrip_main.Size = new Size(297, 30);
            menuStrip_main.TabIndex = 2;
            menuStrip_main.Text = "menuStrip_main";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(64, 24);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.ToolTipText = "To about forms";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // decodeToolStripMenuItem
            // 
            decodeToolStripMenuItem.Name = "decodeToolStripMenuItem";
            decodeToolStripMenuItem.Size = new Size(75, 24);
            decodeToolStripMenuItem.Text = "Decode";
            decodeToolStripMenuItem.ToolTipText = "To decode a snmpEngineID in SNMPv3";
            decodeToolStripMenuItem.Click += decodeToolStripMenuItem_Click;
            // 
            // label_pen
            // 
            label_pen.AutoSize = true;
            label_pen.Location = new Point(133, 21);
            label_pen.Name = "label_pen";
            label_pen.Size = new Size(151, 20);
            label_pen.TabIndex = 3;
            label_pen.Text = "Private Enterprise No.";
            // 
            // textBox_pen
            // 
            textBox_pen.Location = new Point(133, 44);
            textBox_pen.Name = "textBox_pen";
            textBox_pen.Size = new Size(73, 27);
            textBox_pen.TabIndex = 4;
            toolTip_main.SetToolTip(textBox_pen, "The private enterprise number as assigned by IANA(https://www.iana.org/assignments/enterprise-numbers/)");
            textBox_pen.KeyUp += textBox_pen_KeyUp;
            // 
            // label_engineIDFormat
            // 
            label_engineIDFormat.AutoSize = true;
            label_engineIDFormat.Location = new Point(302, 21);
            label_engineIDFormat.Name = "label_engineIDFormat";
            label_engineIDFormat.Size = new Size(124, 20);
            label_engineIDFormat.TabIndex = 5;
            label_engineIDFormat.Text = "Engine ID Format";
            // 
            // textBox_engineIDData
            // 
            textBox_engineIDData.Location = new Point(11, 111);
            textBox_engineIDData.Multiline = true;
            textBox_engineIDData.Name = "textBox_engineIDData";
            textBox_engineIDData.ScrollBars = ScrollBars.Both;
            textBox_engineIDData.Size = new Size(173, 172);
            textBox_engineIDData.TabIndex = 1;
            toolTip_main.SetToolTip(textBox_engineIDData, "Fill the engineID Data based on the Format selected");
            textBox_engineIDData.KeyUp += textBox_engineIDData_KeyUp;
            // 
            // label_engineIDData
            // 
            label_engineIDData.AutoSize = true;
            label_engineIDData.Location = new Point(11, 88);
            label_engineIDData.Name = "label_engineIDData";
            label_engineIDData.Size = new Size(109, 20);
            label_engineIDData.TabIndex = 7;
            label_engineIDData.Text = "Engine ID Data";
            // 
            // textBox_engineIDresult
            // 
            textBox_engineIDresult.Location = new Point(206, 111);
            textBox_engineIDresult.Multiline = true;
            textBox_engineIDresult.Name = "textBox_engineIDresult";
            textBox_engineIDresult.ReadOnly = true;
            textBox_engineIDresult.ScrollBars = ScrollBars.Both;
            textBox_engineIDresult.Size = new Size(381, 172);
            textBox_engineIDresult.TabIndex = 8;
            // 
            // label_engineIDresult
            // 
            label_engineIDresult.AutoSize = true;
            label_engineIDresult.Location = new Point(206, 88);
            label_engineIDresult.Name = "label_engineIDresult";
            label_engineIDresult.Size = new Size(117, 20);
            label_engineIDresult.TabIndex = 9;
            label_engineIDresult.Text = "Engine ID Result";
            // 
            // comboBox_engineIDFormat
            // 
            comboBox_engineIDFormat.FormattingEnabled = true;
            comboBox_engineIDFormat.Items.AddRange(new object[] { "1(IPv4 for Engine ID Data)", "2(IPv6 for Engine ID Data)", "3(MAC for Engine ID Data)", "4(Text, admin assigned with max length 27)" });
            comboBox_engineIDFormat.Location = new Point(302, 45);
            comboBox_engineIDFormat.Margin = new Padding(3, 4, 3, 4);
            comboBox_engineIDFormat.Name = "comboBox_engineIDFormat";
            comboBox_engineIDFormat.Size = new Size(285, 28);
            comboBox_engineIDFormat.TabIndex = 6;
            toolTip_main.SetToolTip(comboBox_engineIDFormat, "Select the engineID format");
            comboBox_engineIDFormat.SelectedIndexChanged += comboBox_engineIDFormat_SelectedIndexChanged;
            // 
            // linkLabel_iana
            // 
            linkLabel_iana.AutoSize = true;
            linkLabel_iana.Location = new Point(207, 53);
            linkLabel_iana.Name = "linkLabel_iana";
            linkLabel_iana.Size = new Size(75, 20);
            linkLabel_iana.TabIndex = 11;
            linkLabel_iana.TabStop = true;
            linkLabel_iana.Text = "IANA PEN";
            toolTip_main.SetToolTip(linkLabel_iana, "To IANA Web(https://www.iana.org/assignments/enterprise-numbers)");
            linkLabel_iana.LinkClicked += linkLabel_iana_LinkClicked;
            // 
            // main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(601, 297);
            Controls.Add(linkLabel_iana);
            Controls.Add(comboBox_engineIDFormat);
            Controls.Add(textBox_engineIDresult);
            Controls.Add(label_engineIDresult);
            Controls.Add(textBox_engineIDData);
            Controls.Add(label_engineIDData);
            Controls.Add(label_engineIDFormat);
            Controls.Add(textBox_pen);
            Controls.Add(label_pen);
            Controls.Add(textBox_version);
            Controls.Add(label_version);
            Controls.Add(menuStrip_main);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip_main;
            MaximizeBox = false;
            Name = "main";
            Text = "SeiFor - SnmpEngineId Format";
            menuStrip_main.ResumeLayout(false);
            menuStrip_main.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private ToolStripMenuItem decodeToolStripMenuItem;
    }
}