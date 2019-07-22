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
            Console.WriteLine("\nOkay Gamer, you get one shot at this, make it count!");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~");
            Bomb.StageBuilder(solved, 12);
            printInfo(timer);
            Turns(timer, solved);
            
        }
        public static void printInfo(int timer)
        {
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
                Console.WriteLine("\nChoose a part to disarm [case sensitive]\nEnter 'list' to see the parts you tested out of order.\n");
                string component = Console.ReadLine();
                if (component == "list")
                {
                    foreach (string item in Bomb.TestedParts)
                    {
                        Console.WriteLine(item);
                    }
                } else
                {
                string test = Bomb.disarmAttempt(component);
                if (test == "success")
                {
                    Console.WriteLine("\nNice choice find the next.");
                    diffused ++;
                }
                else if (test == "fail")
                {
                    Console.WriteLine("Looks like thats the wrong order, rememeber this for later");
                    Console.WriteLine("!      !    !     !      !");
                    timer -=2;

                }
                else 
                {
                    Console.WriteLine("OH NOOOO OH MY GAAAWWDDD HOREY SHEEEIITTT.");
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