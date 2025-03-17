using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jpo
{
    public partial class frmEnregistrementMembres : Form
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\zaki3\Desktop\jpoTest1\jpo\jpo.accdb";
        private readonly object btnAnnuler2;
        private string ancienNom;
        private string ancienPrenom;
        public frmEnregistrementMembres()
        {
            InitializeComponent();
        }
        private void LoadMembres()
        {
            lstMembre.Items.Clear(); // Vide la liste avant de la recharger

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT nom, prénom FROM membre";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nom = reader["nom"].ToString();
                        string prenom = reader["prénom"].ToString();
                        string membre = $"{nom} {prenom}";

                        lstMembre.Items.Add(membre);
                    }
                }
            }
        }
        private void lstMembre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstMembre.SelectedIndex != -1) // Vérifie qu'un membre est sélectionné
            {

                tbxNom.Enabled = false;
                tbxPrenom.Enabled = false;
                tbxTel.Enabled = false;
                tbxMail.Enabled = false;
                comboBox1.Enabled = false;
                btnAjouter.Visible = true;
                btnAnnuler.Visible = false;
                btnEnregistrer.Visible = false;
                btnModifier.Visible = true;
                btnSupprimer.Visible = true;

                string selectedItem = lstMembre.SelectedItem.ToString();
                string[] nomPrenomParts = selectedItem.Split(' ');
                string nom = nomPrenomParts[0];
                string prenom = nomPrenomParts[1];
                


                try
                {

                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();



                        string query = "SELECT * FROM membre WHERE nom = @nom AND prenom = @prenom";
                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@nom", nom); // Envoyer un STRING
                            cmd.Parameters.AddWithValue("@prenom", prenom);


                            using (OleDbDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    tbxNom.Text = reader["nom"].ToString();
                                    tbxPrenom.Text = reader["prénom"].ToString();
                                    tbxTel.Text = reader["téléphone"].ToString();
                                    tbxMail.Text = reader["mail"].ToString();
                                    string codeLigue = reader["codeLigue"].ToString();
                                    for (int i = 0; i < comboBox1.Items.Count; i++)
                                    {
                                        if (((KeyValuePair<string, string>)comboBox1.Items[i]).Key == codeLigue)
                                        {
                                            comboBox1.SelectedIndex = i;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Aucun membre trouvé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tbxNom_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbxFindLigue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFindLigue.SelectedIndex != -1) // Vérifie qu'une ligue est sélectionnée
            {
                string codeLigue = ((KeyValuePair<string, string>)cbxFindLigue.SelectedItem).Key;

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT codeMembre, nom, prénom FROM membre WHERE codeLigue = ?";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", codeLigue);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            lstMembre.Items.Clear(); // Nettoie la liste avant d'ajouter les nouveaux membres

                            while (reader.Read())
                            {

                                string nomPrenom = $"{reader["nom"]} {reader["prénom"]}"; // Affichage : "Nom Prénom"
                                lstMembre.Items.Add(nomPrenom);
                            }
                        }
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFindLigue.SelectedIndex != -1) // Vérifie qu'une ligue est sélectionnée
            {
                string codeLigue = ((KeyValuePair<string, string>)cbxFindLigue.SelectedItem).Key;

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT codeMembre, nom, prénom FROM membre WHERE codeLigue = ?";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", codeLigue);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            lstMembre.Items.Clear(); // Nettoie la liste avant d'ajouter les nouveaux membres

                            while (reader.Read())
                            {

                                string nomPrenom = $"{reader["nom"]} {reader["prénom"]}"; // Affichage : "Nom Prénom"
                                lstMembre.Items.Add(nomPrenom);
                            }
                        }
                    }
                }

                lstMembre.DisplayMember = "Value"; // Afficher "Nom Prénom"
                lstMembre.ValueMember = "Key"; // Stocker "codeMembre"
            }
        }

        private void Enregistrer2_Click(object sender, EventArgs e)
        {
            // Vérifie que nom et prénom ne sont pas vides
            if (string.IsNullOrEmpty(ancienNom) || string.IsNullOrEmpty(ancienPrenom))
            {
                MessageBox.Show("Veuillez entrer un Nom et un Prénom valides.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string codeMembre = "";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                // 1️⃣ Récupérer le codeMembre depuis la base
                string getCodeQuery = "SELECT codeMembre FROM membre WHERE nom = @nom AND prénom = @prenom";
                using (OleDbCommand getCodeCmd = new OleDbCommand(getCodeQuery, conn))
                {
                    getCodeCmd.Parameters.AddWithValue("@nom", ancienNom);
                    getCodeCmd.Parameters.AddWithValue("@prenom", ancienPrenom);

                    object result = getCodeCmd.ExecuteScalar();
                    if (result != null)
                    {
                        codeMembre = result.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Aucun membre trouvé avec ce Nom et Prénom.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // 2️⃣ Modifier les informations du membre
                string nouveauPrenom = tbxPrenom.Text;
                string nouveauNom = tbxNom.Text;
                string nouveauTel = tbxTel.Text;
                string nouveauMail = tbxMail.Text;
                int intLigue = comboBox1.SelectedIndex + 1;
                string nouvelleLigue = intLigue.ToString();




                string updateQuery = "UPDATE membre SET nom = @nouvNom, prénom = @nouvPrenom, téléphone = @tel, mail = @mail, codeLigue = @nouvLigue WHERE codeMembre = @codeMembre";

                using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, conn))
                {
                    updateCmd.Parameters.AddWithValue("@nouvPrenom", nouveauPrenom);
                    updateCmd.Parameters.AddWithValue("@nouvNom", nouveauNom);
                    updateCmd.Parameters.AddWithValue("@tel", nouveauTel);
                    updateCmd.Parameters.AddWithValue("@mail", nouveauMail);
                    updateCmd.Parameters.AddWithValue("@nouvLigue", nouvelleLigue);
                    updateCmd.Parameters.AddWithValue("@codeMembre", codeMembre);


                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Membre mis à jour avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                tbxNom.Enabled = false;
                tbxPrenom.Enabled = false;
                tbxTel.Enabled = false;
                tbxMail.Enabled = false;
                comboBox1.Enabled = false;

                // Cacher les boutons
                Annuler2.Visible = false;
                Enregistrer2.Visible = false;
                btnModifier.Visible = true;
                btnSupprimer.Visible = true;
                btnAjouter.Visible = true;

                LoadMembres();
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            // Récupération des valeurs saisies
            string nom = tbxNom.Text.Trim();
            string prenom = tbxPrenom.Text.Trim();
            string tel = tbxTel.Text.Trim();
            string mail = tbxMail.Text.Trim();

            // Vérifier si une ligue est sélectionnée
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner une ligue.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KeyValuePair<string, string> selectedLigue = (KeyValuePair<string, string>)comboBox1.SelectedItem;
            string codeLigue = selectedLigue.Key;

            // Vérifier que les champs obligatoires ne sont pas vides
            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(prenom) || string.IsNullOrEmpty(codeLigue))
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Connexion et insertion dans la base de données
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {


                    conn.Open();
                    string query = "INSERT INTO membre (codeMembre, nom, prénom, téléphone, mail, codeLigue) VALUES (@codeMembre, @nom, @prenom, @tel, @mail, @codeLigue)";

                    int newCodeMembre = 1; // Valeur par défaut si la table est vide
                    string strMembre = "";
                    using (OleDbCommand getMaxCmd = new OleDbCommand("SELECT MAX(VAL(codeMembre)) FROM membre", conn))
                    {


                        object result = getMaxCmd.ExecuteScalar();

                        if (result != DBNull.Value)
                        {

                            //probleme AVEC LE CODE MEMBRE PAS BON -> résolus probleme dans ma requete
                            newCodeMembre = Convert.ToInt32(result) + 1;
                            strMembre = Convert.ToString(newCodeMembre);

                        }

                    }

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@codeMembre", strMembre);
                        cmd.Parameters.AddWithValue("@nom", nom);
                        cmd.Parameters.AddWithValue("@prenom", prenom);
                        cmd.Parameters.AddWithValue("@tel", tel);
                        cmd.Parameters.AddWithValue("@mail", mail);
                        cmd.Parameters.AddWithValue("@codeLigue", codeLigue);

                        //  string queryPreview = $"INSERT INTO membre (codeMembre, nom, prénom, téléphone, mail, codeLigue) " +
                        //$"VALUES ('{strMembre}', '{nom}', '{prenom}', '{tel}', '{mail}', '{codeLigue}')";

                        //  MessageBox.Show(queryPreview);
                        cmd.ExecuteNonQuery(); // Exécution de la requête sans vérifier le retour

                        MessageBox.Show("Membre ajouté avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Recharger la liste des membres
                        LoadMembres();

                        // Désactiver les champs après l'ajout
                        tbxNom.Enabled = false;
                        tbxPrenom.Enabled = false;
                        tbxTel.Enabled = false;
                        tbxMail.Enabled = false;
                        comboBox1.Enabled = false;
                        btnEnregistrer.Enabled = false;

                        btnEnregistrer.Visible = false;
                        btnAnnuler.Visible = false;
                        btnModifier.Visible = true;
                        btnSupprimer.Visible = true;
                        btnAjouter.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'ajout du membre : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (lstMembre.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner un membre à supprimer.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedItem = lstMembre.SelectedItem.ToString().Trim();
            string nom = "";
            string prenom = "";

            // Gestion des deux formats possibles
            if (selectedItem.StartsWith("[") && selectedItem.Contains(","))
            {
                string[] parts = selectedItem.Trim('[', ']').Split(',');
                if (parts.Length > 1)
                {
                    string nomPrenom = parts[1].Trim();
                    string[] nomPrenomParts = nomPrenom.Split(' ');

                    if (nomPrenomParts.Length > 1)
                    {
                        nom = nomPrenomParts[0].Trim();
                        prenom = nomPrenomParts[1].Trim();
                    }
                }
            }
            else
            {
                string[] nomPrenomParts = selectedItem.Split(' ');

                if (nomPrenomParts.Length > 1)
                {
                    nom = nomPrenomParts[0].Trim();
                    prenom = nomPrenomParts[1].Trim();
                }
            }

            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(prenom))
            {
                MessageBox.Show("Erreur lors de la récupération des informations du membre.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirmation de suppression
            DialogResult result = MessageBox.Show($"Voulez-vous vraiment supprimer {nom} {prenom} ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM membre WHERE nom = ? AND prénom = ?";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", nom);
                        cmd.Parameters.AddWithValue("?", prenom);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        LoadMembres();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Le membre {nom} {prenom} a été supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Recharge la liste des membres après suppression
                        }
                        else
                        {
                            MessageBox.Show("Aucun membre trouvé à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            ancienNom = tbxNom.Text;       // Stocker l'ancien nom
            ancienPrenom = tbxPrenom.Text; // Stocker l'ancien prénom

            // Débloquer les champs et activer les boutons nécessaires
            tbxNom.Enabled = true;
            tbxPrenom.Enabled = true;
            tbxTel.Enabled = true;
            tbxMail.Enabled = true;
            comboBox1.Enabled = true;
            btnEnregistrer.Enabled = true;

            Enregistrer2.Visible = true;
            Annuler2.Visible = true;
            btnModifier.Visible = false;
            btnSupprimer.Visible = false;
            btnAjouter.Visible = false;
        }

        private void Annuler2_Click(object sender, EventArgs e)
        {
            tbxNom.Enabled = false;
            tbxPrenom.Enabled = false;
            tbxTel.Enabled = false;
            tbxMail.Enabled = false;
            comboBox1.Enabled = false;

            // Cacher les boutons
            Annuler2.Visible = false;
            Enregistrer2.Visible = false;
            btnModifier.Visible = true;
            btnSupprimer.Visible = true;
            btnAjouter.Visible = true;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            // Vider les champs
            tbxNom.Clear();
            tbxPrenom.Clear();
            tbxTel.Clear();
            tbxMail.Clear();
            comboBox1.SelectedIndex = -1; // Désélectionner la comboBox

            // Débloquer les champs et activer le bouton Enregistrer
            tbxNom.Enabled = true;
            tbxPrenom.Enabled = true;
            tbxTel.Enabled = true;
            tbxMail.Enabled = true;
            comboBox1.Enabled = true;
            btnEnregistrer.Enabled = true;

            btnEnregistrer.Visible = true;
            btnAnnuler.Visible = true;
            btnModifier.Visible = false;
            btnSupprimer.Visible = false;
            btnAjouter.Visible = false;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            tbxNom.Clear();
            tbxPrenom.Clear();
            tbxTel.Clear();
            tbxMail.Clear();
            cbxFindLigue.SelectedIndex = -1;

            tbxNom.Enabled = false;
            tbxPrenom.Enabled = false;
            tbxTel.Enabled = false;
            tbxMail.Enabled = false;
            comboBox1.Enabled = false;

            // Cacher les boutons
            btnEnregistrer.Visible = false;
            btnAnnuler.Visible = false;
            btnModifier.Visible = true;
            btnSupprimer.Visible = true;
            btnAjouter.Visible = true;
        }

        private void tbxMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxTel_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxPrenom_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmEnregistrementMembres_Load(object sender, EventArgs e)
        {
            btnEnregistrer.Visible = false;
            btnAnnuler.Visible = false;
            Enregistrer2.Visible = false;
            Annuler2.Visible = false;
            tbxNom.Enabled = false;
            tbxPrenom.Enabled = false;
            tbxTel.Enabled = false;
            tbxMail.Enabled = false;
            comboBox1.Enabled = false;

            if (DbConnex.etatConnection() != ConnectionState.Open)
            {
                DbConnex.connexionBase();
            }


            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT codeLigue, nomLigue FROM LIGUES";

                List<KeyValuePair<string, string>> ligues = new List<KeyValuePair<string, string>>();

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ligues.Add(new KeyValuePair<string, string>(
                            reader["codeLigue"].ToString(),
                            reader["nomLigue"].ToString()
                        ));
                    }
                }

                // Remplir les deux ComboBox
                comboBox1.DataSource = ligues;
                cbxFindLigue.DataSource = ligues;

                comboBox1.DisplayMember = "Value"; // Affiche le nom de la ligue
                comboBox1.ValueMember = "Key"; // Stocke le code de la ligue

                cbxFindLigue.DisplayMember = "Value";
                cbxFindLigue.ValueMember = "Key";
            }








            OleDbDataReader drMembres2 = DbConnex.GetDataReader("SELECT nom, prénom FROM membre");

            // Boucle pour ajouter chaque membre dans le ListView
            while (drMembres2.Read())
            {
                // Récupérer le nom et le prénom de chaque membre
                string nom = drMembres2["nom"].ToString();
                string prenom = drMembres2["prénom"].ToString();


                string membre = $"{nom} {prenom}";

                // Ajouter cette chaîne au ListBox
                lstMembre.Items.Add(membre);
            }



            DbConnex.connexionClose();
        }
    }
}
