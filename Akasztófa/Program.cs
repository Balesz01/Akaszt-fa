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
        static string valasztas = "";
        static string megerosites = "";
        static string valasztas2 = "";
        static string valasztas3 = "";

        static void Main(string[] args)
        {
            string[] szavak = { "alma", "körte", "csengő", "bálna", "kuka", "zebra", "lézer", "rakéta" };
            var szamok = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            Random rnd = new Random();

            Console.Title = "Akasztófa játék";

            do
            {
                Console.Clear();
                Console.WriteLine("Üdvözöllek az akasztófa játékban!!!");
                Console.WriteLine("1. Játék Kezdése");
                Console.WriteLine("2. Beállítások");
                Console.WriteLine("3. Kilépés");
                valasztas = Console.ReadLine();

                if (valasztas == "1")
                {
                    // Játék újraindítása
                    Healthpoint = 10;
                    secret_word = szavak[rnd.Next(szavak.Length)];
                    shownword = new string('_', secret_word.Length);
                    shownwordNew = shownword;
                    string leirtbetuk = "";
                    Console.Clear();

                    do
                    {
                        if (leirtbetuk != "")
                        {
                            Console.WriteLine($"Leírt betűk: {leirtbetuk}");
                        }
                        Console.WriteLine($"Életeid száma: {Healthpoint}");
                        Console.WriteLine($"Aktuális állapot: {shownword}");
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

                            shownword = shownwordNew;
                            Console.Clear();
                            Console.WriteLine($"A(z) '{betu}' benne van a titkos szóban, még {Healthpoint} életed van.");
                            Console.WriteLine($"Aktuális állapot: {shownword}");
                        }
                        else
                        {
                            Healthpoint--;
                            Console.Clear();
                            if (szamok.Contains(betu.ToString()))
                            {
                                Console.WriteLine($"Számot nem adhatsz meg! Már csak {Healthpoint} életed van.");
                            }
                            else
                            {
                                Console.WriteLine($"Ez a betű nincs benne a szóban! Már csak {Healthpoint} életed van.");
                            }
                            leirtbetuk += betu + " ";
                            Console.WriteLine($"Aktuális állapot: {shownword}");
                        }

                        if (shownword == secret_word)
                        {
                            Console.Clear();
                            Console.WriteLine($"Nyertél, kitaláltad a szót: {secret_word}");
                            Console.WriteLine("Nyomj ENTER-t a főmenübe lépéshez...");
                            Console.ReadLine();
                            break;
                        }

                    } while (Healthpoint != 0);

                    if (Healthpoint == 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"Vesztettél! A szó ez volt: {secret_word}");
                        Console.WriteLine("Nyomj ENTER-t a főmenübe lépéshez...");
                        Console.ReadLine();
                    }
                }

                else if (valasztas == "2")
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("1. Betű szín");
                        Console.WriteLine("2. Háttér szín");
                        Console.WriteLine("3. Vissza a főmenübe");
                        valasztas2 = Console.ReadLine();

                        if (valasztas2 == "1")
                        {
                            Console.Clear();
                            Console.WriteLine("Ez itt a betű szín beállító!");
                            Console.WriteLine("1. Fehér");
                            Console.WriteLine("2. Sárga");
                            Console.WriteLine("3. Piros");
                            valasztas3 = Console.ReadLine();

                            if (valasztas3 == "1") Console.ForegroundColor = ConsoleColor.White;
                            else if (valasztas3 == "2") Console.ForegroundColor = ConsoleColor.Yellow;
                            else if (valasztas3 == "3") Console.ForegroundColor = ConsoleColor.Red;
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Nincs ilyen opció!");
                            }
                        }
                        else if (valasztas2 == "2")
                        {
                            Console.Clear();
                            Console.WriteLine("Ez itt a háttér szín beállító!");
                            Console.WriteLine("1. Fekete");
                            Console.WriteLine("2. Kék");
                            Console.WriteLine("3. Zöld");
                            valasztas3 = Console.ReadLine();

                            if (valasztas3 == "1") Console.BackgroundColor = ConsoleColor.Black;
                            else if (valasztas3 == "2") Console.BackgroundColor = ConsoleColor.Blue;
                            else if (valasztas3 == "3") Console.BackgroundColor = ConsoleColor.Green;
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Nincs ilyen opció!");
                            }
                        }
                        else if (valasztas2 == "3")
                        {
                            break;
                        }

                    } while (true);
                }

                else if (valasztas == "3")
                {
                    Console.Clear();
                    Console.WriteLine("Biztos hogy ki akarsz lépni? (i/h)");
                    megerosites = Console.ReadLine();
                    if (megerosites == "i")
                    {
                        Console.WriteLine("Viszlát!");
                        return;
                    }
                    else
                    {
                        valasztas = "";
                    }
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("Nincs ilyen opció, próbáld újra!");
                }

            } while (valasztas != "3");
        }
    }
}
