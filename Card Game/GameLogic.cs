using System;
using System.Collections.Generic;
using System.Text;

namespace Card_Game
{
    class GameLogic
    {
        private static int draws = 0;
        private static int mode = 0;
        private static Deck deck = new Deck();

        public static void StartGame(int m)
        {
            mode = m;
            PlayGame();
        }

        private static void PlayGame()
        {
            // builds deck for dealing cards
            deck.BuildDeck();
            deck.ShuffleDeck();

            // creates player object to allow for storing cards, current hand, current hand wins
            // player1 will always be created as there will always be at least one player
            Player player1 = new Player();
            for (int i = 0; i < 10; i++)
            {
                player1.currentDeck.Add(deck.DealCard());
            }

            // calls either the PvP method or the PvC method based on mode
            switch (mode)
            {
                case 0:
                    PvP(player1);                   
                    break;
                case 1:
                    PvC(player1);
                    break;
                default:
                    break;
            }
        }

        private static void PvP(Player player1)
        {
            // creates another player object to allow for pvp
            Player player2 = new Player();
            for (int i = 0; i < 10; i++)
            {
                player2.currentDeck.Add(deck.DealCard());
            }

            // runs the game, while loop stops when either player has ran out of cards
            while (player1.currentDeck.Count > 1 && player2.currentDeck.Count > 1)
            {
                Console.WriteLine("Player 1's turn to choose. Player 2 look away from the screen! Press any key once ready ");
                Console.ReadKey();
                player1.ChooseCards();
                Console.Clear();
                Console.WriteLine("Player 2's turn to choose. Player 1 look away from the screen! Press any key once ready ");
                Console.ReadKey();
                player2.ChooseCards();


                Console.WriteLine($"\n\n\nPlayer 1's chosen cards where {player1.currentHand[0].name} of {player1.currentHand[0].suit} and {player1.currentHand[1].name} of {player1.currentHand[1].suit}" +
                    $"\nPlayer 2's chosen cards where {player2.currentHand[0].name} of {player2.currentHand[0].suit} and {player2.currentHand[1].name} of {player2.currentHand[1].suit}" +
                    $"\n\nPlayer 1's chosen cards totalled to: {player1.currentHand[0].value + player1.currentHand[1].value}" +
                    $"\nPlayer 2's chosen cards totalled to: {player2.currentHand[0].value + player2.currentHand[1].value}");


                if (player1.currentHand[0].value + player1.currentHand[1].value == player2.currentHand[0].value + player2.currentHand[1].value)
                {
                    draws++;
                    Console.WriteLine($"Cards are equal, currently at {draws} draws...");
                }
                else if (player1.currentHand[0].value + player1.currentHand[1].value > player2.currentHand[0].value + player2.currentHand[1].value)
                {
                    Console.WriteLine($"\nPlayer 1 wins!");
                    player1.handsWon++;
                    player1.handsWon += draws;
                    draws = 0;
                }
                else
                {
                    Console.WriteLine($"\nPlayer 2 wins!");
                    player2.handsWon++;
                    player2.handsWon += draws;
                    draws = 0;
                }

                player1.currentHand.Clear();
                player2.currentHand.Clear();
            }

            Console.WriteLine($"\n\n\nPlayer 1 = {player1.handsWon} wins\nPlayer 2 = {player2.handsWon} wins");
        }

        private static void PvC(Player player1)
        {
            // creates another player object to allow for pvp
            Computer cpu = new Computer();
            for (int i = 0; i < 10; i++)
            {
                cpu.currentDeck.Add(deck.DealCard());
            }

            // runs the game, while loop stops when either player has ran out of cards
            while (player1.currentDeck.Count > 1 && cpu.currentDeck.Count > 1)
            {
                player1.ChooseCards();
                cpu.ChooseCard();
                cpu.ChooseCard();

                Console.WriteLine($"\n\n\nPlayer's chosen cards where {player1.currentHand[0].name} of {player1.currentHand[0].suit} and {player1.currentHand[1].name} of {player1.currentHand[1].suit}" +
                    $"\nComputer's chosen cards where {cpu.currentHand[0].name} of {cpu.currentHand[0].suit} and {cpu.currentHand[1].name} of {cpu.currentHand[1].suit}" +
                    $"\n\nPlayer's chosen cards totalled to: {player1.currentHand[0].value + player1.currentHand[1].value}" +
                    $"\nComputer's chosen cards totalled to: {cpu.currentHand[0].value + cpu.currentHand[1].value}");

                if (player1.currentHand[0].value + player1.currentHand[1].value == cpu.currentHand[0].value + cpu.currentHand[1].value)
                {
                    draws++;
                    Console.WriteLine($"Cards are equal, currently at {draws} draws...");
                }
                else if (player1.currentHand[0].value + player1.currentHand[1].value > cpu.currentHand[0].value + cpu.currentHand[1].value)
                {
                    Console.WriteLine($"\nPlayer wins!");
                    player1.handsWon++;
                    player1.handsWon += draws;
                    draws = 0;
                }
                else
                {
                    Console.WriteLine($"\nComputer wins!");
                    cpu.handsWon++;
                    cpu.handsWon += draws;
                    draws = 0;
                }

                player1.currentHand.Clear();
                cpu.currentHand.Clear();

                Console.WriteLine($"Press any key to continue");
                Console.ReadKey();
            }

            Console.WriteLine($"\n\n\nPlayer = {player1.handsWon} wins\nComputer = {cpu.handsWon} wins");
        }
    }
}
