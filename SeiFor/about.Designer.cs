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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(about));
            this.label_name = new System.Windows.Forms.Label();
            this.label_version = new System.Windows.Forms.Label();
            this.label_author = new System.Windows.Forms.Label();
            this.linkLabel_author = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_description = new System.Windows.Forms.TextBox();
            this.button_back = new System.Windows.Forms.Button();
            this.pictureBox_wechat = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_wechat)).BeginInit();
            this.SuspendLayout();
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(14, 12);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(291, 20);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "Production Name: SNMP Engine ID Format";
            // 
            // label_version
            // 
            this.label_version.AutoSize = true;
            this.label_version.Location = new System.Drawing.Point(14, 47);
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(72, 20);
            this.label_version.TabIndex = 1;
            this.label_version.Text = "Version: 1";
            // 
            // label_author
            // 
            this.label_author.AutoSize = true;
            this.label_author.Location = new System.Drawing.Point(14, 79);
            this.label_author.Name = "label_author";
            this.label_author.Size = new System.Drawing.Size(96, 20);
            this.label_author.TabIndex = 2;
            this.label_author.Text = "Copyright @ ";
            // 
            // linkLabel_author
            // 
            this.linkLabel_author.AutoSize = true;
            this.linkLabel_author.Location = new System.Drawing.Point(104, 79);
            this.linkLabel_author.Name = "linkLabel_author";
            this.linkLabel_author.Size = new System.Drawing.Size(89, 20);
            this.linkLabel_author.TabIndex = 3;
            this.linkLabel_author.TabStop = true;
            this.linkLabel_author.Text = "Minpu Kang";
            this.linkLabel_author.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_author_LinkClicked);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 72);
            this.label1.TabIndex = 4;
            this.label1.Text = "WeChat Official Account: qiheyehk (Scan QR code to follow\r\nfor bug feedback)";
            // 
            // textBox_description
            // 
            this.textBox_description.Location = new System.Drawing.Point(14, 189);
            this.textBox_description.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_description.Multiline = true;
            this.textBox_description.Name = "textBox_description";
            this.textBox_description.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_description.Size = new System.Drawing.Size(362, 266);
            this.textBox_description.TabIndex = 5;
            this.textBox_description.Text = resources.GetString("textBox_description.Text");
            // 
            // button_back
            // 
            this.button_back.Location = new System.Drawing.Point(292, 463);
            this.button_back.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(86, 31);
            this.button_back.TabIndex = 6;
            this.button_back.Text = "OK";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // pictureBox_wechat
            // 
            this.pictureBox_wechat.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_wechat.ErrorImage")));
            this.pictureBox_wechat.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_wechat.Image")));
            this.pictureBox_wechat.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_wechat.InitialImage")));
            this.pictureBox_wechat.Location = new System.Drawing.Point(252, 47);
            this.pictureBox_wechat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox_wechat.Name = "pictureBox_wechat";
            this.pictureBox_wechat.Size = new System.Drawing.Size(133, 134);
            this.pictureBox_wechat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_wechat.TabIndex = 7;
            this.pictureBox_wechat.TabStop = false;
            // 
            // about
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 507);
            this.Controls.Add(this.pictureBox_wechat);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.textBox_description);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel_author);
            this.Controls.Add(this.label_author);
            this.Controls.Add(this.label_version);
            this.Controls.Add(this.label_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "about";
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_wechat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label_name;
        private Label label_version;
        private Label label_author;
        private LinkLabel linkLabel_author;
        private Label label1;
        private TextBox textBox_description;
        private Button button_back;
        private PictureBox pictureBox_wechat;
    }
}