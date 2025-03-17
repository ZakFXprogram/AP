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
    public partial class frmInscriptionMembres : Form
    {
        string connectionString2 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\zaki3\Desktop\jpoTest1\jpo\jpo.accdb";
        private bool enModification = false;
        string ancienCreneau;
        public frmInscriptionMembres()
        {
            InitializeComponent();
        }
        private void LoadCreneaux()
        {
            cbxPlage.Items.Clear(); // Nettoie la ComboBox avant d'ajouter les nouveaux éléments

            List<KeyValuePair<string, string>> creneauxList = new List<KeyValuePair<string, string>>();

            using (OleDbConnection conn = new OleDbConnection(connectionString2))
            {
                conn.Open();
                string query = "SELECT codeCréneau, libelléCréneau FROM CRENEAU";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string code = reader["codeCréneau"].ToString();
                        string libelle = reader["libelléCréneau"].ToString();

                        // Ajoute le créneau dans la liste
                        creneauxList.Add(new KeyValuePair<string, string>(code, libelle));
                    }
                }
            }

            // Assigne la liste comme source de données
            cbxPlage.DataSource = creneauxList;
            cbxPlage.DisplayMember = "Value"; // Ce qui saffiche
            cbxPlage.ValueMember = "Key"; // Ce qui est stock dérrière
        }

        private void LoadActivités()
        {
            List<KeyValuePair<string, string>> activites = new List<KeyValuePair<string, string>>();
            // Nettoie la ComboBox avant d'ajouter les nouveaux éléments
            activites.Clear();
            using (OleDbConnection conn = new OleDbConnection(connectionString2))
            {
                conn.Open();
                string query = "SELECT codeActiv, LibelleActiv FROM ACTIVITE";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    //List<KeyValuePair<string, string>> activites = new List<KeyValuePair<string, string>>();

                    while (reader.Read())
                    {
                        string code = reader["codeActiv"].ToString();
                        string libelle = reader["LibelleActiv"].ToString();
                        activites.Add(new KeyValuePair<string, string>(code, libelle));
                    }

                    cbxActivite.DataSource = activites;  // Remplit la ComboBox
                    cbxActivite.DisplayMember = "Value"; // Affiche le libellé (ex: Animation)
                    cbxActivite.ValueMember = "Key";     // Stocke le code (ex: A)
                }

            }
        }

        private void LoadMembres()
        {
            // Nettoie la ComboBox avant d'ajouter les nouveaux éléments

            List<KeyValuePair<string, string>> membresList = new List<KeyValuePair<string, string>>();
            membresList.Clear();

            using (OleDbConnection conn = new OleDbConnection(connectionString2))
            {
                conn.Open();
                string query = "SELECT codeMembre, nom, prénom FROM membre";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string codeMembre = reader["codeMembre"].ToString();
                        string nomPrenom = reader["nom"].ToString() + " " + reader["prénom"].ToString();

                        membresList.Add(new KeyValuePair<string, string>(codeMembre, nomPrenom));
                    }
                }
            }

            // On assigne la liste comme source de données
            cbxMembres.DataSource = membresList;
            cbxMembres.DisplayMember = "Value"; // Affiche "Nom Prénom"
            cbxMembres.ValueMember = "Key"; // Stocke "codeMembre"

        }

        private void LoadMembresIns()
        {
            lstInscription.Items.Clear();
            DbConnex.connexionBase();  // Ouvre la connexion à la base de données
            OleDbDataReader drMembres3 = DbConnex.GetDataReader("SELECT M.nom, M.prénom, C.libelléCréneau, A.LibelleActiv FROM MEMBRE AS M, PARTICIPER AS P, CRENEAU AS C, ACTIVITE AS A WHERE M.codeMembre = P.codeMembre\r\nAND P.codeCréneau = C.codeCréneau AND P.codeActivité = A.codeActiv;");

            // Boucle pour ajouter chaque ligne dans le ListBox
            while (drMembres3.Read())
            {
                string nom = drMembres3["nom"].ToString();
                string prenom = drMembres3["prénom"].ToString();
                string creneau = drMembres3["libelléCréneau"].ToString();
                string activite = drMembres3["LibelleActiv"].ToString();

                string membre = $"{nom} {prenom} - {creneau} - {activite}";

                // Ajouter l'entrée formatée au ListBox
                lstInscription.Items.Add(membre);
            }
            ;

            DbConnex.connexionClose();
        }
        private void frmInscriptionMembres_Load(object sender, EventArgs e)
        {
            LoadCreneaux();
            cbxPlage.SelectedIndex = -1;//A rajouter sur l'autre pour la propreté
            LoadActivités();
            cbxActivite.SelectedIndex = -1;//A rajouter sur l'autre pour la propreté
            LoadMembres();
            cbxPlage.Enabled = true;
            cbxMembres.Enabled = false;
            cbxActivite.Enabled = false;
            LoadMembresIns();
            // Récupérer les nouvelles valeurs sélectionnées dans les combobox



            // Cacher les boutons
            btnAnnuler.Visible = false;
            btnEnregistrer.Visible = false;
            btnAnnuler2.Visible = false;
            btnEnregistrer2.Visible = false;
            btnModifier.Visible = true;
            btnSupprimer.Visible = true;
            btnAjouter.Visible = true;
        }

        private void cbxPlage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (enModification)
            {
                return;

            }
            if (cbxPlage.SelectedItem != null)
            {
                // Sauvegarder l'ancienne valeur avant de la changer
                ancienCreneau = cbxPlage.SelectedValue.ToString();


            }
            if (cbxPlage.SelectedIndex != -1)
            {
                string creneauSelectionne = cbxPlage.SelectedItem.ToString();
                string resultat = creneauSelectionne.Substring(creneauSelectionne.IndexOf(',') + 2).TrimEnd(']');

                lstInscription.Items.Clear();

                string query = "SELECT M.nom, M.prénom, C.libelléCréneau, A.LibelleActiv " +
                               "FROM MEMBRE AS M, PARTICIPER AS P, CRENEAU AS C, ACTIVITE AS A " +
                               "WHERE M.codeMembre = P.codeMembre " +
                               "AND P.codeCréneau = C.codeCréneau " +
                               "AND P.codeActivité = A.codeActiv " +
                               "AND C.libelléCréneau = @crecre";

                using (OleDbConnection conn = new OleDbConnection(connectionString2)) // Utilise la chaîne de connexion
                {
                    try
                    {
                        conn.Open();

                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@crecre", resultat);

                            using (OleDbDataReader drMembres3 = cmd.ExecuteReader())
                            {
                                while (drMembres3.Read())
                                {
                                    string nom = drMembres3["nom"].ToString();
                                    string prenom = drMembres3["prénom"].ToString();
                                    string creneau = drMembres3["libelléCréneau"].ToString();
                                    string activite = drMembres3["LibelleActiv"].ToString();

                                    string membre = $"{nom} {prenom} - {creneau} - {activite}";

                                    lstInscription.Items.Add(membre);
                                }
                            }
                        }
                    }
                    catch (OleDbException ex)
                    {
                        // Gérez l'exception (par exemple, affichez un message d'erreur)
                        MessageBox.Show($"Erreur de base de données : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void lstInscription_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstInscription.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner une participation à supprimer.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedItem = lstInscription.SelectedItem.ToString().Trim();
            string nom = "";
            string prenom = "";
            string plage = "";
            string nomPrenom = "";
            string activite = "";
            // Gestion des deux formats possibles
            if (selectedItem.Contains(" - "))
            {
                string[] parts = selectedItem.Split('-');
                if (parts.Length > 1)
                {
                    nomPrenom = parts[0].Trim();
                    string[] nomPrenomParts = nomPrenom.Split(' ');
                    plage = parts[1].Trim();
                    activite = parts[2].Trim();

                    if (nomPrenomParts.Length > 1)
                    {
                        nom = nomPrenomParts[0].Trim();
                        prenom = nomPrenomParts[1].Trim();
                    }
                }
                //MessageBox.Show($"{nom}+{prenom}+{plage}+{activite}");
                // Vérif des élément dans mes variables
                //comparaison pour voir si un item correspond a ma variable biens sur la cbx associé à la variable
                for (int i = 0; i < cbxActivite.Items.Count; i++)
                {
                    var itemActivité = (KeyValuePair<string, string>)cbxActivite.Items[i];
                    if (itemActivité.Value == activite)
                    {
                        cbxActivite.SelectedIndex = i; // Change l'index sélectionné
                        break;
                    }
                }

                //On répète le processus
                for (int i = 0; i < cbxMembres.Items.Count; i++)
                {
                    var itemduMembre = (KeyValuePair<string, string>)cbxMembres.Items[i];
                    if (itemduMembre.Value == nomPrenom)
                    {
                        cbxMembres.SelectedIndex = i;
                        break;
                    }
                }

                //On répète le processus poure les créeneaux au passage Plage(Horaire)/Créneau je veux déssigner la meme chose en terme de sens
                for (int i = 0; i < cbxPlage.Items.Count; i++)
                {
                    var itemduCréneau = (KeyValuePair<string, string>)cbxPlage.Items[i];
                    if (itemduCréneau.Value == plage)
                    {
                        cbxPlage.SelectedIndex = i;
                        break;
                    }
                }


            }
        }

        private void cbxActivite_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxMembres_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAnnuler2_Click(object sender, EventArgs e)
        {
            enModification = false;
            LoadMembresIns();
            cbxMembres.Enabled = false;
            cbxActivite.Enabled = false;


            // Cacher les boutons
            btnAnnuler2.Visible = false;
            btnEnregistrer2.Visible = false;
            btnModifier.Visible = true;
            btnSupprimer.Visible = true;
            btnAjouter.Visible = true;
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            enModification = true;  // Désactive le rafraîchissement


            cbxMembres.Enabled = true;
            cbxActivite.Enabled = true;


            // Cacher les boutons
            btnAnnuler2.Visible = true;
            btnEnregistrer2.Visible = true;
            btnModifier.Visible = false;
            btnSupprimer.Visible = false;
            btnAjouter.Visible = false;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            cbxMembres.Enabled = false;
            cbxActivite.Enabled = false;


            // Cacher les boutons
            btnAnnuler.Visible = false;
            btnEnregistrer.Visible = false;
            btnModifier.Visible = true;
            btnSupprimer.Visible = true;
            btnAjouter.Visible = true;
        }

        private void btnEnregistrer2_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérifier qu'un élément est sélectionné dans lstInscription
                if (lstInscription.SelectedItem == null)
                {
                    MessageBox.Show("Veuillez sélectionner une inscription à modifier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Vérifier que toutes les combobox ont une valeur sélectionnée
                if (cbxMembres.SelectedValue == null || cbxActivite.SelectedValue == null || cbxPlage.SelectedValue == null)
                {
                    MessageBox.Show("Veuillez sélectionner un membre, une activité et un créneau.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Récupérer les valeurs de l'inscription sélectionnée dans lstInscription
                string ancienneInscription = lstInscription.SelectedItem.ToString();
                string[] parts = ancienneInscription.Split('-'); // Supposons un format : "Nom Prénom - Créneau - Activité"
                if (parts.Length < 3)
                {
                    MessageBox.Show("Format d'inscription incorrect.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string nomPrenom = parts[0].Trim();
                //string ancienCreneau = cbxPlage.SelectedValue.ToString();
                string ancienneActivite = cbxActivite.SelectedValue.ToString();

                // Récupérer le codeMembre correspondant au nom et prénom
                string queryMembre = "SELECT codeMembre FROM MEMBRE WHERE nom + ' ' + prénom = @nomPrenom";
                string codeMembre = "";

                using (OleDbConnection conn = new OleDbConnection(connectionString2))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(queryMembre, conn))
                    {
                        cmd.Parameters.AddWithValue("@nomPrenom", nomPrenom);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            codeMembre = result.ToString();

                        }

                    }
                }

                if (string.IsNullOrEmpty(codeMembre))
                {
                    MessageBox.Show("Impossible de trouver le membre sélectionné.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string nouveauCreneau = cbxPlage.SelectedValue.ToString().Trim();
                string nouvelleActivite = cbxActivite.SelectedValue.ToString().Trim();


                using (OleDbConnection conn = new OleDbConnection(connectionString2))
                {
                    conn.Open();

                    // Supprimer l'ancienne inscription
                    string supprReq = "DELETE FROM PARTICIPER WHERE codeMembre = @codeMembre AND codeCréneau = @ancienCreneau";
                    using (OleDbCommand cmdDelete = new OleDbCommand(supprReq, conn))
                    {
                        cmdDelete.Parameters.AddWithValue("@codeMembre", codeMembre);
                        cmdDelete.Parameters.AddWithValue("@ancienCreneau", ancienCreneau);
                        cmdDelete.ExecuteNonQuery();
                        MessageBox.Show($"{ancienCreneau} ");
                    }
                    System.Threading.Thread.Sleep(200);
                    LoadMembresIns();
                    // Insérer la nouvelle inscription
                    string insertReq = "INSERT INTO PARTICIPER (codeMembre, codeCréneau, codeActivité) VALUES (@codeMembre, @nouveauCreneau, @nouvelleActivite)";
                    using (OleDbCommand cmdInsert = new OleDbCommand(insertReq, conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@codeMembre", codeMembre);
                        cmdInsert.Parameters.AddWithValue("@nouveauCreneau", nouveauCreneau);
                        cmdInsert.Parameters.AddWithValue("@nouvelleActivite", nouvelleActivite);
                        cmdInsert.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Inscription modifiée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recharger la liste des inscriptions après la modification
                LoadMembresIns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            enModification = false;
            // Recharger la liste des inscriptions après la modification
            LoadMembresIns();
            cbxMembres.Enabled = false;
            cbxActivite.Enabled = false;


            // Cacher les boutons
            btnAnnuler2.Visible = false;
            btnEnregistrer2.Visible = false;
            btnModifier.Visible = true;
            btnSupprimer.Visible = true;
            btnAjouter.Visible = true;
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            try
            {

                // Vérifier que toutes les combobox ont une valeur sélectionnée
                if (cbxMembres.SelectedValue == null || cbxActivite.SelectedValue == null || cbxPlage.SelectedValue == null)
                {
                    MessageBox.Show("Veuillez sélectionner un membre, une activité et un créneau.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Récupérer les valeurs sélectionnées
                string codeMembre = cbxMembres.SelectedValue.ToString();
                string codeActivité = cbxActivite.SelectedValue.ToString();
                string codeCréneau = cbxPlage.SelectedValue.ToString();
                MessageBox.Show($"Vérification des codes :  {codeMembre} {codeActivité} {codeCréneau}");





                // Construire la requête SQL pour insérer la participation
                string query = "INSERT INTO participer (codeMembre, codeCréneau, codeActivité) VALUES (@codeMembre, @codeCréneau, @codeActivité)";

                using (OleDbConnection conn = new OleDbConnection(connectionString2))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@codeMembre", codeMembre);
                        cmd.Parameters.AddWithValue("@codeCréneau", codeCréneau);
                        cmd.Parameters.AddWithValue("@codeActivité", codeActivité);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Participation enregistrée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadMembresIns();
            cbxPlage.Enabled = true;
            cbxMembres.Enabled = false;
            cbxActivite.Enabled = false;
            // Cacher les boutons
            btnAnnuler.Visible = false;
            btnEnregistrer.Visible = false;
            btnAnnuler2.Visible = false;
            btnEnregistrer2.Visible = false;
            btnModifier.Visible = true;
            btnSupprimer.Visible = true;
            btnAjouter.Visible = true;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            cbxMembres.Enabled = true;
            cbxActivite.Enabled = true;


            // Cacher les boutons
            btnAnnuler.Visible = true;
            btnEnregistrer.Visible = true;
            btnModifier.Visible = false;
            btnSupprimer.Visible = false;
            btnAjouter.Visible = false;
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (lstInscription.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner une participation à supprimer.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string codePlage = cbxPlage.Text;
            string codeMembre = cbxMembres.Text;

            // Confirmation de suppression
            DialogResult result = MessageBox.Show($"Voulez-vous vraiment supprimer la participation de {codeMembre} dans le/l'{codePlage} ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            string codePlage2 = cbxPlage.SelectedValue.ToString();
            string codeMembre2 = cbxMembres.SelectedValue.ToString();
            if (string.IsNullOrEmpty(codeMembre2) || string.IsNullOrEmpty(codePlage2))
            {
                MessageBox.Show("Erreur lors de la récupération des informations du membre.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show($"{codeMembre2} + {codePlage2}"); //Sa me récupère les bonne valeur pour la suite !
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString2))
                {
                    conn.Open();
                    string query = "DELETE FROM participer WHERE codeMembre = @membree AND codeCréneau = @crecreno";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@membree", codeMembre2);
                        cmd.Parameters.AddWithValue("@crecreno", codePlage2);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        LoadMembres();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"La participation de {codeMembre} pour ce/cette {codePlage} a été supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Recharge la liste des membres après suppression
                        }
                        else
                        {
                            MessageBox.Show("Aucune participation trouvé à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            LoadMembresIns();
        }
    }
}
