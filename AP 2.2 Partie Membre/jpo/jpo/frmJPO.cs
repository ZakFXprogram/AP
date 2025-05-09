﻿using System;
using System.Windows.Forms;

namespace jpo
{
    public partial class frmJPO : Form
    {
        public frmJPO()
        {
            InitializeComponent();
        }




 

        private void enregistrementLiguesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild.Text != "enregistrementLigues")
            {
                this.ActiveMdiChild.Close();
            }

            if (this.ActiveMdiChild == null)
            {
                frmEnregistrementLigues formEnregistrementLigues = new frmEnregistrementLigues();
                formEnregistrementLigues.MdiParent = this;
                formEnregistrementLigues.WindowState = FormWindowState.Maximized;
                formEnregistrementLigues.Show();
            }
        }

        private void inscriptionLiguesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild.Text != "inscriptionLigues")
            {
                this.ActiveMdiChild.Close();
            }

            if (this.ActiveMdiChild == null)
            {
                frmInscriptionLigues formInscriptionLigues = new frmInscriptionLigues();
                formInscriptionLigues.MdiParent = this;
                formInscriptionLigues.WindowState = FormWindowState.Maximized;
                formInscriptionLigues.Show();
            }
        }

        private void enregistrementMembresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild.Text != "enregistrementMembres")
            {
                this.ActiveMdiChild.Close();
            }

            if (this.ActiveMdiChild == null)
            {
                frmEnregistrementMembres formEnregistrementMembres = new frmEnregistrementMembres();
                formEnregistrementMembres.MdiParent = this;
                formEnregistrementMembres.WindowState = FormWindowState.Maximized;
                formEnregistrementMembres.Show();
            }
        }

        private void inscriptionMembresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild.Text != "inscriptionMembres")
            {
                this.ActiveMdiChild.Close();
            }

            if (this.ActiveMdiChild == null)
            {
                frmInscriptionMembres formInscriptionMembres = new frmInscriptionMembres();
                formInscriptionMembres.MdiParent = this;
                formInscriptionMembres.WindowState = FormWindowState.Maximized;
                formInscriptionMembres.Show();
            }
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
