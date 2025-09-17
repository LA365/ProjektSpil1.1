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
            Console.WriteLine("Velkommen til følgende program skrevet af Lasse og Laura");
            Console.WriteLine("Programmer vil tage dig igennem nogle forskellige spil,og vi som udvilker håber du har det sjovt\n");

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
                //Spilleren har 3 liv til at gætter tallet, hvor man bruger en int variable, da man har med tal at gøre
                //Variablen sættes her, så den kan anvendes i andre funktioner og bliver derfor en global variable
                int gt_userLife = 3;

                //Funktion Gæt tal menu, så brugeren kan komme tilbage og spille igen, hvis de ønsker  
                void GTMenu()
                {
                    //Starter med en lille velkomst besked til spillet og hvad spillet handler om, for brugervenlighed
                    Console.WriteLine($"Velkommen til spillet Gæt et tal.");
                    Console.WriteLine($"Som title angiver skal du, {userName}, i dette spil gætte et tal.");

                    //Her fortæller man at brugeren har 3 muligheder, at vælge i mellem
                    Console.WriteLine("Du har mulighed for at vælge en sværhedsgrad, og har følgende muligheder:\n");
                    Console.WriteLine("1. Nem: Gæt et tal mellem 1 - 10.");
                    Console.WriteLine("2. Mellem: Gæt er tal mellem 1 - 100.");
                    Console.WriteLine("3. Svær: Gæt et tal mellem 1 - 1000.");

                    string gt_diffeculty = Console.ReadLine();

                    //Her laver man en forgrening med switch for overskueligheden skyld. I switchen finder man 3 funktioner.
                    //De 3 funktioner indekere sværhedsgraden, som er nem, melllem og svær
                    switch (gt_diffeculty)
                    {
                        case "1":
                            GTEasy();
                            break;

                        case "2":
                            GTMedium();
                            break;

                        case "3":
                            GTDifficult();
                            break;

                        default:
                            Console.WriteLine("Du har valgt en ugyldig mulighed, prøv igen tak!");
                            break;
                    }
                }

                //Det er en funktion, hvor det skal være nemt at gætte tallet computeren generer til brugeren
                void GTEasy()
                {
                    Console.WriteLine("Computeren vil genere et nummer til dig mellem 1 - 10, som du nu skal prøve at gætte.");
                    Console.WriteLine("Du har 3 liv til at gætte tallet computeren har generet.");

                    // Generer et tilfældigt tal:
                    int gt_randomNumber = new Random().Next(1, 10);

                    //Her definere man variablen brugerens gæt
                    int gt_userGuess = (0);

                    //Her bruger man en while løkke, så man kan blive ved med at spille, hvis man gætter forkert
                    while (gt_userGuess != gt_randomNumber)
                    {
                        Console.WriteLine("Gæt et tal:");

                        //Her konveterer man byte til readline, så brugere kan indtaste sit gæt
                        //Man vælger at bruge Byte i stedet for int, siden computer kun skal generet et tal mellem 1 - 10
                        gt_userGuess = Convert.ToByte(Console.ReadLine());

                        //Her udregner man hvor langt man er fra det computere har genéret. Man anvender Math.abs så man er sikret værdien altid vil forblive positiv
                        int gt_numberFrom = Math.Abs(gt_userGuess - gt_randomNumber);

                        //Her bruger man if/else så, hvis man gætter rigtig for man en besked og gætter man forkert får man en anden
                        if (gt_randomNumber == gt_userGuess)
                        {
                            Console.WriteLine("Succes, du gættede rigtigt og har vundet!");
                            GTMenu();
                            //Skriv ud
                        }

                        else
                        {
                            Console.WriteLine("Prøv igen.");

                            //Her siger man, at når brugeren har gættet forkert mister de et liv
                            gt_userLife--;

                            //Her fortæller man brugere hvor mange liv det har tilbage
                            Console.WriteLine($"Du har {gt_userLife} liv tilbage.");

                            //Denne if kommmer når brugeren har et liv igen, som en form for livline eller hjælp til brugeren
                            if (gt_userLife == 1)
                            {
                                Console.WriteLine($"Du er {gt_numberFrom} fra det tallet.");
                            }
                        }
                    }
                }

                // Det er en funktion, hvor der skal være middel at gætte tallet
                void GTMedium()
                {
                    Console.WriteLine("Computeren vil genere et nummer til dig mellem 1 - 100, som du nu skal prøve at gætte.");
                    Console.WriteLine("Du har 3 liv til at gætte tallet computeren har generet.");

                    // Generer et tilfældigt tal:
                    int gt_randomNumber = new Random().Next(1, 100);

                    //Her definere man variablen brugerens gæt
                    int gt_userGuess = (0);

                    //Her bruger man en while løkke, så man kan blive ved med at spille, hvis man gætter forkert
                    while (gt_userGuess != gt_randomNumber)
                    {
                        Console.WriteLine("Gæt et tal:");

                        //Her konveterer man byte til readline, så brugere kan indtaste sit gæt
                        gt_userGuess = Convert.ToByte(Console.ReadLine());

                        //Her udregner man hvor langt man er fra det computere har genéret. Man anvender Math.abs så man er sikret værdien altid vil forblive positiv
                        int gt_numberFrom = Math.Abs(gt_userGuess - gt_randomNumber);

                        //Her bruger man if/else så, hvis man gætter rigtig for man en besked og gætter man forkert får man en anden
                        if (gt_randomNumber == gt_userGuess)
                        {
                            Console.WriteLine("Succes, du gættede rigtigt og har vundet!");
                        }

                        else
                        {
                            //Her siger man, at når brugeren har gættet forkert mister de et liv
                            gt_userLife--;

                            //Her fortæller man brugere hvor mange liv det har tilbage
                            Console.WriteLine($"Du har {gt_userLife} liv tilbage.");

                            //Denne if kommmer når brugeren har et liv igen, som en form for livline eller hjælp til brugeren
                            if (gt_userLife == 1)
                            {
                                Console.WriteLine($"Du er {gt_numberFrom} fra det tallet.");
                            }
                        }
                    }
                }

                //Dette er en funktion, hvor det skal være svært at gætte tallet 
                void GTDifficult()
                {
                    Console.WriteLine("Computeren vil genere et nummer til dig mellem 1 - 1000, som du nu skal prøve at gætte.");
                    Console.WriteLine("Du har 3 liv til at gætte tallet computeren har generet.");

                    // Generer et tilfældigt tal:
                    int gt_randomNumber = new Random().Next(1, 1000);
                    int gt_userGuess = (0);

                    //Her bruger man en while løkke, så man kan blive ved med at spille, hvis man gætter forkert
                    while (gt_userGuess != gt_randomNumber)
                    {
                        Console.WriteLine("Gæt et tal:");

                        //Her konveterer man byte til readline, så brugere kan indtaste sit gæt
                        //Her bruger man int i stedet for Byte, fordi tallet computeren generer er højere end hvad Byte indeholde
                        gt_userGuess = Convert.ToInt16(Console.ReadLine());

                        //Her udregner man hvor langt man er fra det computere har genéret. Man anvender Math.abs så man er sikret værdien altid vil forblive positiv
                        int gt_numberFrom = Math.Abs(gt_userGuess - gt_randomNumber);

                        //Her bruger man if/else så, hvis man gætter rigtig for man en besked og gætter man forkert får man en anden
                        if (gt_randomNumber == gt_userGuess)
                        {
                            Console.WriteLine("Succes, du gættede rigtigt og har vundet!");
                        }

                        else
                        {
                            //Her siger man, at når brugeren har gættet forkert mister de et liv
                            gt_userLife--;

                            //Her fortæller man brugere hvor mange liv det har tilbage
                            Console.WriteLine($"Du har {gt_userLife} liv tilbage.");

                            //Denne if kommmer når brugeren har et liv igen, som en form for livline eller hjælp
                            if (gt_userLife == 1)
                            {
                                Console.WriteLine($"Du er {gt_numberFrom} fra det tallet.");
                            }
                        }
                    }
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
