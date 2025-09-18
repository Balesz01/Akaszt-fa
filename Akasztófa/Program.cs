using System;
using System.Linq;

namespace Akasztófa
{
    internal class Program
    {
        static int Healthpoint = 17;
        static string secret_word = "";
        static string secret_word_cha;
        static string shownwordNew;

        static void Main(string[] args)
        {
            string[] szavak = { "alma" };
            Random rnd = new Random();
            secret_word = szavak[rnd.Next(szavak.Length)];
            string shownword = "";
            string shownwordNew = shownword;
            secret_word_cha = secret_word;

            for (int i = 0; i < secret_word.Length; i++)
            {
                shownword += "_";
            }
            do
            {
                Console.WriteLine("Adj meg egy betűt:");
                char betu = Convert.ToChar(Console.ReadLine());

                if (secret_word.Contains(betu))
                {
                    while (secret_word_cha.Contains(betu))
                    {
                        secret_word_cha = secret_word_cha.Remove(secret_word_cha.IndexOf(betu), 1);
                    }
                    while (secret_word_cha.Contains(betu))
                    {
                        shownwordNew = shownword.Replace("_", betu);
                    }

                    Console.WriteLine($"A {betu} benne van a titkos szóban még {Healthpoint} életed maradt!");
                }
                else
                {
                    Healthpoint--;
                    Console.WriteLine($"Ez a betű nincsen benne a szóban vagy már nincs ezért már csak {Healthpoint} életed maradt!");
                }

                if (secret_word_cha == "")
                {
                    Console.WriteLine($"Nyertél, kitaláltad a szót!");
                    break;
                }

            } while (Healthpoint != 0);
        }
    }
}
