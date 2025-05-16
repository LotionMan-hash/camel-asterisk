namespace elgamal
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
            lblPlain = new Label();
            lblCypher1 = new Label();
            lblCypher2 = new Label();
            txtPlain = new TextBox();
            txtCypher1 = new TextBox();
            txtCypher2 = new TextBox();
            btnEncrypt = new Button();
            btnDecrypt = new Button();
            lblP = new Label();
            lblA = new Label();
            lblX = new Label();
            lblY = new Label();
            txtP = new TextBox();
            txtA = new TextBox();
            txtX = new TextBox();
            txtY = new TextBox();
            btnKeygen = new Button();
            chkX = new CheckBox();
            nudKeySize = new NumericUpDown();
            lblKeySize = new Label();
            cbType = new ComboBox();
            lblTextStatus = new Label();
            lblStatus = new Label();
            cbK = new CheckBox();
            txtK = new TextBox();
            gbPublic = new GroupBox();
            panelGen = new Panel();
            ((System.ComponentModel.ISupportInitialize)nudKeySize).BeginInit();
            gbPublic.SuspendLayout();
            panelGen.SuspendLayout();
            SuspendLayout();
            // 
            // lblPlain
            // 
            lblPlain.AutoSize = true;
            lblPlain.Location = new Point(39, 82);
            lblPlain.Name = "lblPlain";
            lblPlain.Size = new Size(56, 15);
            lblPlain.TabIndex = 0;
            lblPlain.Text = "Plaintext:";
            // 
            // lblCypher1
            // 
            lblCypher1.AutoSize = true;
            lblCypher1.Location = new Point(501, 18);
            lblCypher1.Name = "lblCypher1";
            lblCypher1.Size = new Size(24, 15);
            lblCypher1.TabIndex = 1;
            lblCypher1.Text = "C1:";
            // 
            // lblCypher2
            // 
            lblCypher2.AutoSize = true;
            lblCypher2.Location = new Point(501, 206);
            lblCypher2.Name = "lblCypher2";
            lblCypher2.Size = new Size(24, 15);
            lblCypher2.TabIndex = 2;
            lblCypher2.Text = "C2:";
            // 
            // txtPlain
            // 
            txtPlain.Location = new Point(39, 105);
            txtPlain.Multiline = true;
            txtPlain.Name = "txtPlain";
            txtPlain.Size = new Size(200, 150);
            txtPlain.TabIndex = 3;
            txtPlain.KeyPress += txtPlain_KeyPress;
            // 
            // txtCypher1
            // 
            txtCypher1.Location = new Point(501, 36);
            txtCypher1.Multiline = true;
            txtCypher1.Name = "txtCypher1";
            txtCypher1.Size = new Size(200, 150);
            txtCypher1.TabIndex = 4;
            txtCypher1.KeyPress += txtCypher1_KeyPress;
            // 
            // txtCypher2
            // 
            txtCypher2.Location = new Point(501, 224);
            txtCypher2.Multiline = true;
            txtCypher2.Name = "txtCypher2";
            txtCypher2.Size = new Size(200, 150);
            txtCypher2.TabIndex = 5;
            txtCypher2.KeyPress += txtCypher2_KeyPress;
            // 
            // btnEncrypt
            // 
            btnEncrypt.Location = new Point(323, 152);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(105, 23);
            btnEncrypt.TabIndex = 6;
            btnEncrypt.Text = ">> Encrypt";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // btnDecrypt
            // 
            btnDecrypt.Location = new Point(323, 181);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(105, 23);
            btnDecrypt.TabIndex = 7;
            btnDecrypt.Text = "<< Decrypt";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // lblP
            // 
            lblP.AutoSize = true;
            lblP.Location = new Point(6, 25);
            lblP.Name = "lblP";
            lblP.Size = new Size(25, 15);
            lblP.TabIndex = 8;
            lblP.Text = "p =";
            // 
            // lblA
            // 
            lblA.AutoSize = true;
            lblA.Location = new Point(6, 51);
            lblA.Name = "lblA";
            lblA.Size = new Size(24, 15);
            lblA.TabIndex = 9;
            lblA.Text = "a =";
            // 
            // lblX
            // 
            lblX.AutoSize = true;
            lblX.Location = new Point(260, 235);
            lblX.Name = "lblX";
            lblX.Size = new Size(24, 15);
            lblX.TabIndex = 10;
            lblX.Text = "x =";
            // 
            // lblY
            // 
            lblY.AutoSize = true;
            lblY.Location = new Point(6, 76);
            lblY.Name = "lblY";
            lblY.Size = new Size(24, 15);
            lblY.TabIndex = 11;
            lblY.Text = "y =";
            // 
            // txtP
            // 
            txtP.Location = new Point(37, 22);
            txtP.Name = "txtP";
            txtP.Size = new Size(169, 23);
            txtP.TabIndex = 12;
            txtP.KeyPress += txtP_KeyPress;
            // 
            // txtA
            // 
            txtA.Location = new Point(36, 48);
            txtA.Name = "txtA";
            txtA.Size = new Size(170, 23);
            txtA.TabIndex = 13;
            txtA.KeyPress += txtA_KeyPress;
            // 
            // txtX
            // 
            txtX.Location = new Point(290, 232);
            txtX.Name = "txtX";
            txtX.Size = new Size(179, 23);
            txtX.TabIndex = 14;
            // 
            // txtY
            // 
            txtY.Location = new Point(36, 73);
            txtY.Name = "txtY";
            txtY.Size = new Size(170, 23);
            txtY.TabIndex = 15;
            txtY.KeyPress += txtY_KeyPress;
            // 
            // btnKeygen
            // 
            btnKeygen.Location = new Point(2, 41);
            btnKeygen.Name = "btnKeygen";
            btnKeygen.Size = new Size(105, 23);
            btnKeygen.TabIndex = 16;
            btnKeygen.Text = "Generate Keys";
            btnKeygen.UseVisualStyleBackColor = true;
            btnKeygen.Click += btnKeygen_Click;
            // 
            // chkX
            // 
            chkX.AutoSize = true;
            chkX.Location = new Point(114, 43);
            chkX.Name = "chkX";
            chkX.Size = new Size(98, 19);
            chkX.TabIndex = 17;
            chkX.Text = "Generate X(Y)";
            chkX.UseVisualStyleBackColor = true;
            // 
            // nudKeySize
            // 
            nudKeySize.Location = new Point(114, 14);
            nudKeySize.Name = "nudKeySize";
            nudKeySize.Size = new Size(98, 23);
            nudKeySize.TabIndex = 19;
            nudKeySize.Value = new decimal(new int[] { 16, 0, 0, 0 });
            // 
            // lblKeySize
            // 
            lblKeySize.AutoSize = true;
            lblKeySize.Location = new Point(3, 16);
            lblKeySize.Name = "lblKeySize";
            lblKeySize.Size = new Size(88, 15);
            lblKeySize.TabIndex = 20;
            lblKeySize.Text = "Key size (byte): ";
            // 
            // cbType
            // 
            cbType.FormattingEnabled = true;
            cbType.Items.AddRange(new object[] { "String", "Number" });
            cbType.Location = new Point(101, 79);
            cbType.Name = "cbType";
            cbType.Size = new Size(138, 23);
            cbType.TabIndex = 21;
            cbType.SelectedValueChanged += cbType_SelectedValueChanged;
            // 
            // lblTextStatus
            // 
            lblTextStatus.AutoSize = true;
            lblTextStatus.Location = new Point(39, 386);
            lblTextStatus.Name = "lblTextStatus";
            lblTextStatus.Size = new Size(42, 15);
            lblTextStatus.TabIndex = 22;
            lblTextStatus.Text = "Status:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(87, 386);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(46, 15);
            lblStatus.TabIndex = 23;
            lblStatus.Text = "[status]";
            // 
            // cbK
            // 
            cbK.AutoSize = true;
            cbK.Location = new Point(3, 71);
            cbK.Name = "cbK";
            cbK.Size = new Size(43, 19);
            cbK.TabIndex = 24;
            cbK.Text = "k =";
            cbK.UseVisualStyleBackColor = true;
            cbK.CheckedChanged += cbK_CheckedChanged;
            // 
            // txtK
            // 
            txtK.Enabled = false;
            txtK.Location = new Point(45, 67);
            txtK.Name = "txtK";
            txtK.Size = new Size(167, 23);
            txtK.TabIndex = 25;
            txtK.KeyPress += txtK_KeyPress;
            // 
            // gbPublic
            // 
            gbPublic.Controls.Add(txtP);
            gbPublic.Controls.Add(lblP);
            gbPublic.Controls.Add(lblA);
            gbPublic.Controls.Add(lblY);
            gbPublic.Controls.Add(txtA);
            gbPublic.Controls.Add(txtY);
            gbPublic.Location = new Point(39, 271);
            gbPublic.Name = "gbPublic";
            gbPublic.Size = new Size(212, 103);
            gbPublic.TabIndex = 26;
            gbPublic.TabStop = false;
            gbPublic.Text = "Public keys:";
            // 
            // panelGen
            // 
            panelGen.Controls.Add(lblKeySize);
            panelGen.Controls.Add(btnKeygen);
            panelGen.Controls.Add(txtK);
            panelGen.Controls.Add(chkX);
            panelGen.Controls.Add(cbK);
            panelGen.Controls.Add(nudKeySize);
            panelGen.Location = new Point(257, 280);
            panelGen.Name = "panelGen";
            panelGen.Size = new Size(238, 94);
            panelGen.TabIndex = 27;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(748, 410);
            Controls.Add(panelGen);
            Controls.Add(gbPublic);
            Controls.Add(lblStatus);
            Controls.Add(lblTextStatus);
            Controls.Add(cbType);
            Controls.Add(txtX);
            Controls.Add(lblX);
            Controls.Add(btnDecrypt);
            Controls.Add(btnEncrypt);
            Controls.Add(txtCypher2);
            Controls.Add(txtCypher1);
            Controls.Add(txtPlain);
            Controls.Add(lblCypher2);
            Controls.Add(lblCypher1);
            Controls.Add(lblPlain);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "ElGamal";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)nudKeySize).EndInit();
            gbPublic.ResumeLayout(false);
            gbPublic.PerformLayout();
            panelGen.ResumeLayout(false);
            panelGen.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPlain;
        private Label lblCypher1;
        private Label lblCypher2;
        private TextBox txtPlain;
        private TextBox txtCypher1;
        private TextBox txtCypher2;
        private Button btnEncrypt;
        private Button btnDecrypt;
        private Label lblP;
        private Label lblA;
        private Label lblX;
        private Label lblY;
        private TextBox txtP;
        private TextBox txtA;
        private TextBox txtX;
        private TextBox txtY;
        private Button btnKeygen;
        private CheckBox chkX;
        private NumericUpDown nudKeySize;
        private Label lblKeySize;
        private ComboBox cbType;
        private Label lblTextStatus;
        private Label lblStatus;
        private CheckBox cbK;
        private TextBox txtK;
        private GroupBox gbPublic;
        private Panel panelGen;
    }
}
