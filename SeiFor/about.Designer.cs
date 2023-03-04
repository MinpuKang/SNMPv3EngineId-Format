namespace SeiFor
{
    partial class about
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(about));
            label_name = new Label();
            label_version = new Label();
            label_author = new Label();
            linkLabel_author = new LinkLabel();
            label1 = new Label();
            button_back = new Button();
            pictureBox_wechat = new PictureBox();
            richTextBox_description = new RichTextBox();
            toolTip_about = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox_wechat).BeginInit();
            SuspendLayout();
            // 
            // label_name
            // 
            label_name.AutoSize = true;
            label_name.Location = new Point(14, 12);
            label_name.Name = "label_name";
            label_name.Size = new Size(291, 20);
            label_name.TabIndex = 0;
            label_name.Text = "Production Name: SNMP Engine ID Format";
            // 
            // label_version
            // 
            label_version.AutoSize = true;
            label_version.Location = new Point(14, 47);
            label_version.Name = "label_version";
            label_version.Size = new Size(72, 20);
            label_version.TabIndex = 1;
            label_version.Text = "Version: 2";
            // 
            // label_author
            // 
            label_author.AutoSize = true;
            label_author.Location = new Point(14, 79);
            label_author.Name = "label_author";
            label_author.Size = new Size(96, 20);
            label_author.TabIndex = 2;
            label_author.Text = "Copyright @ ";
            // 
            // linkLabel_author
            // 
            linkLabel_author.AutoSize = true;
            linkLabel_author.Location = new Point(104, 79);
            linkLabel_author.Name = "linkLabel_author";
            linkLabel_author.Size = new Size(89, 20);
            linkLabel_author.TabIndex = 3;
            linkLabel_author.TabStop = true;
            linkLabel_author.Text = "Minpu Kang";
            toolTip_about.SetToolTip(linkLabel_author, "To hk314.top");
            linkLabel_author.LinkClicked += linkLabel_author_LinkClicked;
            // 
            // label1
            // 
            label1.Location = new Point(14, 113);
            label1.Name = "label1";
            label1.Size = new Size(333, 72);
            label1.TabIndex = 4;
            label1.Text = "WeChat Official Account: qiheyehk (Scan QR code to follow\r\nfor bug feedback)";
            // 
            // button_back
            // 
            button_back.Location = new Point(188, 495);
            button_back.Margin = new Padding(3, 4, 3, 4);
            button_back.Name = "button_back";
            button_back.Size = new Size(117, 31);
            button_back.TabIndex = 6;
            button_back.Text = "Back to Main";
            button_back.UseVisualStyleBackColor = true;
            button_back.Click += button_back_Click;
            // 
            // pictureBox_wechat
            // 
            pictureBox_wechat.ErrorImage = (Image)resources.GetObject("pictureBox_wechat.ErrorImage");
            pictureBox_wechat.Image = (Image)resources.GetObject("pictureBox_wechat.Image");
            pictureBox_wechat.InitialImage = (Image)resources.GetObject("pictureBox_wechat.InitialImage");
            pictureBox_wechat.Location = new Point(333, 13);
            pictureBox_wechat.Margin = new Padding(3, 4, 3, 4);
            pictureBox_wechat.Name = "pictureBox_wechat";
            pictureBox_wechat.Size = new Size(162, 169);
            pictureBox_wechat.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_wechat.TabIndex = 7;
            pictureBox_wechat.TabStop = false;
            toolTip_about.SetToolTip(pictureBox_wechat, "Scan the QR to follow for bug report");
            // 
            // richTextBox_description
            // 
            richTextBox_description.BackColor = SystemColors.Window;
            richTextBox_description.BorderStyle = BorderStyle.None;
            richTextBox_description.Location = new Point(12, 188);
            richTextBox_description.Name = "richTextBox_description";
            richTextBox_description.ReadOnly = true;
            richTextBox_description.Size = new Size(483, 300);
            richTextBox_description.TabIndex = 8;
            richTextBox_description.Text = resources.GetString("richTextBox_description.Text");
            richTextBox_description.LinkClicked += richTextBox_description_LinkClicked;
            // 
            // about
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(507, 533);
            Controls.Add(richTextBox_description);
            Controls.Add(pictureBox_wechat);
            Controls.Add(button_back);
            Controls.Add(label1);
            Controls.Add(linkLabel_author);
            Controls.Add(label_author);
            Controls.Add(label_version);
            Controls.Add(label_name);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "about";
            Text = "About";
            ((System.ComponentModel.ISupportInitialize)pictureBox_wechat).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_name;
        private Label label_version;
        private Label label_author;
        private LinkLabel linkLabel_author;
        private Label label1;
        private Button button_back;
        private PictureBox pictureBox_wechat;
        private RichTextBox richTextBox_description;
        private ToolTip toolTip_about;
    }
}