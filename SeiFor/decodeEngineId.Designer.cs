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
            pictureBox_wechat = new PictureBox();
            button_back = new Button();
            label_result = new Label();
            toolTip_decode = new ToolTip(components);
            button_save = new Button();
            saveFileDialog_result = new SaveFileDialog();
            textBox_result = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox_wechat).BeginInit();
            SuspendLayout();
            // 
            // label_engineid
            // 
            label_engineid.AutoSize = true;
            label_engineid.Location = new Point(12, 14);
            label_engineid.Name = "label_engineid";
            label_engineid.Size = new Size(131, 20);
            label_engineid.TabIndex = 0;
            label_engineid.Text = "SNMPv3 EngineID:";
            // 
            // textBox_engineid
            // 
            textBox_engineid.Location = new Point(149, 11);
            textBox_engineid.Name = "textBox_engineid";
            textBox_engineid.Size = new Size(379, 27);
            textBox_engineid.TabIndex = 1;
            toolTip_decode.SetToolTip(textBox_engineid, "Fill in the SNMPv3 engineID");
            textBox_engineid.KeyUp += textBox_engineid_KeyUp;
            // 
            // pictureBox_wechat
            // 
            pictureBox_wechat.ErrorImage = (Image)resources.GetObject("pictureBox_wechat.ErrorImage");
            pictureBox_wechat.Image = (Image)resources.GetObject("pictureBox_wechat.Image");
            pictureBox_wechat.InitialImage = (Image)resources.GetObject("pictureBox_wechat.InitialImage");
            pictureBox_wechat.Location = new Point(21, 107);
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
            button_back.Location = new Point(362, 211);
            button_back.Margin = new Padding(3, 4, 3, 4);
            button_back.Name = "button_back";
            button_back.Size = new Size(117, 31);
            button_back.TabIndex = 12;
            button_back.Text = "Back to Main";
            button_back.UseVisualStyleBackColor = true;
            button_back.Click += button_back_Click;
            // 
            // label_result
            // 
            label_result.AutoSize = true;
            label_result.Location = new Point(21, 49);
            label_result.Name = "label_result";
            label_result.Size = new Size(117, 20);
            label_result.TabIndex = 13;
            label_result.Text = "Decoded Result:";
            // 
            // button_save
            // 
            button_save.Location = new Point(229, 211);
            button_save.Margin = new Padding(3, 4, 3, 4);
            button_save.Name = "button_save";
            button_save.Size = new Size(95, 31);
            button_save.TabIndex = 17;
            button_save.Text = "Save";
            button_save.UseVisualStyleBackColor = true;
            button_save.Click += button_save_Click;
            // 
            // textBox_result
            // 
            textBox_result.Location = new Point(149, 49);
            textBox_result.Multiline = true;
            textBox_result.Name = "textBox_result";
            textBox_result.ReadOnly = true;
            textBox_result.Size = new Size(379, 155);
            textBox_result.TabIndex = 18;
            // 
            // decodeEngineId
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 253);
            Controls.Add(textBox_result);
            Controls.Add(button_save);
            Controls.Add(label_result);
            Controls.Add(button_back);
            Controls.Add(pictureBox_wechat);
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
        private PictureBox pictureBox_wechat;
        private Button button_back;
        private Label label_result;
        private ToolTip toolTip_decode;
        private Button button_save;
        private SaveFileDialog saveFileDialog_result;
        private TextBox textBox_result;
    }
}