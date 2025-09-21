using System;
using System.Linq;

namespace Akasztófa
{
    internal class Program
    {
        static int Healthpoint = 10;
        static string secret_word = "";
        static string shownwordNew;
        static string shownword = "";
        

        static void Main(string[] args)
        {
            string[] szavak = { "alma", "körte", "csengő", "bálna", "kuka", "zebra", "lézer", "rakéta"};
            var szamok = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            var leirtbetuk = "";
            Random rnd = new Random();
            secret_word = szavak[rnd.Next(szavak.Length)];

            for (int i = 0; i < secret_word.Length; i++)
            {
                shownword += "_";
            }

            shownwordNew = shownword;

            Console.WriteLine($"Üdvözöllek az akasztófa játékban!!!");
            Console.Title = "Akasztófa játék";
            do
            {
                if (leirtbetuk == "")
                {
                    ;
                }
                else
                {
                    Console.WriteLine($"Leírt betűk: {leirtbetuk}" );
                }
                Console.WriteLine("Adj meg egy betűt:");
                char betu = Convert.ToChar(Console.ReadLine());

                if (secret_word.Contains(betu))
                {
                    shownwordNew = "";
                    leirtbetuk += betu + " ";

                    for (int i = 0; i < secret_word.Length; i++)
                    {
                        if (secret_word[i] == betu)
                        {
                            shownwordNew += betu;
                        }
                        else
                        {
                            shownwordNew += shownword[i];
                        }
                    }

                    shownword = shownwordNew; // Frissítjük a jelenlegi állapotot
                    Console.Clear();
                    Console.WriteLine($"A(z) '{betu}' benne van a titkos szóban, még {Healthpoint} életed van.");
                    Console.WriteLine($"Aktuális állapot: {shownword}" );
                }
                else
                {
                    Healthpoint--;
                    Console.Clear();
                    if (szamok.Contains(Convert.ToString(betu)))
                    {
                        Console.WriteLine($"Számot nem adhatsz meg!  Már csak {Healthpoint} életed van.");
                        leirtbetuk += betu + " ";
                    }
                    else
                    {
                        Console.WriteLine($"Ez a betű nincs benne a szóban! Már csak {Healthpoint} életed van.");
                        leirtbetuk += betu + " ";
                    }
                    Console.WriteLine($"Aktuális állapot: {shownword}" );
                }

                if (shownword == secret_word)
                {
                    Console.WriteLine($"Nyertél, kitaláltad a szót: {secret_word}");
                    break;
                }

            } while (Healthpoint != 0);

            if (Healthpoint == 0)
            {
                Console.WriteLine($"Vesztettél! A szó ez volt: {secret_word}");
            }
        }
    }
}
