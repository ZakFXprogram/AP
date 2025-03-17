
namespace jpo
{
    partial class frmEnregistrementMembres
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
            this.label1 = new System.Windows.Forms.Label();
            this.Enregistrer2 = new System.Windows.Forms.Button();
            this.Annuler2 = new System.Windows.Forms.Button();
            this.lstMembre = new System.Windows.Forms.ListBox();
            this.lbxFindLigue = new System.Windows.Forms.Label();
            this.cbxFindLigue = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lbxNom = new System.Windows.Forms.Label();
            this.lbxMail = new System.Windows.Forms.Label();
            this.lbxLigue = new System.Windows.Forms.Label();
            this.lbxTel = new System.Windows.Forms.Label();
            this.lbxPrenom = new System.Windows.Forms.Label();
            this.tbxMail = new System.Windows.Forms.TextBox();
            this.tbxTel = new System.Windows.Forms.TextBox();
            this.tbxPrenom = new System.Windows.Forms.TextBox();
            this.tbxNom = new System.Windows.Forms.TextBox();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(291, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enregistrement membres";
            // 
            // Enregistrer2
            // 
            this.Enregistrer2.Font = new System.Drawing.Font("Reem Kufi", 11.25F, System.Drawing.FontStyle.Bold);
            this.Enregistrer2.Location = new System.Drawing.Point(217, 321);
            this.Enregistrer2.Name = "Enregistrer2";
            this.Enregistrer2.Size = new System.Drawing.Size(127, 38);
            this.Enregistrer2.TabIndex = 66;
            this.Enregistrer2.Text = "Enregistrer";
            this.Enregistrer2.UseVisualStyleBackColor = true;
            this.Enregistrer2.Click += new System.EventHandler(this.Enregistrer2_Click);
            // 
            // Annuler2
            // 
            this.Annuler2.Font = new System.Drawing.Font("Reem Kufi", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Annuler2.Location = new System.Drawing.Point(55, 319);
            this.Annuler2.Name = "Annuler2";
            this.Annuler2.Size = new System.Drawing.Size(127, 38);
            this.Annuler2.TabIndex = 65;
            this.Annuler2.Text = "Annuler";
            this.Annuler2.UseVisualStyleBackColor = true;
            this.Annuler2.Click += new System.EventHandler(this.Annuler2_Click);
            // 
            // lstMembre
            // 
            this.lstMembre.Font = new System.Drawing.Font("Reem Kufi", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMembre.FormattingEnabled = true;
            this.lstMembre.ItemHeight = 23;
            this.lstMembre.Location = new System.Drawing.Point(513, 103);
            this.lstMembre.Name = "lstMembre";
            this.lstMembre.Size = new System.Drawing.Size(237, 211);
            this.lstMembre.TabIndex = 64;
            this.lstMembre.SelectedIndexChanged += new System.EventHandler(this.lstMembre_SelectedIndexChanged);
            // 
            // lbxFindLigue
            // 
            this.lbxFindLigue.AutoSize = true;
            this.lbxFindLigue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbxFindLigue.Location = new System.Drawing.Point(510, 53);
            this.lbxFindLigue.Name = "lbxFindLigue";
            this.lbxFindLigue.Size = new System.Drawing.Size(67, 18);
            this.lbxFindLigue.TabIndex = 63;
            this.lbxFindLigue.Text = "LIGUE :";
            // 
            // cbxFindLigue
            // 
            this.cbxFindLigue.FormattingEnabled = true;
            this.cbxFindLigue.Location = new System.Drawing.Point(594, 50);
            this.cbxFindLigue.Name = "cbxFindLigue";
            this.cbxFindLigue.Size = new System.Drawing.Size(156, 21);
            this.cbxFindLigue.TabIndex = 62;
            this.cbxFindLigue.SelectedIndexChanged += new System.EventHandler(this.cbxFindLigue_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(149, 259);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(193, 21);
            this.comboBox1.TabIndex = 61;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lbxNom
            // 
            this.lbxNom.AutoSize = true;
            this.lbxNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbxNom.Location = new System.Drawing.Point(85, 87);
            this.lbxNom.Name = "lbxNom";
            this.lbxNom.Size = new System.Drawing.Size(57, 18);
            this.lbxNom.TabIndex = 60;
            this.lbxNom.Text = "NOM :";
            // 
            // lbxMail
            // 
            this.lbxMail.AutoSize = true;
            this.lbxMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbxMail.Location = new System.Drawing.Point(87, 224);
            this.lbxMail.Name = "lbxMail";
            this.lbxMail.Size = new System.Drawing.Size(55, 18);
            this.lbxMail.TabIndex = 59;
            this.lbxMail.Text = "MAIL :";
            // 
            // lbxLigue
            // 
            this.lbxLigue.AutoSize = true;
            this.lbxLigue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbxLigue.Location = new System.Drawing.Point(75, 262);
            this.lbxLigue.Name = "lbxLigue";
            this.lbxLigue.Size = new System.Drawing.Size(67, 18);
            this.lbxLigue.TabIndex = 58;
            this.lbxLigue.Text = "LIGUE :";
            // 
            // lbxTel
            // 
            this.lbxTel.AutoSize = true;
            this.lbxTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbxTel.Location = new System.Drawing.Point(70, 180);
            this.lbxTel.Name = "lbxTel";
            this.lbxTel.Size = new System.Drawing.Size(72, 18);
            this.lbxTel.TabIndex = 57;
            this.lbxTel.Text = "N° TÈL :";
            // 
            // lbxPrenom
            // 
            this.lbxPrenom.AutoSize = true;
            this.lbxPrenom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbxPrenom.Location = new System.Drawing.Point(51, 133);
            this.lbxPrenom.Name = "lbxPrenom";
            this.lbxPrenom.Size = new System.Drawing.Size(91, 18);
            this.lbxPrenom.TabIndex = 56;
            this.lbxPrenom.Text = "PRÉNOM :";
            // 
            // tbxMail
            // 
            this.tbxMail.Location = new System.Drawing.Point(149, 213);
            this.tbxMail.Multiline = true;
            this.tbxMail.Name = "tbxMail";
            this.tbxMail.Size = new System.Drawing.Size(193, 29);
            this.tbxMail.TabIndex = 55;
            this.tbxMail.TextChanged += new System.EventHandler(this.tbxMail_TextChanged);
            // 
            // tbxTel
            // 
            this.tbxTel.Location = new System.Drawing.Point(151, 169);
            this.tbxTel.Multiline = true;
            this.tbxTel.Name = "tbxTel";
            this.tbxTel.Size = new System.Drawing.Size(193, 29);
            this.tbxTel.TabIndex = 54;
            this.tbxTel.TextChanged += new System.EventHandler(this.tbxTel_TextChanged);
            // 
            // tbxPrenom
            // 
            this.tbxPrenom.Location = new System.Drawing.Point(151, 122);
            this.tbxPrenom.Multiline = true;
            this.tbxPrenom.Name = "tbxPrenom";
            this.tbxPrenom.Size = new System.Drawing.Size(193, 29);
            this.tbxPrenom.TabIndex = 53;
            this.tbxPrenom.TextChanged += new System.EventHandler(this.tbxPrenom_TextChanged);
            // 
            // tbxNom
            // 
            this.tbxNom.Location = new System.Drawing.Point(151, 77);
            this.tbxNom.Multiline = true;
            this.tbxNom.Name = "tbxNom";
            this.tbxNom.Size = new System.Drawing.Size(193, 28);
            this.tbxNom.TabIndex = 52;
            this.tbxNom.TextChanged += new System.EventHandler(this.tbxNom_TextChanged);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Font = new System.Drawing.Font("Reem Kufi", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.Location = new System.Drawing.Point(54, 321);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(127, 37);
            this.btnAnnuler.TabIndex = 51;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Font = new System.Drawing.Font("Reem Kufi", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.Location = new System.Drawing.Point(217, 321);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(127, 38);
            this.btnSupprimer.TabIndex = 50;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnAjouter
            // 
            this.btnAjouter.Font = new System.Drawing.Font("Reem Kufi", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.Location = new System.Drawing.Point(55, 319);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(127, 38);
            this.btnAjouter.TabIndex = 49;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Font = new System.Drawing.Font("Reem Kufi", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrer.Location = new System.Drawing.Point(217, 321);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(127, 36);
            this.btnEnregistrer.TabIndex = 48;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.Font = new System.Drawing.Font("Reem Kufi", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifier.Location = new System.Drawing.Point(133, 364);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(127, 38);
            this.btnModifier.TabIndex = 47;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // frmEnregistrementMembres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Enregistrer2);
            this.Controls.Add(this.Annuler2);
            this.Controls.Add(this.lstMembre);
            this.Controls.Add(this.lbxFindLigue);
            this.Controls.Add(this.cbxFindLigue);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lbxNom);
            this.Controls.Add(this.lbxMail);
            this.Controls.Add(this.lbxLigue);
            this.Controls.Add(this.lbxTel);
            this.Controls.Add(this.lbxPrenom);
            this.Controls.Add(this.tbxMail);
            this.Controls.Add(this.tbxTel);
            this.Controls.Add(this.tbxPrenom);
            this.Controls.Add(this.tbxNom);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.label1);
            this.Name = "frmEnregistrementMembres";
            this.Text = "Enregistrement membres";
            this.Load += new System.EventHandler(this.frmEnregistrementMembres_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Enregistrer2;
        private System.Windows.Forms.Button Annuler2;
        private System.Windows.Forms.ListBox lstMembre;
        private System.Windows.Forms.Label lbxFindLigue;
        private System.Windows.Forms.ComboBox cbxFindLigue;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lbxNom;
        private System.Windows.Forms.Label lbxMail;
        private System.Windows.Forms.Label lbxLigue;
        private System.Windows.Forms.Label lbxTel;
        private System.Windows.Forms.Label lbxPrenom;
        private System.Windows.Forms.TextBox tbxMail;
        private System.Windows.Forms.TextBox tbxTel;
        private System.Windows.Forms.TextBox tbxPrenom;
        private System.Windows.Forms.TextBox tbxNom;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnModifier;
    }
}