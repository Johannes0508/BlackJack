using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace blackjack_v2
{
    public class Gamemanager
    {
        public int maxpoäng = 21;
        public int playerPoints = 0;
        public int dealerPoints = 0;
        public bool playerTurn = true;


        int[] cardArray =
        {
            1, 1, 1, 1,
            2, 2, 2, 2,
            3, 3, 3, 3,
            4, 4, 4, 4,
            5, 5, 5, 5,
            6, 6, 6, 6,
            7, 7, 7, 7,
            8, 8, 8, 8,
            9, 9, 9, 9,
            10, 10, 10,10,
            11, 11, 11, 11,
            12, 12, 12, 12,
            13, 13, 13, 13

            };
        List<int> cards = new List<int>();
        public void list()
        {
            for (int i = 0; i < cardArray.Length; i++)
            {
                cards.Add(cardArray[i]);
            }
        }

        public void card()
        {

            Random random = new Random();

            int localValue = random.Next(0, cards.Count);
            if (playerTurn == true)
            {
                playerPoints += cardArray[localValue];
            }
            else
            {
                dealerPoints += cardArray[localValue];
            }

            cards.RemoveAt(localValue);

        }

    }
    class Program
    {


        static void Main(string[] args)
        {

            int delay = 750;
            int display_delay = 1000;

            Gamemanager cards = new Gamemanager();
            string input = string.Empty;
            bool ifDone = false;
            cards.list();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("you are Green");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("dealer is red");
            Console.WriteLine("");

            while (ifDone == false)
            {
                

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Type h to hit or s to Stand");
                input = Console.ReadLine();
                if (input == "h")
                {
                    cards.card();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(cards.playerPoints);
                    if (cards.playerPoints > 21)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Thread.Sleep(display_delay);
                        Console.WriteLine("dealer won!");
                        ifDone = true;
                        break;
                    }
                    if (cards.playerPoints == 21)
                    {
                        break;
                    }
                    //draw a card from gamemanger
                }
                else if (input == "s")
                {
                    cards.playerTurn = false;
                    //dealers turn
                    while (ifDone == false)
                    {
                        cards.card();

                        if (cards.dealerPoints >= 17)
                        {
                            //stand
                            ifDone = true;
                            Thread.Sleep(delay);
                            Console.WriteLine(cards.dealerPoints);
                        }
                        if (cards.dealerPoints <= 16)
                        {
                            //hit
                            Console.ForegroundColor = ConsoleColor.Red;
                            Thread.Sleep(delay);
                            Console.WriteLine(cards.dealerPoints);
                            

                        }
                        if (cards.dealerPoints > 21)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Thread.Sleep(display_delay);
                            Console.WriteLine("you Won");
                            ifDone = true;
                            break;
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Try again");
                }
            }
            if (cards.dealerPoints > cards.playerPoints && cards.dealerPoints <= cards.maxpoäng)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Thread.Sleep(display_delay);
                Console.WriteLine("dealer won");
            }
            else if (cards.playerPoints > cards.dealerPoints && cards.playerPoints <= cards.maxpoäng)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Thread.Sleep(display_delay);
                Console.WriteLine("player Won");
            }
            else if (cards.dealerPoints == cards.playerPoints)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(display_delay);
                Console.WriteLine("Draw");
            }
        }
    }
}