using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace jpo
{
    class DbConnex
    {
        private static OleDbConnection connex = new System.Data.OleDb.OleDbConnection();
        private static string connexString = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data source=..\..\..\..\jpo.accdb";

        public static void connexionBase()
        {
            try
            {
                connex.ConnectionString = connexString;
                connex.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static System.Data.ConnectionState etatConnection()
        {
            return connex.State;
        }

        public static void connexionClose()
        {
            connex.Close();
        
        }

        public static OleDbDataReader GetDataReader(string uneRequete)
        {
            try
            {
                OleDbCommand oleCommande = new OleDbCommand(uneRequete, connex);
                OleDbDataReader reader = oleCommande.ExecuteReader();
                return reader;
            }

            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }


        public static int Unscalar(string uneRequete)
        {
            try
            {
                OleDbCommand oleCommande = new OleDbCommand(uneRequete, connex);
                int unNB = (Int32)oleCommande.ExecuteScalar();
                return unNB;
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        public static int nonQuery(string uneRequete)
        {
            try
            {
                OleDbCommand oleCommande = new OleDbCommand(uneRequete, connex);
                int reponse = oleCommande.ExecuteNonQuery();
                return reponse;
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }   
    }
}
