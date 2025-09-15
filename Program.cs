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

                //Tilfældigt tal vælges 
                Random hm_rng = new Random();
                int hm_randomnumber = hm_rng.Next(0, hm_wordhard.Length);
                Console.WriteLine(hm_randomnumber);


                //Velkomstbesked og tast for at starte spillet
                Console.WriteLine("Velkommen til Hangman!");
                Console.WriteLine("Tryk på en tast for at starte spillet");
                Console.ReadKey();
                Console.Clear();

                //Valg af sværhedsgrad
                Console.WriteLine("Vælg sværhedsgrad:");
                Console.WriteLine("1. Nem");
                Console.WriteLine("2. Mellem");
                Console.WriteLine("3. Svær");
                Console.WriteLine("4. Glem det");
                Console.WriteLine("0. Afslut spillet");
                Console.ReadKey();
            }
        }
    }
}
