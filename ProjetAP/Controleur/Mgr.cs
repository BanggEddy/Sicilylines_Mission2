﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connecte.DAL;
using Connecte.Modele;


namespace Connecte.Controleur
{
  public  class Mgr
    {

        DAL.SecteurDAO empDAO = new DAL.SecteurDAO();

        List<Modele.Secteur> maListeSecteur;

        public Mgr()
        {

            maListeSecteur = new List<Modele.Secteur>();
        }



        // Récupération de la liste des secteurs à partir de la DAL
        public List<Secteur> chargementEmpBD()
        {

            maListeSecteur = SecteurDAO.getSecteur();

            return (maListeSecteur);
        }




    }
}
