using System;
using System.Linq;

namespace Akasztófa
{
    internal class Program
    {
        static int Healthpoint = 17;
        static string secret_word = "";
        static string shownwordNew;
        static string shownword = "";

        static void Main(string[] args)
        {
            string[] szavak = { "alma" };
            Random rnd = new Random();
            secret_word = szavak[rnd.Next(szavak.Length)];

            for (int i = 0; i < secret_word.Length; i++)
            {
                shownword += "_";
            }

            shownwordNew = shownword;

            do
            {
                Console.WriteLine("Adj meg egy betűt:");
                char betu = Convert.ToChar(Console.ReadLine());

                if (secret_word.Contains(betu))
                {
                    shownwordNew = "";

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

                    Console.WriteLine($"A(z) '{betu}' benne van a titkos szóban, még {Healthpoint} életed van.");
                    Console.WriteLine("Aktuális állapot: " + shownword);
                }
                else
                {
                    Healthpoint--;
                    Console.WriteLine($"Ez a betű nincs benne a szóban! Már csak {Healthpoint} életed van.");
                    Console.WriteLine("Aktuális állapot: " + shownword);
                }

                if (shownword == secret_word)
                {
                    Console.WriteLine("Nyertél, kitaláltad a szót: " + secret_word);
                    break;
                }

            } while (Healthpoint != 0);

            if (Healthpoint == 0)
            {
                Console.WriteLine("Vesztettél! A szó ez volt: " + secret_word);
            }
        }
    }
}
