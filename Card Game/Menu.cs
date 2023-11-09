using System;
using System.Collections.Generic;
using System.Text;

namespace Card_Game
{
    class Menu
    {
        public void CallMenu()
        {
            int low = 1;
            int high = 3;
            int userInput = 0;
            bool continueLoop = true;

            while (continueLoop)
            {
                Console.WriteLine($"Welcome to lincoln card game. Would you like to do PvP or PvC?" +
                    $"\n1 = Player Vs Player" +
                    $"\n2 = Player Vs Computer" +
                    $"\n3 = Exit program" +
                    $"\nEnter between {low} and {high - 1}, or press {high} to exit:");
                userInput = ValidateInput(low, high);

                switch (userInput)
                {
                    case 1:
                        GameLogic.StartGame(0);     // 0 = PvP
                        break;
                    case 2:
                        GameLogic.StartGame(1);     // 1 = PvC
                        break;
                    case 3:
                        continueLoop = false;
                        break;
                    default:
                        break;
                }


                Console.WriteLine($"\n\n\nPress any key to contuine");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private int ValidateInput(int lowestOption, int highestOption)
        {
            int input = 0;

            // while loop used for error checking
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out input) && input >= lowestOption && input <= highestOption)        // returns true if the input was valid
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Error. Please enter a number between {lowestOption} and {highestOption}: ");
                }
            }

            return input;
        }
    }
}
