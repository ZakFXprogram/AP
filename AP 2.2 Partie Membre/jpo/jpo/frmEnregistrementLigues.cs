using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace jpo
{
    public partial class frmEnregistrementLigues : Form
    {
        public frmEnregistrementLigues()
        {
            InitializeComponent();
        }

        private void frmEnregistrementLigues_Load(object sender, EventArgs e)
        {
            if (DbConnex.etatConnection() != ConnectionState.Open)
            {
                DbConnex.connexionBase();
            }
            OleDbDataReader drLigues = DbConnex.GetDataReader("select * from ligues");
            while (drLigues.Read())
            {
                MessageBox.Show(drLigues.GetString(1));
            }
            DbConnex.connexionClose();
        }
    }
}
