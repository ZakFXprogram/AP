
namespace jpo
{
    partial class frmInscriptionMembres
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
            this.lstInscription = new System.Windows.Forms.ListBox();
            this.btnEnregistrer2 = new System.Windows.Forms.Button();
            this.btnAnnuler2 = new System.Windows.Forms.Button();
            this.lbxMembre = new System.Windows.Forms.Label();
            this.cbxActivite = new System.Windows.Forms.ComboBox();
            this.lbxActi = new System.Windows.Forms.Label();
            this.lbxCreneau = new System.Windows.Forms.Label();
            this.cbxPlage = new System.Windows.Forms.ComboBox();
            this.cbxMembres = new System.Windows.Forms.ComboBox();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(298, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Inscription membres";
            // 
            // lstInscription
            // 
            this.lstInscription.Font = new System.Drawing.Font("Reem Kufi", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstInscription.FormattingEnabled = true;
            this.lstInscription.ItemHeight = 27;
            this.lstInscription.Location = new System.Drawing.Point(380, 130);
            this.lstInscription.Name = "lstInscription";
            this.lstInscription.Size = new System.Drawing.Size(368, 193);
            this.lstInscription.TabIndex = 33;
            this.lstInscription.SelectedIndexChanged += new System.EventHandler(this.lstInscription_SelectedIndexChanged);
            // 
            // btnEnregistrer2
            // 
            this.btnEnregistrer2.Font = new System.Drawing.Font("Reem Kufi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrer2.Location = new System.Drawing.Point(188, 286);
            this.btnEnregistrer2.Name = "btnEnregistrer2";
            this.btnEnregistrer2.Size = new System.Drawing.Size(129, 36);
            this.btnEnregistrer2.TabIndex = 32;
            this.btnEnregistrer2.Text = "Enregistrer";
            this.btnEnregistrer2.UseVisualStyleBackColor = true;
            this.btnEnregistrer2.Click += new System.EventHandler(this.btnEnregistrer2_Click);
            // 
            // btnAnnuler2
            // 
            this.btnAnnuler2.Font = new System.Drawing.Font("Reem Kufi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler2.Location = new System.Drawing.Point(53, 286);
            this.btnAnnuler2.Name = "btnAnnuler2";
            this.btnAnnuler2.Size = new System.Drawing.Size(129, 36);
            this.btnAnnuler2.TabIndex = 31;
            this.btnAnnuler2.Text = "Annuler";
            this.btnAnnuler2.UseVisualStyleBackColor = true;
            this.btnAnnuler2.Click += new System.EventHandler(this.btnAnnuler2_Click);
            // 
            // lbxMembre
            // 
            this.lbxMembre.AutoSize = true;
            this.lbxMembre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxMembre.Location = new System.Drawing.Point(147, 178);
            this.lbxMembre.Name = "lbxMembre";
            this.lbxMembre.Size = new System.Drawing.Size(72, 13);
            this.lbxMembre.TabIndex = 30;
            this.lbxMembre.Text = "MEMBRE : ";
            // 
            // cbxActivite
            // 
            this.cbxActivite.FormattingEnabled = true;
            this.cbxActivite.Location = new System.Drawing.Point(122, 130);
            this.cbxActivite.Name = "cbxActivite";
            this.cbxActivite.Size = new System.Drawing.Size(121, 21);
            this.cbxActivite.TabIndex = 29;
            this.cbxActivite.SelectedIndexChanged += new System.EventHandler(this.cbxActivite_SelectedIndexChanged);
            // 
            // lbxActi
            // 
            this.lbxActi.AutoSize = true;
            this.lbxActi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxActi.Location = new System.Drawing.Point(147, 114);
            this.lbxActi.Name = "lbxActi";
            this.lbxActi.Size = new System.Drawing.Size(75, 13);
            this.lbxActi.TabIndex = 28;
            this.lbxActi.Text = "ACTIVITÉ : ";
            // 
            // lbxCreneau
            // 
            this.lbxCreneau.AutoSize = true;
            this.lbxCreneau.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxCreneau.Location = new System.Drawing.Point(454, 90);
            this.lbxCreneau.Name = "lbxCreneau";
            this.lbxCreneau.Size = new System.Drawing.Size(78, 13);
            this.lbxCreneau.TabIndex = 27;
            this.lbxCreneau.Text = "CRÉNEAU : ";
            // 
            // cbxPlage
            // 
            this.cbxPlage.FormattingEnabled = true;
            this.cbxPlage.Location = new System.Drawing.Point(538, 87);
            this.cbxPlage.Name = "cbxPlage";
            this.cbxPlage.Size = new System.Drawing.Size(121, 21);
            this.cbxPlage.TabIndex = 26;
            this.cbxPlage.SelectedIndexChanged += new System.EventHandler(this.cbxPlage_SelectedIndexChanged);
            // 
            // cbxMembres
            // 
            this.cbxMembres.FormattingEnabled = true;
            this.cbxMembres.Location = new System.Drawing.Point(92, 194);
            this.cbxMembres.Name = "cbxMembres";
            this.cbxMembres.Size = new System.Drawing.Size(180, 21);
            this.cbxMembres.TabIndex = 25;
            this.cbxMembres.SelectedIndexChanged += new System.EventHandler(this.cbxMembres_SelectedIndexChanged);
            // 
            // btnModifier
            // 
            this.btnModifier.Font = new System.Drawing.Font("Reem Kufi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifier.Location = new System.Drawing.Point(53, 286);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(129, 36);
            this.btnModifier.TabIndex = 24;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnAjouter
            // 
            this.btnAjouter.Font = new System.Drawing.Font("Reem Kufi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.Location = new System.Drawing.Point(188, 287);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(129, 36);
            this.btnAjouter.TabIndex = 23;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Font = new System.Drawing.Font("Reem Kufi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.Location = new System.Drawing.Point(53, 286);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(129, 36);
            this.btnAnnuler.TabIndex = 22;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Font = new System.Drawing.Font("Reem Kufi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrer.Location = new System.Drawing.Point(188, 286);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(129, 36);
            this.btnEnregistrer.TabIndex = 21;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Font = new System.Drawing.Font("Reem Kufi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.Location = new System.Drawing.Point(114, 328);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(129, 36);
            this.btnSupprimer.TabIndex = 20;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // frmInscriptionMembres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstInscription);
            this.Controls.Add(this.btnEnregistrer2);
            this.Controls.Add(this.btnAnnuler2);
            this.Controls.Add(this.lbxMembre);
            this.Controls.Add(this.cbxActivite);
            this.Controls.Add(this.lbxActi);
            this.Controls.Add(this.lbxCreneau);
            this.Controls.Add(this.cbxPlage);
            this.Controls.Add(this.cbxMembres);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.label1);
            this.Name = "frmInscriptionMembres";
            this.Text = "frmInscriptionMembres";
            this.Load += new System.EventHandler(this.frmInscriptionMembres_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstInscription;
        private System.Windows.Forms.Button btnEnregistrer2;
        private System.Windows.Forms.Button btnAnnuler2;
        private System.Windows.Forms.Label lbxMembre;
        private System.Windows.Forms.ComboBox cbxActivite;
        private System.Windows.Forms.Label lbxActi;
        private System.Windows.Forms.Label lbxCreneau;
        private System.Windows.Forms.ComboBox cbxPlage;
        private System.Windows.Forms.ComboBox cbxMembres;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnSupprimer;
    }
}