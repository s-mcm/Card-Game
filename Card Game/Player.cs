using System;
using System.Collections.Generic;
using System.Text;

namespace Card_Game
{
    class Player
    {
        public List<Card> currentDeck = new List<Card>();
        public List<Card> currentHand = new List<Card>();
        public int handsWon = 0;
        protected Random rng = new Random();         

        public void ChooseCards()
        {
            // prints deck to player so they can see what they can choose
            PrintDeck(currentDeck);

            // allows player to choose 2 different cards
            Console.WriteLine($"\nPlease select the first card to use: ");
            int previousChoice = -1;
            int input1 = ValidateChoice(previousChoice);
            previousChoice = input1;
            Console.WriteLine($"Select a second card to use:");
            int input2 = ValidateChoice(previousChoice);

            // adds selected cards to current hand
            currentHand.Add(currentDeck[input1 - 1]);
            currentHand.Add(currentDeck[input2 - 1]);

            // removes first selected card
            currentDeck.RemoveAt(input1 - 1);

            // removes second selected card based upon the inputs. This ensures the correct selected card is removed!
            if (input1 >= input2)
            {
                currentDeck.RemoveAt(input2 - 1);
            }
            else
            {
                currentDeck.RemoveAt(input2 - 2);
            }
        }

        public void PrintDeck(List<Card> d)         // prints deck based on given list
        {
            Console.WriteLine($"\n\n\nCurrent deck: ");
            for (int i = 0; i < d.Count; i++)
            {
                Console.WriteLine($"Card {i + 1}: {d[i].name} of {d[i].suit}");
            }
        }

        private int ValidateChoice(int previousChoice)
        {
            int input = 0;

            // while loop used for error checking
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out input) && input >= 1 && input <= currentDeck.Count && input != previousChoice)        // returns true if the input was valid
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Error. Please enter a number between 1 and {currentDeck.Count} and don't enter your previous choice: ");
                }
            }

            return input;
        }
    }
}
