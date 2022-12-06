using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.OracleClient;
using MySql.Data.MySqlClient;
using Connecte.Controleur;
using Connecte.Modele;
using Connecte.DAL;

namespace Connecte
{
    public partial class Front : Form
    {

        Mgr monManager;

        List<Secteur> lSecteur = new List<Secteur>();

        public Front()
        {
            InitializeComponent();

            monManager = new Mgr();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            lSecteur = monManager.chargementEmpBD();

        
        affiche();
        }

        public void affiche()

        {

            try
            {
                //Reset 
                listBoxSecteur.DataSource = null;
                //Connection BDD
                listBoxSecteur.DataSource = lSecteur;
                //Affiche la méthode
                listBoxSecteur.DisplayMember = "Description";

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Modifier
                Secteur unSecteur = (Secteur)listBoxSecteur.SelectedItem;

                unSecteur.Nom = tbLogin.Text;

                SecteurDAO.updateSecteur(unSecteur);

                lSecteur = monManager.chargementEmpBD();

                affiche();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //L'objet prend la liste de la lisaison
                Liaison uneLiaison = (Liaison)listBoxLiaison.SelectedItem;
                //la classe utilise la méthode deleteLiaison et prend la liste de lisaion
                LiaisonDAO.deleteLiaison(uneLiaison.idLiaison);



                //L'objet prend la liste des secteurs
                var secteur = listBoxSecteur.SelectedItem as Secteur;
                //La classe utilise la méthode et va chercher dans les id de la liste des secteurs
                listBoxLiaison.DataSource = LiaisonDAO.getLiaison(secteur.Id);
                //Affiche le return de la méthode description
                listBoxLiaison.DisplayMember = "Description";

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //Supprimer
            try
            {
                
                Secteur unSecteur = (Secteur)listBoxSecteur.SelectedItem;
                //La classe SecteurDAO utilise la méthode deleteSecteur qui va chercher dans la liste des secteurs
                SecteurDAO.deleteSecteur(unSecteur);


                //Utilisation de la BDD
                lSecteur = monManager.chargementEmpBD();
                listBoxSecteur.SelectedIndex= 0;
                //Affiche le résultat
                affiche();

            }

            catch (Exception ex)
            {
                //Si marche pas, il affichera l'erreur
                MessageBox.Show(ex.Message);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Création de l'objet uneLiaison qui prend la liste de liaison 
            Liaison uneLiaison = (Liaison)listBoxLiaison.SelectedItem;
            //La classe LiaisonDAO utilise la méthode modifLiaison et prend en paramètre l'id de la liste de liaison)
            LiaisonDAO.modifLiaison(uneLiaison.idLiaison, textBoxDureeLiaison.Text);

        }

        private void listBoxSecteur_SelectedIndexChanged(object sender, EventArgs e)
        {
            int secteur = listBoxSecteur.SelectedIndex;
            //Permet de reset, ou sinon il va garder les précédents valeurs
            listBoxLiaison.DataSource = null;
            //La classe LiaisonDAO va dans getLiaison et va dans l'id de la liste de secteur
            listBoxLiaison.DataSource = LiaisonDAO.getLiaison(secteur);
            //Permet d'afficher la description
            listBoxLiaison.DisplayMember = "Description";
        }

        private void listBoxLiaison_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxDureeLiaison_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void buttonAjout_Click(object sender, EventArgs e)
        {
            Liaison uneLiaison = (Liaison)listBoxLiaison.SelectedItem;
            //Permet de reset, ou sinon il va garder les précédents valeurs
            listBoxLiaison.DataSource = null;
            LiaisonDAO.ajoutLiaison(textBoxDureeAjout.Text,  Convert.ToInt32(textBoxPortDepAjout.Text), Convert.ToInt32(textBoxPortArrAjout.Text),Convert.ToInt32(textBoxIdSecteur.Text));
            // Ajout



        }

        private void textBoxPortDepAjout_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }


}

           
            
            
        
            
           
        
    

