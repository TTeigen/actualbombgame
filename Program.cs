using System;
using System.Collections.Generic;


namespace BombGame
{
    class Program
    {
        public static Random rnd = new Random();
        public static void Main()
        {
            int solved = 5;
            int timer = 60;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nOkay Gamer, you get one shot at this, make it count!");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("You need to interact with the 5 parts of the mechanism in the correct order if you want to diffuse this bomb. Wrong guess cost you 4 seconds, out of order guesses COULD cost you extra time. Good Luck!");
            Bomb.StageBuilder(solved, 12);
            printInfo(timer);
            Turns(timer, solved);
            
        }
        public static void printInfo(int timer)
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Timer Reads:  " + timer+"\n");
            Console.ForegroundColor = ConsoleColor.Black;
            List<string> counter = new List<string>();
            counter.Clear();
            do
            {
                int i = rnd.Next(0, Bomb.Printable.Count);
                string partToAdd = Bomb.Printable[i];
                if (!counter.Contains(partToAdd))
                {
                                       
                    counter.Add(partToAdd);
                }
            } while (counter.Count < Bomb.Printable.Count);
            foreach(string item in counter)
            {
                Console.WriteLine(item);
            }
        }
        public static void Turns(int timer,int solved)
        {
            int diffused = 0;
            do
            {
                Console.WriteLine("\nChoose a part to disarm [case sensitive]");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Remember to check your list with 'list';\n");
                Console.ForegroundColor = ConsoleColor.Black;
                string component = Console.ReadLine();
                if (component == "list")
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    foreach (string item in Bomb.TestedParts)
                    {
                        Console.WriteLine(item);
                    }
                    Console.ForegroundColor = ConsoleColor.Black;
                } else
                {
                string test = Bomb.disarmAttempt(component);
                if (test == "success")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\nNice choice find the next.");
                    Console.ForegroundColor = ConsoleColor.Black;
                    diffused ++;
                }
                else if (test == "fail")
                {   
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Looks like thats the wrong order, part added to your 'list'");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("!      !    !     !      !");
                    if (Bomb.TestedParts.Count%2 == 0)
                    {
                        timer -=2;
                    }

                }
                else 
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("OH NOOOO OH MY GAAAWWDDD HOREY SHEEEIITTT.");
                    Console.ForegroundColor = ConsoleColor.Black;
                    timer -= 3;
                }
                timer--;
                printInfo(timer);
                }
            } while (diffused < solved && timer > 0);
            if (timer > 0)
            {
                Console.WriteLine("\nYou did it! Bomb diffused");
            } else
            {
                Console.WriteLine("\nBOOM YOU DED!");
            }
        }
    }
}