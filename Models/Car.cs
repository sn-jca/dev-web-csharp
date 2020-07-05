using System;
using System.ComponentModel.DataAnnotations;

namespace myWebAppHTTPS.Models
{
    public class Car
    {

        public int Id { get; set; }

        public string Marque { get; set; }

        public int Annee { get; set; }  

        public string Categorie { get; set; }   
        public string Carburant { get; set; }  
      
        public bool Disponible { get; set; }



    }
}
