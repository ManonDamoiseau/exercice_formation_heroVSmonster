using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_Shorewood.Models
{
    public class Hero : Personnage
    {
        public int _pvMax;

        //Propriétés
        public int PvMax { get; set; }

        //méthode création personnage héro
        //public void CreationHero() 
        //{ 
        //    Hero hero = new Hero();
        //    CreationPerso();
        //    _cuir = 0;
        //    _or = 0;
        //}
    }    
    

    public class Humain : Hero
    {
        //public void Humanisation() 
        //{
        //    CreationHero();
        //    //+1 force
        //    _for += +1;
        //    //+1 endurance
        //    _end += +1;
        //}

    }

    public class Nain : Hero 
    {
        //public void Nainisation()
        //{
        //    CreationHero();
        //    // + 2 endurance
        //    _end += +2;
        //}
    }
}
