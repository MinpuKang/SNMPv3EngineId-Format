namespace SeiFor
{
    partial class decodeEngineId
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(decodeEngineId));
            label_engineid = new Label();
            textBox_engineid = new TextBox();
            label_pen = new Label();
            textBox_pen = new TextBox();
            label_engineIDFormat = new Label();
            textBox_dataformat = new TextBox();
            label_engineIDData = new Label();
            textBox_engineIDData = new TextBox();
            pictureBox_wechat = new PictureBox();
            button_back = new Button();
            textBox_conformance = new TextBox();
            label_conformance = new Label();
            linkLabel_iana = new LinkLabel();
            toolTip_decode = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox_wechat).BeginInit();
            SuspendLayout();
            // 
            // label_engineid
            // 
            label_engineid.AutoSize = true;
            label_engineid.Location = new Point(48, 13);
            label_engineid.Name = "label_engineid";
            label_engineid.Size = new Size(131, 20);
            label_engineid.TabIndex = 0;
            label_engineid.Text = "SNMPv3 EngineID:";
            // 
            // textBox_engineid
            // 
            textBox_engineid.Location = new Point(185, 11);
            textBox_engineid.Name = "textBox_engineid";
            textBox_engineid.Size = new Size(261, 27);
            textBox_engineid.TabIndex = 1;
            toolTip_decode.SetToolTip(textBox_engineid, "Fill in the SNMPv3 engineID");
            textBox_engineid.KeyUp += textBox_engineid_KeyUp;
            // 
            // label_pen
            // 
            label_pen.AutoSize = true;
            label_pen.Location = new Point(25, 88);
            label_pen.Name = "label_pen";
            label_pen.Size = new Size(158, 20);
            label_pen.TabIndex = 4;
            label_pen.Text = "Private Enterprise No.: ";
            // 
            // textBox_pen
            // 
            textBox_pen.Location = new Point(185, 88);
            textBox_pen.Name = "textBox_pen";
            textBox_pen.ReadOnly = true;
            textBox_pen.Size = new Size(128, 27);
            textBox_pen.TabIndex = 5;
            // 
            // label_engineIDFormat
            // 
            label_engineIDFormat.AutoSize = true;
            label_engineIDFormat.Location = new Point(55, 122);
            label_engineIDFormat.Name = "label_engineIDFormat";
            label_engineIDFormat.Size = new Size(127, 20);
            label_engineIDFormat.TabIndex = 6;
            label_engineIDFormat.Text = "Engine ID Format:";
            // 
            // textBox_dataformat
            // 
            textBox_dataformat.Location = new Point(185, 122);
            textBox_dataformat.Name = "textBox_dataformat";
            textBox_dataformat.ReadOnly = true;
            textBox_dataformat.Size = new Size(261, 27);
            textBox_dataformat.TabIndex = 7;
            // 
            // label_engineIDData
            // 
            label_engineIDData.AutoSize = true;
            label_engineIDData.Location = new Point(70, 157);
            label_engineIDData.Name = "label_engineIDData";
            label_engineIDData.Size = new Size(112, 20);
            label_engineIDData.TabIndex = 8;
            label_engineIDData.Text = "Engine ID Data:";
            // 
            // textBox_engineIDData
            // 
            textBox_engineIDData.Location = new Point(185, 157);
            textBox_engineIDData.Multiline = true;
            textBox_engineIDData.Name = "textBox_engineIDData";
            textBox_engineIDData.ReadOnly = true;
            textBox_engineIDData.ScrollBars = ScrollBars.Both;
            textBox_engineIDData.Size = new Size(261, 82);
            textBox_engineIDData.TabIndex = 9;
            // 
            // pictureBox_wechat
            // 
            pictureBox_wechat.ErrorImage = (Image)resources.GetObject("pictureBox_wechat.ErrorImage");
            pictureBox_wechat.Image = (Image)resources.GetObject("pictureBox_wechat.Image");
            pictureBox_wechat.InitialImage = (Image)resources.GetObject("pictureBox_wechat.InitialImage");
            pictureBox_wechat.Location = new Point(69, 180);
            pictureBox_wechat.Margin = new Padding(3, 4, 3, 4);
            pictureBox_wechat.Name = "pictureBox_wechat";
            pictureBox_wechat.Size = new Size(113, 97);
            pictureBox_wechat.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_wechat.TabIndex = 11;
            pictureBox_wechat.TabStop = false;
            toolTip_decode.SetToolTip(pictureBox_wechat, "Scan the QR to follow for bug report");
            // 
            // button_back
            // 
            button_back.Location = new Point(329, 246);
            button_back.Margin = new Padding(3, 4, 3, 4);
            button_back.Name = "button_back";
            button_back.Size = new Size(117, 31);
            button_back.TabIndex = 12;
            button_back.Text = "Back to Main";
            button_back.UseVisualStyleBackColor = true;
            button_back.Click += button_back_Click;
            // 
            // textBox_conformance
            // 
            textBox_conformance.Location = new Point(185, 55);
            textBox_conformance.Name = "textBox_conformance";
            textBox_conformance.ReadOnly = true;
            textBox_conformance.Size = new Size(261, 27);
            textBox_conformance.TabIndex = 14;
            // 
            // label_conformance
            // 
            label_conformance.AutoSize = true;
            label_conformance.Location = new Point(14, 55);
            label_conformance.Name = "label_conformance";
            label_conformance.Size = new Size(169, 20);
            label_conformance.TabIndex = 13;
            label_conformance.Text = "Engine ID Conformance:";
            // 
            // linkLabel_iana
            // 
            linkLabel_iana.AutoSize = true;
            linkLabel_iana.Location = new Point(319, 95);
            linkLabel_iana.Name = "linkLabel_iana";
            linkLabel_iana.Size = new Size(125, 20);
            linkLabel_iana.TabIndex = 15;
            linkLabel_iana.TabStop = true;
            linkLabel_iana.Text = "IANA PEN_Search";
            toolTip_decode.SetToolTip(linkLabel_iana, "To IANA Web(https://www.iana.org/assignments/enterprise-numbers)");
            linkLabel_iana.LinkClicked += linkLabel_iana_LinkClicked;
            // 
            // decodeEngineId
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(469, 286);
            Controls.Add(linkLabel_iana);
            Controls.Add(textBox_conformance);
            Controls.Add(label_conformance);
            Controls.Add(button_back);
            Controls.Add(pictureBox_wechat);
            Controls.Add(textBox_engineIDData);
            Controls.Add(label_engineIDData);
            Controls.Add(textBox_dataformat);
            Controls.Add(label_engineIDFormat);
            Controls.Add(textBox_pen);
            Controls.Add(label_pen);
            Controls.Add(textBox_engineid);
            Controls.Add(label_engineid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "decodeEngineId";
            Text = "Decode SNMPv3 EngineID";
            ((System.ComponentModel.ISupportInitialize)pictureBox_wechat).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_engineid;
        private TextBox textBox_engineid;
        private Label label_pen;
        private TextBox textBox_pen;
        private Label label_engineIDFormat;
        private TextBox textBox_dataformat;
        private Label label_engineIDData;
        private TextBox textBox_engineIDData;
        private PictureBox pictureBox_wechat;
        private Button button_back;
        private TextBox textBox_conformance;
        private Label label_conformance;
        private LinkLabel linkLabel_iana;
        private ToolTip toolTip_decode;
    }
}