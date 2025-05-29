using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using Labo_Shorewood.Models;

namespace Labo_Shorewood
{
    class Program 
    {
        static void Main(string[] args)
        {
            bool play = true;

            //Top 3 players
            string namePlayer1 = "_______";
            string namePlayer2 = "_______";
            string namePlayer3 = "_______";

            int winPlayer1 = 0;
            int winPlayer2 = 0;
            int winPlayer3 = 0;

            while (play == true)
            {
                // Réinitialisation
                bool gameOver = false;
                int grenouille = 0;
                int monstreOccis = 0;
                int chgmtNom = 0;

                //Welcome
                Console.WriteLine("---------------------------------------------------------------------------------------------");
                Console.WriteLine(" ( )    ( )                                                                      ( )    ( )");
                Console.WriteLine("(___)  (___) Bienvenue dans la forêt de SHOREWOOD, située au pays de Stormwall! (___)  (___)");
                Console.WriteLine("  |      |                                                                        |      |");
                Console.WriteLine("--------------------------------------------------------------------------------------------");


                //Création héro
                Console.WriteLine("\n\nVeux-tu créer un nain ou un humain? \n \n 1 : Nain \n 2 : Humain\n\n\n");

                //visuel nain et humain
                Visuels.NainOuHumain();


                int.TryParse(Console.ReadLine(), out int choixHero);


                while (choixHero != 1 && choixHero != 2 && grenouille != 2)
            {
                Console.Clear();
                Console.WriteLine("****************"
                + " Bienvenue dans la forêt de Shorewood, situé au pays de Stormwall! " +
                "****************\n\n");
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("ERREUR");
                Console.WriteLine("------------------------------------------------------------");
                if (grenouille == 0) 
                    {
                    Console.WriteLine("Tu as entré autre chose que 1 ou 2, j'espère que tu n'as pas fait exprès pour m'embêter..." +
                        "\n... les petits malins je les transforme en grenouille moi.\n\n");
                    Console.WriteLine("Veux-tu créer un nain ou un humain?\n\n 1 : Nain\n 2 : Humain");
                    int.TryParse(Console.ReadLine(), out choixHero);
                    }
                
                else
                    {
                    Console.WriteLine("Très bien, tu l'aura cherché!");
                    Console.ReadLine();
                    }
             grenouille += 1;
            }

            //Attributs
            Console.Clear();
            Hero hero = new Hero();
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Création du héro");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Génération de l'endurance");
            hero.CreationPerso();
            hero._end = hero._stat;
            Console.WriteLine("\nGénération de la force");
            hero.CreationPerso();
            hero._for = hero._stat;
            Console.WriteLine("\nGénération des PV");
            hero.CreationPV();
            hero._pvMax = hero._pv;
            hero._cuir = 0;
            hero._or = 0;
            hero._xp = 0;

            if (choixHero == 1) //Nain
            {
                Console.WriteLine("\n------------------------------------------------------------");
                Console.WriteLine("Tu as choisi d'être un Nain!");
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("****** Tu es béni par le dieu nain : endurance +2 ******\n");
                hero._end += +2;

            }

            else if (choixHero == 2) // Humain
            {
                Console.WriteLine("\n------------------------------------------------------------");
                Console.WriteLine("Tu as choisi d'être un Humain!");
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("****** Tu es béni par le dieu humain : force +1 et endurance +1 ******\n");
                hero._for += +1;
                hero._end += +1;
            }

            else
            {
                Console.WriteLine("\n------------------------------------------------------------");
                Console.WriteLine("Tu as donc choisi le MODE DIFFICILE!");
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("****** Et quoi, t'as cru que t'aurais les stats d'un héro? ******\n");
                Console.WriteLine("Et non, tu es une grenouille, tu aura donc des stats pourries!");
                hero._end = 3;
                hero._for = 3;
                hero._pv = 5;
                hero._pvMax = 5;
                    Visuels.Grenouille();
            }

            Console.WriteLine($"Endurance : {hero._end} \nForce : {hero._for}" +
                $"\nPoint de vie : {hero._pv}");
            Console.WriteLine($"\n--- Ton inventaire --- \nCuir : {hero._cuir} \nOr : {hero._or}");
            Console.WriteLine("\n------------------------------------------------------------");
            Console.WriteLine("\n(Tape sur une touche du clavier pour afficher la suite)");
            Console.ReadLine();
            Console.Clear();

            string choixNom;
                //Choix du nom
                    Console.WriteLine("\n------------------------------------------------------------");
                    Console.WriteLine("Choisi ton nom de héro");
                    Console.WriteLine("------------------------------------------------------------\n");
                Visuels.Bouclier();
                choixNom = Console.ReadLine()!;
                    choixNom.Trim();
                
     

                while (choixNom == "")
                {
                    Console.WriteLine("Ton héro doit avoir un nom");
                    choixNom = Console.ReadLine()!;
                    choixNom.Trim();
                    Console.Clear();
                }


                if (grenouille == 2)
            {
                    Console.Clear();
                Console.WriteLine("T'as vraiment cru que j'allais te laisser choisir ton nom?");
                Console.WriteLine("ET BEN NON !");
                choixNom = "Tétard";
                Console.WriteLine($"Ton nom de batracien misérable sera donc {choixNom} !");
            }


            else
            {
                    Console.Clear();
                    Console.WriteLine("\n------------------------------------------------------------");
                    Console.WriteLine("Choisi ton nom de héro");
                    Console.WriteLine("------------------------------------------------------------\n");
                    Visuels.Bouclier();
                    Console.WriteLine($"Ton nom héroïque sera donc {choixNom} !");
                }
            Console.ReadLine();


            //Déroulement du jeu - 1 combat par tour
            while (gameOver == false)
            {
                // Début du jeu
                Console.Clear();
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("Il est temps de partir en quête d'un ennemi à combattre ! ");
                Console.WriteLine("------------------------------------------------------------\n");
                    Visuels.Epee();

                    //Génération monstre
                    Console.WriteLine("****** Un monstre vient d'aparaître !! Prépare-toi au combat! ******\n");
                Console.WriteLine("Il semblerait que ça ne soit pas n'importe quel monstre... ");
                Console.ReadLine();
                Random rnd = new Random();
               int ennemi =  rnd.Next(3);
                
                //appel méthode créa monstre
                //Attributs
                Monstre monstre = new Monstre();
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("Création du monstre");
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("Génération de l'endurance");
                monstre.CreationPerso();
                monstre._end = monstre._stat;
                //hero._end = hero._stat;
                Console.WriteLine("\nGénération de la force");
                monstre.CreationPerso();
                monstre._for = monstre._stat;
                Console.WriteLine("\nGénération des PV");
                monstre.CreationPV();

                //Loup
                if (ennemi == 0)
                {
                    monstre.CreaCuir();
                    monstre._xp = 1;
                    Console.WriteLine("\n\n------------------------------------------------------------");
                    Console.WriteLine("OH NON, C'EST UN LOUP!");
                    Console.WriteLine("Et il a l'air coriace!");
                        Visuels.Loup();
                }
                //Orque
                else if (ennemi == 1)
                {
                    monstre.Richesse();
                    monstre._for += +1;
                    monstre._xp = 2;
                    Console.WriteLine("\n\n------------------------------------------------------------");
                    Console.WriteLine("MISERE, C'EST UN ORQUE!");
                    Console.WriteLine("Il a l'air moins sympa que dans 'Sauvez Willy'! Fais attention!");
                        Visuels.Orque();
                }
                //Dragonnet
                else
                {
                    monstre.CreaCuir();
                    monstre.Richesse();
                    monstre._end += +1;
                    monstre._xp = 3;
                    Console.WriteLine("\n\n------------------------------------------------------------");
                    Console.WriteLine("NOUS SOMMES PERDUS, C'EST UN DRAGONNET!");
                    Console.WriteLine("Il n'est pas aussi dangereux qu'un dragon adulte, mais il reste redoutable!");
                        Visuels.Dragonet();
                }

                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine($"Endurance : {monstre._end} \nForce : {monstre._for}" +
                       $"\nPoint de vie : {monstre._pv}");
                Console.WriteLine($"\n--- Son butin --- \nCuir : {monstre._cuir}\nOr : {monstre._or}");
                Console.ReadLine();

                //Déroulement du combat
                bool attaqueHero = true;
                while (hero._pv > 0 && monstre._pv > 0)
                {
                    Console.Clear();
                        Visuels.Combats();
                    Console.WriteLine("\n------------------------------------------------------------");
                    Console.WriteLine($"Les pv de ton héro : {hero._pv}");
                    Console.WriteLine($"Les pv du monstre : {monstre._pv}");
                    Console.WriteLine("------------------------------------------------------------");
            
                    if (attaqueHero == true)
                    {
                        Console.WriteLine($"C'est à ton tour d'attaquer {choixNom}, FINISH HIM!");
                        monstre.Frappe();
                        attaqueHero = false;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("C'est au tour du monstre d'attaquer, prends garde!");
                        hero.Frappe();
                        attaqueHero = true;
                        Console.ReadLine();
                    }
                    
                }

                //Fin de combat
                if (hero._pv <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("******************* GAME OVER *******************\n\n");
                    Console.WriteLine("Oh non tu as été occis par le monstre!");
                    Console.WriteLine($"Nous garderons en mémoire tes actes honorables et héroïques mon cher {choixNom}, repose en paix...");
                    gameOver = true;
                        Visuels.Death();
                    Console.ReadLine();
                    Console.Clear();

                    //Resultats fin de partie
                    Console.WriteLine("------------------------------------------------------------");
                    Console.WriteLine("Ton score");
                    Console.WriteLine("------------------------------------------------------------\n");
                    Console.WriteLine($"Nombre de monstres occis : {monstreOccis}");
                    Console.WriteLine("\n--- Ton butin ---");
                    Console.WriteLine($"Cuir : {hero._cuir}");
                    Console.WriteLine($"Or : {hero._or}");
                    Console.WriteLine("\n------------------------------------------------------------\n");

                        //Top 3
                        Visuels.Top3();
                        if (monstreOccis > winPlayer1 && monstreOccis != 0)
                        {
                            winPlayer3 = winPlayer2;
                            namePlayer3 = namePlayer2;

                            winPlayer2 = winPlayer1;
                            namePlayer2 = namePlayer1;

                            winPlayer1 = monstreOccis;
                            namePlayer1 = choixNom;

                        }
                        else if (monstreOccis > winPlayer2 || monstreOccis == winPlayer1 && monstreOccis != 0)
                        {
                            winPlayer3 = winPlayer2;
                            namePlayer3 = namePlayer2;

                            winPlayer2 = monstreOccis;
                            namePlayer2 = choixNom;
                        }
                        else if (monstreOccis > winPlayer3 || monstreOccis == winPlayer2 && monstreOccis != 0)
                        {
                            winPlayer3 = winPlayer2;
                            namePlayer3 = namePlayer2;
                        }
                            

                        Console.WriteLine("Nos valeureux héros ayant occis le plus de monstre \n");
                        Console.WriteLine($" 1er : {namePlayer1} -  {winPlayer1}");
                        Console.WriteLine($" 2eme : {namePlayer2} -  {winPlayer2}");
                        Console.WriteLine($" 3eme : {namePlayer3} -  {winPlayer3}");

                        Console.WriteLine("\n\n------------------------------------------------------------");
                        Console.WriteLine("Veux-tu lancer une nouvelle partie?");
                        Console.WriteLine("------------------------------------------------------------\n");
                        Console.WriteLine("Tapes 1 si tu veux t'arrêter ici, tapes autre chose si tu veux continuer à jouer :)");
                        int.TryParse(Console.ReadLine(), out int choixPlay);

                        if (choixPlay == 1)
                        {
                            play = false;
                        }

                    }
                else
                {
                    Console.Clear();
                    Console.WriteLine("------------------------------------------------------------");
                    Console.WriteLine($"Merveilleux! Gloire ô grand {choixNom}! Tu as vaincu le monstre!");
                    Console.WriteLine("------------------------------------------------------------");
                        Visuels.WinMonster();

                        //Recupérer stuff monstre + afficher nouveau inventaire
                        Console.WriteLine("\nTu récupère le butin du monstre, voici ton nouvel inventaire :");
                    hero._or += monstre._or;
                    hero._cuir += monstre._cuir;
                    hero._xp += monstre._xp;
                    Console.WriteLine($"\nOr : {hero._or} \nCuir : {hero._cuir}");
                    monstreOccis += 1;

                        //Montée de niveau
                        string adjectif;
                        if (hero._xp >= 5 && chgmtNom < 1 && grenouille != 2)
                        {
                            Console.ReadLine();
                            adjectif = "chevalier";
                            choixNom = $"{choixNom} le {adjectif}";
                            chgmtNom += 1;
                        
                        Console.WriteLine("\n\n------------------------------------------------------------");
                        Console.WriteLine($"MONTE DE NIVEAU");
                        Console.WriteLine("------------------------------------------------------------\n");
                        Console.WriteLine($"Tes exploits sont contés dans tous le royaume, tu te voit octroyé le titre de 'CHEVALIER' !");
                        Console.WriteLine($"*** Tu es dorénavant connu sous le nom de {choixNom} ***");
                            Visuels.Niveau();
                        }
                        else if (hero._xp >= 10 && chgmtNom < 2)
                        {
                            Console.ReadLine();
                            adjectif = "suprême";
                            choixNom = $"{choixNom} {adjectif}";
                            chgmtNom += 1;

                            Console.WriteLine("\n\n------------------------------------------------------------");
                            Console.WriteLine($"MONTE DE NIVEAU");
                            Console.WriteLine("------------------------------------------------------------\n");
                            Console.WriteLine($"Tes exploits sont contés dans tous le royaume, tu te voit octroyé un titre supplémentaire !");
                            Console.WriteLine($"*** Tu es dorénavant connu sous le nom de {choixNom} ***");
                            Visuels.Niveau();
                        }
                        else if (hero._xp >= 15 && chgmtNom < 3)
                        {
                            Console.ReadLine();
                            adjectif = "ULTRA";
                            choixNom = $"{choixNom} {adjectif}";
                            chgmtNom += 1;

                            Console.WriteLine("\n\n------------------------------------------------------------");
                            Console.WriteLine($"MONTE DE NIVEAU");
                            Console.WriteLine("------------------------------------------------------------\n");
                            Console.WriteLine($"Tes exploits sont contés dans tous le royaume, tu te voit octroyé un titre supplémentaire !");
                            Console.WriteLine($"*** Tu es dorénavant connu sous le nom de {choixNom} ***");
                            Visuels.Niveau();
                        }

                        //Recup pv avec nuit
                        Console.ReadLine();
                    Console.WriteLine("\n------------------------------------------------------------");
                    Console.WriteLine("Il serait préférable de reprendre des forces après ce combat...");
                    Console.WriteLine($"\n****** {choixNom} passes une bonne nuit et a récupéré un max!******");
                    hero._pv = hero._pvMax;
                        Visuels.Sleep();
                    Console.ReadLine();

                    if (grenouille == 2 && monstreOccis == 10)
                    {
                        Console.WriteLine("Mais... Que se passe-t-il??");
                        Console.ReadLine();
                        Console.WriteLine("NON c'est impossible!! Il semblerait que la déesse de la lune s'incline devant " +
                            "\ntant de bravoure, elle veut te récompenser!");
                        Console.ReadLine();
                        Console.WriteLine("\n\n------------------------------------------------------------");
                        Console.WriteLine("EVOLUTION");
                        Console.WriteLine("------------------------------------------------------------");
                        Console.WriteLine("On dirait que ta grenouille évolue en ... CRAPAUD BUFFLE!!");
                        Console.WriteLine("\n Tu développes également de nouvelles stats! (elle abuse la déesse lunaire là... pfff)");
                        hero._end = 18;
                        hero._for = 18;
                        hero._pv = 25;
                        hero._pvMax = 25;
                        Console.WriteLine($"Endurance : {hero._end} \nForce : {hero._for}" +
                        $"\nPoint de vie : {hero._pv}");
                            Visuels.CrapaudBuffle();
                        Console.WriteLine("\n\n QUOI?! Mais c'est quoi cette dinguerie??" + 
                            "\nMes monstres ne feront plus le poids maintenant TT");
                        Console.ReadLine();
                    }   
                }
                    Console.Clear();
            }
        }
    }
    }
}
