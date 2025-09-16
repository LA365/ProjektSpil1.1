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
                string[] hm_wordhard = new string[] { "Algoritme", "Infrastruktur", "Kryptografi", "Virtualisering", "Mississippi" };
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
                    {
                        Menu();
                        return;
                    }

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
                            //Skriver tomme felter ud til det valgte ord og gemmer '_' i array
                            char[] hm_wordchar = new char[hm_selectedword.Length];
                            //Fylder alle pladser med '_'
                            for (int i = 0; i < hm_wordchar.Length; i++)
                            {
                                //Viser '_' for hvert bogstav i det valgte ord
                                hm_wordchar[i] = '_';
                            }
                            //Vareiabel til vise antallet af forkerte gæt
                            int hm_wrongguesses = 0;
                            //String til at gemme de bogstaver brugeren har gættet
                            string hm_guessedLetters = "";
                            //Hvis brugeren gætter et forkert bogstav tæller hm_wrongguesses op
                            int hm_lifetotal = 5;   
                            while (hm_wrongguesses < hm_lifetotal)
                            {
                                //Viser status for spilleren
                                Console.Clear();
                                Console.WriteLine($"Du har {hm_lifetotal - hm_wrongguesses} liv tilbage.");
                                Console.WriteLine($"Du har gættet på følgende bogstaver: {hm_guessedLetters}");
                                //Viser ordet med '_' og gættede bogstaver
                                for (int i = 0; i < hm_wordchar.Length; i++)
                                {
                                    Console.Write(hm_wordchar[i] + " ");
                                }   
                                Console.WriteLine();
                                //Nyt gæt
                                Console.Write("Gæt et bogstav:");
                                string hm_userguess = Console.ReadLine().ToLower();
                                //Kontrol af gyldigt input (længde og type)
                                if (hm_userguess.Length != 1)
                                {
                                    Console.WriteLine("Indtast venligst kun ét bogstav.");
                                    continue;
                                }
                                char hm_userguesschar = hm_userguess[0];
                                //Tjekker om det er et bogstav
                                if (!char.IsLetter(hm_userguesschar))
                                {
                                    Console.WriteLine("Indtast venligst et bogstav (A-Å).");
                                    continue;
                                }
                                //Tjekker om det allerede er gættet
                                if (hm_guessedLetters.Contains(hm_userguesschar))
                                {
                                    Console.WriteLine("Du har allerede gættet på dette bogstav, prøv igen.");
                                    continue;
                                }
                                //Tilføjer det gættede bogstav til listen over gættede bogstaver
                                hm_guessedLetters += hm_userguesschar + " ";
                                //Tjekker om det gættede bogstav er i det valgte ord og viser bogstavet hvis det er korrekt
                                bool hm_correctguess = false;
                                for (int i = 0; i < hm_selectedword.Length; i++)
                                {
                                    //Sammenligner det gættede bogstav med hvert bogstav i det valgte ord, i lower case
                                    if (char.ToLower(hm_selectedword[i]) == hm_userguesschar)
                                    {
                                        //Indsætter det korrekte bogstav i arrayet
                                        hm_wordchar[i] = hm_selectedword[i];
                                        hm_correctguess = true;
                                    }
                                }
                                //Hvis det gættede bogstav ikke er i ordet tæller hm_wrongguesses op
                                if (!hm_correctguess)
                                {
                                    hm_wrongguesses++;
                                }
                                bool hm_wordcomplete = true;
                                for (int i = 0; i < hm_wordchar.Length; i++)
                                {
                                    if (hm_wordchar[i] == '_')
                                    {
                                        hm_wordcomplete = false;
                                        break;
                                    }
                                }
                                if (hm_wordcomplete)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Tillykke, {userName}! Du har gættet ordet: {hm_selectedword} med {hm_wrongguesses} forkerte gæt.");
                                    Console.WriteLine("Tryk på en tast for at vende tilbage til menuen");
                                    Console.ReadKey();
                                    break;
                                }
                                if (hm_wrongguesses >= hm_lifetotal)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Desværre, {userName}. Du har brugt alle dine liv. Ordet var: {hm_selectedword}");
                                    Console.WriteLine("Tryk på en tast for at vende tilbage til menuen");
                                    Console.ReadKey();
                                    break;

                                }
                        }
                    }
                }
            }
        
        }
    }
}
