using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_Shorewood.Models
{
    public class Monstre : Personnage
    {
        //méthode or
        public void Richesse()
        {
            Console.WriteLine("\n\nGénération de l'or\n");
            Lance1d6();
            _or = _result1d6;
        }

        //méthode cuir
        public void CreaCuir()
        {
            Console.WriteLine("\n\nGénération du cuir\n");
            Lance1d4();
            _cuir = _result1d4;
        }

        //méthode création personnage monstre
        //public void CreationMonstre()
        //{
        //    Monstre monstre = new Monstre();
        //    CreationPerso();
        //}

    }

    public class Loup : Monstre 
    {
        //public void Loupisation()
        //{
        //    CreaCuir();
        //}


    }

    public class  Orque : Monstre
    {
        //public void Orquisation()
        //{
        //    CreationMonstre();
        //    //+1 force
        //    _for += +1;
        //    Richesse();
        //}
        

    }

    public class Dragonnet : Monstre 
    {
        //public void Dragonification()
        //{
        //    CreationMonstre();
        //    //+1 endurance
        //    _end += +1;
        //    Richesse();
        //    CreaCuir();
        //}
    }
}
