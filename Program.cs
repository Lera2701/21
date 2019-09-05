using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        public static int score = 0;
        public static int dealerScore = 0;
        static Random x = new Random();
        static Random d = new Random();

        public static void Addition(ref int sc)
        {            
            int card = x.Next(2, 15);
            switch (card)
            {
                case 11:
                    Console.WriteLine("Card: Ace");
                    if (sc > 10) sc += 1;
                    else sc += card;
                    break;

                case 12:
                    Console.WriteLine("Card: Jack");
                    sc += 10;
                    break;

                case 13:
                    Console.WriteLine("Card: Queen");
                    sc += 10;
                    break;

                case 14:
                    Console.WriteLine("Card: King");
                    sc += 10;
                    break;

                default:
                    Console.WriteLine($"Card: {card}");
                    sc += card;
                    break;
            }
        }

        static void Step()
        {
            Console.WriteLine("Do you want another one? Print \"y\" or \"n\"");
            var x = Console.ReadLine();
            if (x == "n")
            {
                Console.WriteLine($"You: {score}");
                Console.WriteLine("-------------");
                if (score >= 20 && dealerScore >= 20 && score == dealerScore) Resume();
                if (dealerScore < 20)
                {
                    Console.WriteLine("Dealer turn.");
                    Console.WriteLine("");
                    DealerStep();
                }
                Resume();
            }
            else if (x == "y")
            {
                Addition(ref score);
                Console.WriteLine($"You: {score}");
                if (score < 22) Step();
                else Console.WriteLine("You lost!");
            }
            else
            {
                Console.WriteLine("Print \"y\" or \"n\"");
                Step();
            }
        }

        static void DealerStep()
        {
            int card = d.Next(1, 4);
            switch (card)
            {
                case 1:
                    Addition(ref dealerScore);
                    if (dealerScore >= 21)
                    {
                        Console.WriteLine($"Dealer: {dealerScore}");
                        break;
                    }
                    Console.WriteLine($"Dealer: {dealerScore}");
                    break;

                case 2:
                    Addition(ref dealerScore);
                    if (dealerScore >= 21)
                    {
                        Console.WriteLine($"Dealer: {dealerScore}");
                        break;
                    }
                    Addition(ref dealerScore);
                    if (dealerScore >= 21)
                    {
                        Console.WriteLine($"Dealer: {dealerScore}");
                        break;
                    }
                    Console.WriteLine($"Dealer: {dealerScore}");
                    break;

                case 3:
                    Addition(ref dealerScore);
                    if (dealerScore >= 21)
                    {
                        Console.WriteLine($"Dealer: {dealerScore}");
                        break;
                    }
                    Addition(ref dealerScore);
                    if (dealerScore >= 21)
                    {
                        Console.WriteLine($"Dealer: {dealerScore}");
                        break;
                    }
                    Addition(ref dealerScore);
                    if (dealerScore >= 21)
                    {
                        Console.WriteLine($"Dealer: {dealerScore}");
                        break;
                    }
                    Console.WriteLine($"Dealer: {dealerScore}");
                    break;
            }
        }

        static void Resume()
        {
            Console.WriteLine("-------------");
            if (dealerScore > 21 && score < 22 || dealerScore < 22 && score < 22 && score > dealerScore) Console.WriteLine("You won!");
            else if (score == dealerScore) Console.WriteLine("Ended in a drow!");
            else Console.WriteLine("You lost!");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            Console.WriteLine("-------------");

            Console.WriteLine("Dealer turn.");
            Console.WriteLine("");
            Addition(ref dealerScore);
            Addition(ref dealerScore);
            Console.WriteLine($"Dealer: {dealerScore}");
            Console.WriteLine("-------------");

            Console.WriteLine("Your turn.");
            Console.WriteLine("");

            Addition(ref score);
            Console.WriteLine($"You: {score}");
            Console.WriteLine("-------------");
            Step();
            Console.ReadKey();
        }
    }
}
