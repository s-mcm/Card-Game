using System;
using System.Collections.Generic;
using System.Text;

namespace Card_Game
{
    class Deck
    {
        public List<Card> deck = new List<Card>();
        private string currentSuit = "Clubs";
        private Random rng = new Random();

        public void BuildDeck()
        {
            for (int i = 1; i <= 4; i++)        // run 4 times for each suit
            {
                currentSuit = i switch          // changes value of currentSuit based on iteration
                {
                    1 => "Clubs",
                    2 => "Spades",
                    3 => "Hearts",
                    4 => "Diamonds",
                    _ => "Null",
                };

                // runs 14 times for each type of card. Adds cards to deck list. Each card has appropriate name, suit and value
                for (int j = 2; j <= 14; j++)
                {
                    Card temp = new Card();

                    if (j < 11)     // checks value of card to allow for appropriate names to be given
                    {
                        temp.name = j.ToString();
                    }
                    else
                    {
                        temp.name = j switch
                        {
                            11 => "Jack",
                            12 => "Queen",
                            13 => "King",
                            14 => "Ace",
                            _ => "Null",
                        };
                    }

                    temp.suit = currentSuit;
                    temp.value = j;

                    deck.Add(temp);
                }
            }
        }

        public void ShuffleDeck()       // shuffles deck based on Fisher-Yates shuffle
        {
            List<Card> temp = new List<Card>();
            int n = deck.Count;

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                temp.Add(deck[k]);
                deck[k] = deck[n];
                deck[n] = temp[0];
                temp.Clear();
            }
        }

        public Card DealCard()      // deals card to player by returning the card value, then removes delt card from deck
        {
            Card c = new Card();
            int r = rng.Next(0, deck.Count);
            c = deck[r];
            deck.RemoveAt(r);
            return c;
        }
    }
}
