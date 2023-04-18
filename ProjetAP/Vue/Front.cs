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


            //Permet de reset, ou sinon il va garder les précédents valeurs
            comboBox2.DataSource = null;
            //La classe LiaisonDAO va dans getLiaison et va dans l'id de la liste de secteur
            comboBox2.DataSource = PortDAO.GetPort();
            //Permet d'afficher la description
            comboBox2.DisplayMember = "Description";


            //Permet de reset, ou sinon il va garder les précédents valeurs
            comboBox1.DataSource = null;
            //La classe LiaisonDAO va dans getLiaison et va dans l'id de la liste de secteur
            comboBox1.DataSource = PortDAO.GetPort();
            //Permet d'afficher la description
            comboBox1.DisplayMember = "Description";


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
                LiaisonDAO.deleteLiaison(uneLiaison.IdLiaison);



                //L'objet prend la liste des secteurs
                var secteur = listBoxSecteur.SelectedItem as Secteur;
                //La classe utilise la méthode et va chercher dans les id de la liste des secteurs
                listBoxLiaison.DataSource = LiaisonDAO.GetLiaison(secteur.Id);
                //Affiche le return de la méthode description
                listBoxLiaison.DisplayMember = "Description";
                affiche();
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
            LiaisonDAO.modifLiaison(uneLiaison.IdLiaison, textBoxDureeLiaison.Text);
            affiche();


        }

        private void listBoxSecteur_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Permet de prendre l'id de la chose sélectionnée
            int secteur = listBoxSecteur.SelectedIndex;
            //Permet de reset, ou sinon il va garder les précédents valeurs
            listBoxLiaison.DataSource = null;
            //La classe LiaisonDAO va dans getLiaison et va dans l'id de la liste de secteur
            listBoxLiaison.DataSource = LiaisonDAO.GetLiaison(secteur);
            //Permet d'afficher la description
            listBoxLiaison.DisplayMember = "Description";
        }

        private void listBoxLiaison_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Permet de prendre l'id de la chose sélectionnée
            Liaison liaisonSelec = listBoxLiaison.SelectedItem as Liaison;
            //Permet de reset, ou sinon il va garder les précédents valeurs
            listBoxTraversee.DataSource = null;
            //La classe TraverseeDAO va dans getLiaison et va dans l'id de la liste de la liaison
            if(liaisonSelec != null)
            {
                listBoxTraversee.DataSource = TraverseeDAO.GetTraversee(liaisonSelec.IdLiaison);
                //Permet d'afficher la description
                listBoxTraversee.DisplayMember = "Description";

            }

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

            //L'objet prend la liste des secteurs
        private void buttonAjout_Click(object sender, EventArgs e)
        {
            Secteur secteur = listBoxSecteur.SelectedItem as Secteur;
            //L'objet prend la liste des secteurs
            Port portdepart = comboBox1.SelectedItem as Port;
            //L'objet prend la liste des secteurs
            Port portarrivee = comboBox2.SelectedItem as Port;

            LiaisonDAO.ajoutLiaison( textBoxDureeAjout.Text , portdepart.Id,  portarrivee.Id, secteur.Id);

            //Permet de reset, ou sinon il va garder les précédents valeurs
            Liaison uneLiaison = (Liaison)listBoxLiaison.SelectedItem;
            listBoxLiaison.DataSource = null;
            // Ajout en appellant la méthode

            affiche();


        }

        private void textBoxPortDepAjout_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }


}

           
            
            
        
            
           
        
    

