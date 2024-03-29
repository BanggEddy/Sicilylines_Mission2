﻿using Connecte.Modele;
using Connecte;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connecte.DAL
{
    internal class LiaisonDAO
    {

        // attributs de connexion statiques
        private static string provider = "localhost";

        private static string dataBase = "sicilylines";

        private static string uid = "root";

        private static string mdp = "";



        private static ConnexionSql maConnexionSql;


        private static MySqlCommand Ocom;


        //Afficher les liaisons
        public static List<Liaison> GetLiaison(int idSecteur)
        {

            try
            {
                List<Liaison> list = new List<Liaison>();
                Liaison _liaison = new Liaison(); 
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);


                maConnexionSql.openConnection();


                Ocom = maConnexionSql.reqExec("Select * from liaison where idSecteur = " + idSecteur +"+1");


                MySqlDataReader reader1 = Ocom.ExecuteReader();

                

                while (reader1.Read())
                {

                    int _idLiaison = (int)reader1.GetValue(0);
                    string _duree = (string)reader1.GetValue(1);
                    int idPortDepart = (int)reader1.GetValue(2);
                    int idPortArrivee = (int)reader1.GetValue(3);
                    int _idSecteur = (int)reader1.GetValue(4);

                    _liaison = new Liaison(_idLiaison, _duree, idPortDepart, idPortArrivee, _idSecteur);

                    //Chaque objet ajouter inséré dans la liste
                    list.Add(_liaison);
                }



                reader1.Close();

                maConnexionSql.closeConnection();


                return (list);

            }

            catch (Exception uneLiaison)
            {

                throw (uneLiaison);
            }
        }

        //Supprimer liaison
        public static void deleteLiaison(int idLiaison)
        {
            try
            {

                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);


                maConnexionSql.openConnection();


                Ocom = maConnexionSql.reqExec("DELETE from liaison where id=" + idLiaison);


                int i = Ocom.ExecuteNonQuery();

                maConnexionSql.closeConnection();

            }

            catch (Exception emp)
            {

                throw (emp);
            }
        }
        //Modifier liaison
        public static void modifLiaison(int idLiaison, string duree)
        {
            try
            {

                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("update liaison set duree = '" + duree + "' where id = " + idLiaison);


                int i = Ocom.ExecuteNonQuery();

                maConnexionSql.closeConnection();

            }

            catch (Exception emp)
            {

                throw (emp);
            }
        }

        //Modifier liaison
        public static void ajoutLiaison(string duree,int monPortDepart, int monPortArrivee, int idSecteur)
        {
            try
            {

                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();
                String sqlReq = "INSERT INTO liaison(duree, port_depart, port_arrivee, idSecteur) VALUES('" + duree + "'," + monPortDepart + "," + monPortArrivee + "," + idSecteur + ");";
                Ocom = maConnexionSql.reqExec(sqlReq);
                Console.WriteLine(sqlReq);

                int i = Ocom.ExecuteNonQuery();

                maConnexionSql.closeConnection();

            }

            catch (Exception emp)
            {

                throw (emp);
            }



        }

    }
}
