using System;
using System.Collections.Generic;
using System.Text;

namespace Card_Game
{
    class Computer : Player
    {
        public void ChooseCard()
        {
            int r = rng.Next(0, currentDeck.Count);
            currentHand.Add(currentDeck[r]);
            currentDeck.RemoveAt(r);
        }
    }
}
