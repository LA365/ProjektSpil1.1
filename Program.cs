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
            Console.WriteLine("Programmer vil tage dig igennem nogle forskellige spil, og vi som udvilker håber du har det sjovt\n");

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
                    Console.WriteLine($"\nVælg en af følgende muligheder {userName}:");
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

                /*Her kalder man GTMenu funktionen for spillet, og den kaldes derfor GT, så den ikke overskrive
                 Menu funktionen længere oppe*/
                GTMenu();

                //Funktion Gæt tal menu, så brugeren kan komme tilbage og spille igen, hvis de ønsker  
                void GTMenu()
                {
                    //Her clearer man det så kommer før
                    Console.Clear();

                    //Starter med en lille velkomst besked til spillet og hvad spillet handler om, for brugervenlighed
                    Console.WriteLine($"Velkommen til spillet Gæt et tal.");
                    Console.WriteLine($"Som title angiver skal du, {userName}, i dette spil gætte et tal som Computeren har generer.\n");

                    //Her fortæller man at brugeren har 3 muligheder, at vælge i mellem
                    Console.WriteLine("Du har mulighed for at vælge en sværhedsgrad, og har følgende muligheder:\n");
                    Console.WriteLine("1. Nem: Gæt et tal mellem 1 - 10.");
                    Console.WriteLine("2. Mellem: Gæt er tal mellem 1 - 100.");
                    Console.WriteLine("3. Svær: Gæt et tal mellem 1 - 1000.");
                    Console.WriteLine("0. Afslut spillet");

                    string gt_userInput = Console.ReadLine();
                    int gt_diffeculty = Convert.ToInt16(gt_userInput); 

                    if (gt_diffeculty == 0)
                    {
                        Menu();
                        return;
                    }

                    //Her laver man en forgrening med switch for overskueligheden skyld. I switchen finder man 3 funktioner.
                    //De 3 funktioner indekere sværhedsgraden, som er nem, melllem og svær
                    switch (gt_diffeculty)
                    {
                        case 1:
                            GTEasy();
                            break;

                        case 2:
                            GTMedium();
                            break;

                        case 3  :
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
                    Console.Clear();
                    Console.WriteLine("Computeren vil genere et nummer til dig mellem 1 - 10, som du nu skal prøve at gætte.");
                    Console.WriteLine("Du har 3 liv til at gætte tallet computeren har generet.");

                    // Generer et tilfældigt tal:
                    int gt_randomNumber = new Random().Next(1, 10);
  
                    //Her definere man variablen brugerens gæt
                    int gt_userGuess = (0);

                    //Her bruger man en while løkke, så man kan blive ved med at spille, hvis man gætter forkert.
                    while (gt_userGuess != gt_randomNumber)
                    {
                        Console.WriteLine("Gæt et tal:\n");

                        //Her konveterer man int til readline, så brugere kan indtaste sit gæt
                        gt_userGuess = Convert.ToInt16(Console.ReadLine());

                        //Her udregner man hvor langt man er fra det computere har genéret. Man anvender Math.abs så man er sikret værdien altid vil forblive positiv
                        int gt_numberFrom = Math.Abs(gt_userGuess - gt_randomNumber);

                        //Her bruger man if/else så, hvis man gætter rigtig for man en besked og gætter man forkert får man en anden
                        if (gt_randomNumber == gt_userGuess)
                        {
                            Console.WriteLine("\nSucces, du gættede rigtigt og har vundet!");
                            Console.WriteLine("Tast en vilkårlige tast og returner til Lauras spil menu");
                            Console.ReadKey();
                            GTMenu();
                            return;
                        }

                        else
                        {
                            //Her siger man, at når brugeren har gættet forkert mister de et liv
                            gt_userLife--;

                            /* Man benytter en if sætning, så kun noget tekst kommer frem.
                             Man har i spillet valgt at der kun skal være en livlinje ved 1 liv,
                             hvilket er hvor der er er mange if sætninger. Man kunne sagtens for overkuelighedenskyld
                             have haft en fælles if sætnigen for når liv er 2 og 1.*/
                            if (gt_userLife == 2)
                            {
                                Console.WriteLine("\nPrøv igen");

                                //Man buger disse to if sætninger til at fortælle brugeren om de er over eller under tallet de skal gætte
                                if (gt_userGuess>gt_randomNumber)
                                {
                                    Console.WriteLine("Dit gæt er over, det tal computeren har generet");
                                }

                                if (gt_userGuess<gt_randomNumber)
                                {
                                    Console.WriteLine("Dit gæt er under, det tal computeren har generet");
                                }

                                //Her fortæller man brugere hvor mange liv det har tilbage
                                Console.WriteLine($"Du har {gt_userLife} liv tilbage.\n");
                            }

                            //Denne if kommmer når brugeren har et liv igen, som en form for livline eller hjælp til brugeren
                            if (gt_userLife == 1)
                            {
                                Console.WriteLine("\nPrøv igen");
                                Console.WriteLine($"Du er {gt_numberFrom} fra det tallet.\n");
                               
                                //Man buger disse to if sætninger til at fortælle brugeren om de er over eller under tallet de skal gætte
                                if (gt_userGuess > gt_randomNumber)
                                {
                                    Console.WriteLine("Dit gæt er over, det tal computeren har generet");
                                }

                                if (gt_userGuess < gt_randomNumber)
                                {
                                    Console.WriteLine("Dit gæt er under, det tal computeren har generet");
                                }
                            }

                            //Her er en if sætning, somkommer frem når man ikke har flere liv 
                            if (gt_userLife == 0)
                            {
                                Console.WriteLine("\nDu er desværre død!");
                                Console.WriteLine("Tast en vilkårlige tast og returner til Lauras spil menu.");
                                Console.ReadKey();

                                GTMenu();
                                return;
                            }
                        }
                    }
                }

                // Det er en funktion, hvor der skal være middel at gætte tallet
                void GTMedium()
                {
                    Console.Clear();
                    Console.WriteLine("Computeren vil genere et nummer til dig mellem 1 - 100, som du nu skal prøve at gætte.");
                    Console.WriteLine("Du har 3 liv til at gætte tallet computeren har generet.");

                    // Generer et tilfældigt tal mellem 1 og 100:
                    int gt_randomNumber = new Random().Next(1, 100);

                    //Her definere man variablen brugerens gæt
                    int gt_userGuess = (0);

                    //Her bruger man en while løkke, så man kan blive ved med at spille, hvis man gætter forkert
                    while (gt_userGuess != gt_randomNumber)
                    {
                        Console.WriteLine("Gæt et tal:");

                        //Her konveterer man int til readline, så brugere kan indtaste sit gæt
                        gt_userGuess = Convert.ToInt16(Console.ReadLine());

                        //Her udregner man hvor langt man er fra det computere har genéret. Man anvender Math.abs så man er sikret værdien altid vil forblive positiv
                        int gt_numberFrom = Math.Abs(gt_userGuess - gt_randomNumber);

                        //Her bruger man if/else så, hvis man gætter rigtig for man en besked og gætter man forkert får man en anden
                        if (gt_randomNumber == gt_userGuess)
                        {
                            Console.WriteLine("\nSucces, du gættede rigtigt og har vundet!");
                            Console.WriteLine("Tast en vilkårlige tast og returner til Lauras spil menu.");
                            Console.ReadKey();
                            GTMenu();
                            return;
                        }

                        else
                        {
                            //Her siger man, at når brugeren har gættet forkert mister de et liv
                            gt_userLife--;

                            /* Man benytter en if sætning, så kun noget tekst kommer frem.
                            Man har i spillet valgt at der kun skal være en livlinje ved 1 liv,
                            hvilket er hvor der er er mange if sætninger. Man kunne sagtens for overkuelighedenskyld
                            have haft en fælles if sætnigen for når liv er 2 og 1.*/
                            if (gt_userLife == 2)
                            {
                                Console.WriteLine("\nPrøv igen");

                                //Man buger disse to if sætninger til at fortælle brugeren om de er over eller under tallet de skal gætte
                                if (gt_userGuess > gt_randomNumber)
                                {
                                    Console.WriteLine("Dit gæt er over, det tal computeren har generet");
                                }

                                if (gt_userGuess < gt_randomNumber)
                                {
                                    Console.WriteLine("Dit gæt er under, det tal computeren har generet");
                                }

                                //Her fortæller man brugere hvor mange liv det har tilbage
                                Console.WriteLine($"Du har {gt_userLife} liv tilbage.\n");
                            }

                            //Denne if kommmer når brugeren har et liv igen, som en form for livline eller hjælp til brugeren
                            if (gt_userLife == 1)
                            {
                                Console.WriteLine("\nPrøv igen");
                                Console.WriteLine($"Du er {gt_numberFrom} fra det tallet.\n");

                                //Man buger disse to if sætninger til at fortælle brugeren om de er over eller under tallet de skal gætte
                                if (gt_userGuess > gt_randomNumber)
                                {
                                    Console.WriteLine("Dit gæt er over, det tal computeren har generet");
                                }

                                if (gt_userGuess < gt_randomNumber)
                                {
                                    Console.WriteLine("Dit gæt er under, det tal computeren har generet");
                                }
                            }

                            //Her er en if sætning, somkommer frem når man ikke har flere liv 
                            if (gt_userLife == 0)
                            {
                                Console.WriteLine("\nDu er desværre død!");
                                Console.WriteLine("Tast en vilkårlige tast og returner til Lauras spil menu.");
                                Console.ReadKey();

                                GTMenu();
                                return;
                            }
                        }
                    }
                }

                //Dette er en funktion, hvor det skal være svært at gætte tallet 
                void GTDifficult()
                {
                    Console.Clear();
                    Console.WriteLine("Computeren vil genere et nummer til dig mellem 1 - 1000, som du nu skal prøve at gætte.");
                    Console.WriteLine("Du har 3 liv til at gætte tallet computeren har generet.");

                    // Generer et tilfældigt tal mellem 1 og 1000:
                    int gt_randomNumber = new Random().Next(1, 1000);
                    int gt_userGuess = (0);

                    //Her bruger man en while løkke, så man kan blive ved med at spille, hvis man gætter forkert
                    while (gt_userGuess != gt_randomNumber)
                    {
                        Console.WriteLine("Gæt et tal:");

                        //Her konveterer man int til readline, så brugere kan indtaste sit gæt
                        gt_userGuess = Convert.ToInt16(Console.ReadLine());

                        //Her udregner man hvor langt man er fra det computere har genéret. Man anvender Math.abs så man er sikret værdien altid vil forblive positiv
                        int gt_numberFrom = Math.Abs(gt_userGuess - gt_randomNumber);

                        //Her bruger man if/else så, hvis man gætter rigtig for man en besked og gætter man forkert får man en anden
                        if (gt_randomNumber == gt_userGuess)
                        {
                            Console.WriteLine("\nSucces, du gættede rigtigt og har vundet!");
                            Console.WriteLine("Tast en vilkårlige tast og returner til Lauras spil menu.");
                            Console.ReadKey();
                            GTMenu();
                            return;
                        }

                        else
                        {
                            //Her siger man, at når brugeren har gættet forkert mister de et liv
                            gt_userLife--;

                            /* Man benytter en if sætning, så kun noget tekst kommer frem.
                            Man har i spillet valgt at der kun skal være en livlinje ved 1 liv,
                            hvilket er hvor der er er mange if sætninger. Man kunne sagtens for overkuelighedenskyld
                            have haft en fælles if sætnigen for når liv er 2 og 1.*/
                            if (gt_userLife == 2)
                            {
                                Console.WriteLine("\nPrøv igen");

                                //Man buger disse to if sætninger til at fortælle brugeren om de er over eller under tallet de skal gætte
                                if (gt_userGuess > gt_randomNumber)
                                {
                                    Console.WriteLine("Dit gæt er over, det tal computeren har generet");
                                }

                                if (gt_userGuess < gt_randomNumber)
                                {
                                    Console.WriteLine("Dit gæt er under, det tal computeren har generet");
                                }

                                //Her fortæller man brugere hvor mange liv det har tilbage
                                Console.WriteLine($"Du har {gt_userLife} liv tilbage.\n");
                            }

                            //Denne if kommmer når brugeren har et liv igen, som en form for livline eller hjælp til brugeren
                            if (gt_userLife == 1)
                            {
                                Console.WriteLine("\nPrøv igen");
                                Console.WriteLine($"Du er {gt_numberFrom} fra det tallet.\n");

                                //Man buger disse to if sætninger til at fortælle brugeren om de er over eller under tallet de skal gætte
                                if (gt_userGuess > gt_randomNumber)
                                {
                                    Console.WriteLine("Dit gæt er over, det tal computeren har generet");
                                }

                                if (gt_userGuess < gt_randomNumber)
                                {
                                    Console.WriteLine("Dit gæt er under, det tal computeren har generet");
                                }
                            }

                            //Her er en if sætning, somkommer frem når man ikke har flere liv 
                            if (gt_userLife == 0)
                            {
                                Console.WriteLine("\nDu er desværre død!");
                                Console.WriteLine("Tast en vilkårlige tast og returner til Lauras spil menu.");
                                Console.ReadKey();

                                GTMenu();
                                return;
                            }
                        }
                    }
                }
            }

            //Lasse Spil (primært valg af sværhedsgrad og ordlister)
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

                //Menu med valg af sværhedsgrad, vi bliver i denne menu indtil der foretages et gyldigt valg
                while (true)
                {
                    Console.WriteLine("Vælg sværhedsgrad:\n");
                    Console.WriteLine("1. Nem");
                    Console.WriteLine("2. Mellem");
                    Console.WriteLine("3. Svær");
                    Console.WriteLine("4. Umulig.. du kan glemme det");
                    Console.WriteLine("0. Afslut spillet");

                    //Menuvalg gemmmes
                    string hm_menuinput = Console.ReadLine();

                    //Kontrol af om brugeren skrev et tal
                    if (!int.TryParse(hm_menuinput, out int hm_menuchoice))

                    {
                        Console.WriteLine("Ugyldigt valg, prøv igen.");
                        continue;
                    }

                    // Mulighed for at kalde Menu() og returnere til hovedmenu
                    if (hm_menuchoice == 0)
                    {
                        Menu();
                        return;
                    }

                    //Her vælges den rigtige ordliste ud fra brugerinput og hm_Game kaldes.
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

                        /*/
                           Spil funktion (én runde)
                           Ord vælges og viser underscores i stedet for tegn og spilleren gætter ét bogstav ad gangen.
                           Runden stopper når ordet er gættet eller livene er brugt
                        /*/
                        void hm_Game()
                        {
                            Console.Clear();
                            Console.WriteLine("Spillet starter nu!");

                            //Vælger et tilfældigt ord fra det valgte array med sværhedsgrad
                            string hm_selectedword = hm_wordlist[hm_rng.Next(hm_wordlist.Length)];

                            //Skriver ordet om til '_' form i stedet for bogstaver
                            char[] hm_wordchar = new char[hm_selectedword.Length];
                            for (int i = 0; i < hm_wordchar.Length; i++)
                            {
                                //Viser '_' for hvert bogstav i det valgte ord
                                hm_wordchar[i] = '_';
                            }

                            //Vareiabel til vise antallet af forkerte gæt
                            int hm_wrongguesses = 0;

                            //String til at gemme de bogstaver brugeren har gættet
                            string hm_guessedLetters = "";

                            //Antal liv brugeren har per runde
                            int hm_lifetotal = 5;

                            //Spil-løkke der kører indtil brugeren gætter ordet eller løber tør for liv
                            while (hm_wrongguesses < hm_lifetotal)
                            {
                                Console.Clear();
                                Console.WriteLine($"Du har {hm_lifetotal - hm_wrongguesses} liv tilbage.");
                                Console.WriteLine($"Du har gættet på følgende bogstaver: {hm_guessedLetters}");

                                //Viser ordet med '_' og gættede bogstaver
                                for (int i = 0; i < hm_wordchar.Length; i++)
                                {
                                    Console.Write(hm_wordchar[i] + " ");
                                }
                                Console.WriteLine();

                                //Spørger spilleren om et bogstav og ændrer det til lower-case så de behandles ens.
                                Console.Write("Gæt et bogstav:");
                                string hm_userguess = Console.ReadLine().ToLower();

                                //Kontrol af gyldigt input (længde må kun være ét tegn)
                                if (hm_userguess.Length != 1)
                                {
                                    Console.WriteLine("Indtast venligst kun ét bogstav.");
                                    continue;
                                }
                                char hm_userguesschar = hm_userguess[0];

                                //Tjekker om det er et bogstav (A-Å)
                                if (!char.IsLetter(hm_userguesschar))
                                {
                                    Console.WriteLine("Indtast venligst et bogstav (A-Å).");
                                    continue;
                                }

                                //Tjekker om det allerede er gættet på tidligere
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
                                        //Viser det korrekte bogstav i stedet for underscore
                                        hm_wordchar[i] = hm_selectedword[i];
                                        hm_correctguess = true;
                                    }
                                }

                                //Hvis det gættede bogstav ikke er i ordet tæller hm_wrongguesses op og brugeren bruger derfor ét liv
                                if (!hm_correctguess)
                                {
                                    hm_wrongguesses++;
                                }

                                //Tjekker om ordet er gættet, altså om der ikke er nogle underscores tilbage.
                                bool hm_wordcomplete = true;
                                for (int i = 0; i < hm_wordchar.Length; i++)
                                {
                                    if (hm_wordchar[i] == '_')
                                    {
                                        hm_wordcomplete = false;
                                        break;
                                    }
                                }
                                //Er ordet gættet får brugeren besked herom og får mulighed for at vende tilbage til menuen
                                if (hm_wordcomplete)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Tillykke, {userName}! Du har gættet ordet: {hm_selectedword} med {hm_wrongguesses} forkerte gæt.");
                                    Console.WriteLine("Tryk på en tast for at vende tilbage til menuen");
                                    Console.ReadKey();
                                    break;
                                }

                                //Hvis brugeren har flere forkerte gæt end liv får brugeren besked herom og får mulighed for at vende tilbage til menuen
                                if (hm_wrongguesses >= hm_lifetotal)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Desværre, {userName}.\n Du har brugt alle dine liv. \n Ordet var: {hm_selectedword}");
                                    Console.WriteLine("Tryk på en tast for at vende tilbage til menuen");
                                    Console.ReadKey();
                                }
                            }
                        }
                    }
                }
            }
        
        }
    }
}
