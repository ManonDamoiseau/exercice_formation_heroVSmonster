using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Labo_Shorewood.Models
{
    public class Personnage 
    {
        //Attributs
        public int _end;
        public int _for;
        public int _pv;
        public int _degat;
        public int _or;
        public int _cuir;
        public int _xp;

        public int _result1d4;
        public int _result1d6;
        public double _modificateur;
        public int _stat;
        


        //Propriétés
        public int End { get; init; }
        public int For { get; init; }
        public int Pv { get; init; }
        public int Or { get; set; }
        public int Cuir { get; set; }
        public int Exp { get; set; }

        public int Result1d4 { get; set; }
        public int Result1d6 { get; set; }

        //Méthodes  

        //créa endurance, force
        public void CreationPerso()
        {
            int[] resultd6 = new int[4];
            //1d6 fois 4
            Lance1d6();
            resultd6[3] = _result1d6;
            

            for (int i = 2; i >= 0; i--)
            {
                //trier les 3 meilleurs 
                Lance1d6();
                
                if (_result1d6 > resultd6[i+1])
                {
                    resultd6[i] = resultd6[i+1];
                    resultd6[i+1] = _result1d6;
                }
                else
                {
                    resultd6[i] = _result1d6;
                }
            }
            _stat = resultd6[1] + resultd6[2] + resultd6[3];
            Console.WriteLine($"test result : {resultd6[1]} + {resultd6[2]} + {resultd6[3]}");
        }


        // créa pv via endurance et modificateur
        public void CreationPV()
            {
                Modificateur(_end);
                _pv = (int)(_end + _modificateur);
            Console.WriteLine($"modificateur result : {_modificateur} + {_end}");
        }
        public void Frappe()
        {
            //lancer 1d4 + modificateur sur force pour les dégats
            Lance1d4();
            Modificateur(_for);
            _degat = (int)(_result1d4 + _modificateur);
            //retirer pv
            _pv -= _degat;
            Console.WriteLine($" + modificateur : {_modificateur}");
            Console.WriteLine($"\n ***** Dégats de {_degat} *****");
         }

        //méthodes Jet de dés 
        public void Lance1d4()
        {
            Random rnd = new Random();
            int result1d4 = rnd.Next(1,5);
            _result1d4 = result1d4;
            Console.WriteLine($" --> 1d4 : {result1d4}");
        }
        public void Lance1d6()
        {
            Random rnd= new Random();
            int result1d6 = rnd.Next(1,7);
            _result1d6 = result1d6;
            Console.WriteLine($" --> 1d6 : {result1d6}");
        }
        //méthode calcul modificateur (bonus/malus)
        public void Modificateur(int _for) // Force
        {
            switch (_for)
            {
                case < 5:
                    _modificateur = -1;
                    break;
                case < 10:
                    _modificateur = 0; 
                    break;
                case < 15 : 
                    _modificateur = 1;
                    break;
                default :
                    _modificateur = 2;
                    break;
            }
        }

    }
}
