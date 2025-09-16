using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSpil1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Velkomstbesked
            Console.WriteLine("Velkommen til");

            //Spørger om navn og kontrollerer om det er gyldigt
            Console.WriteLine("Indtast dit navn:");
            string userName = Console.ReadLine();
            Menu();
            //Menu funktion
            void Menu()
            {
                //Løkke indeholdende switch med funktionskald til de forskellige spil.
                //Løkken bruges i tilfælde af at brugeren vælger noget ikke kan og derfor kører den forfra.
                while (true)
                {
                    //Brugeren præsenteres for spil valgmulighederne
                    Console.WriteLine($"Vælg en af følgende muligheder {userName}:");
                    Console.WriteLine("1. Laura Spil");
                    Console.WriteLine("2. Lasse Spil");
                    /*/Læser brugerens input og gemmer som string, switch for overskuelighed og som forgrening,
                    derudover bruges break i stedet for return for automatisk at komme tilbage til menuen efter afsluttet spil/*/
                    string valgSpilInput = Console.ReadLine();
                    switch (valgSpilInput)
                    {
                        case "1":
                            LauraSpil();
                            break;
                        case "2":
                            LasseSpil();
                            break;
                        default:
                            Console.WriteLine("Ugyldigt valg, prøv igen.");
                            break;
                    }
                }
            }

            //Laura spil    
            void LauraSpil()
            {
                Console.WriteLine($"Velkommen til Gæt et tal.");
                Console.WriteLine($"Som title angiver skal du ,{userName}, gætte et tal.");
                //int gt_randomnumber = new Random().Next(1, 100);
                int gt_randomnumber = 7;
                int gt_guess = Convert.ToByte(Console.ReadLine());
                int gt_numberFrom = Math.Abs(gt_guess - gt_randomnumber); // Math.Abs sikre at værdien altid er positiv

                if (gt_randomnumber == gt_guess)
                {
                    Console.WriteLine("Succes, du gættede rigtigt og har vundet!");
                }
                else
                {
                    Console.WriteLine("Prøv igen");
                    Console.WriteLine($"Du er {gt_numberFrom} fra det tallet");
                }
            }
            //Lasse Spil
            void LasseSpil()
            {
                //Arrays med ord, opdelt i 4 sværhedsgrader.
                string[] hm_wordeasy = new string[] { "Hest", "Bil", "Sko", "Stol", "Taske" };
                string[] hm_wordmedium = new string[] { "Computer", "Hovedtelefoner", "Programmering", "Skærm", "Tastatur" };
                string[] hm_wordhard = new string[] { " Algoritme", "Infrastruktur", "Kryptografi", "Virtualisering", "Mississippi" };
                string[] hm_wordinsane = new string[] { "Parallellogram", "Termodynamik", "Kvantefysik", "Elektromagnetisme", "Fotosyntese" };

                //Random metode oprettes til senere brug 
                Random hm_rng = new Random();

                //Velkomstbesked og tast for at starte spillet
                Console.WriteLine($"Velkommen til Hangman, {userName}!");
                Console.WriteLine("Tryk på en tast for at starte spillet");
                Console.ReadKey();
                Console.Clear();

                //Menu med valg af sværhedsgrad
                while (true)
                {
                    Console.WriteLine("Vælg sværhedsgrad:\n");
                    Console.WriteLine("1. Nem");
                    Console.WriteLine("2. Mellem");
                    Console.WriteLine("3. Svær");
                    Console.WriteLine("4. Umulig.. du kan glemme det");
                    Console.WriteLine("0. Afslut spillet");

                    string hm_menuinput = Console.ReadLine();

                    //Kontrol af gyldigt input samt mulighed for at afslutte spillet og vende tilbage til hovedmenuen
                    if (!int.TryParse(hm_menuinput, out int hm_menuchoice))

                    {
                        Console.WriteLine("Ugyldigt valg, prøv igen.");
                        continue;
                    }

                    // Returnerer til hovedmenu
                    if (hm_menuchoice == 0)
                        Menu();
                    //Array til at binde de forskellige sværhedsgrader sammen
                    string[] hm_wordlist;
                    {
                        switch (hm_menuchoice)
                        {
                            case 1:
                                hm_wordlist = hm_wordeasy;
                                hm_Game();
                                break;
                            case 2:
                                hm_wordlist = hm_wordmedium;
                                hm_Game();
                                break;
                            case 3:
                                hm_wordlist = hm_wordhard;
                                hm_Game();
                                break;
                            case 4:
                                hm_wordlist = hm_wordinsane;
                                hm_Game();
                                break;
                            default:
                                Console.WriteLine("Ugyldigt valg, prøv igen.");
                                continue;
                        }
                        //Spil funktion
                        void hm_Game()
                        {
                            Console.Clear();
                            Console.WriteLine("Spillet starter nu!");
                            //Vælger et tilfældigt ord fra det valgte array med sværhedsgrad
                            string hm_selectedword = hm_wordlist[hm_rng.Next(hm_wordlist.Length)];
                            //Skriver tomme felter ud til det valgte ord 
                            char[] hm_wordchar = new char[hm_selectedword.Length];
                            for (int i = 0; i < hm_wordchar.Length; i++)
                            {
                                Console.Write("_ ");
                            }
                            //Vareiabel til vise antallet af forkerte gæt
                            int hm_wrongguesses = 0;
                            //String til at gemme de bogstaver brugeren har gættet
                            string hm_guessedLetters = "";
                            //Spørger brugeren om et bogstav og gemmer det som char 
                            char hm_guess = Console.ReadLine().ToLower()[0];
                            //Tjekker om det gættede bogstav er i det valgte ord
                            if (hm_selectedword.ToLower().Contains(hm_guess))
                                hm_wrongguesses++;

                            //Hvis brugeren gætter et forkert bogstav tæller hm_wrongguesses op
                            byte hm_lifetotal = 5;   
                            while (hm_wrongguesses < hm_lifetotal)
                            {
                                Console.Clear();
                                Console.WriteLine($"Du har {hm_lifetotal - hm_wrongguesses} liv tilbage.");
                                Console.WriteLine($"Du har gættet på følgende bogstaver: {hm_guessedLetters}");
                            }
                        }
                    }
                }
            }
        
        }
    }
}
