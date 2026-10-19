using System;
using System.Collections.Generic;
using System.Text;

namespace NumberGuessingGame
{
    internal class NumberGuessingGame
    {
        public static void Run()
        {
            bool isInvalid = true;
            do
            {
                int difficulty = MenuSelect();
                int randNum;
                if (difficulty == 1)
                {
                    randNum = ChooseRandomNumber(1, 11);
                } 
                else if (difficulty == 2)
                {
                    randNum = ChooseRandomNumber(1, 51);
                }
                else
                {
                    randNum = ChooseRandomNumber(1, 101);
                }
                
                isInvalid = PromptForPlayAgain();

            } while (isInvalid);
        }

        private static int MenuSelect()
        {
            string[] options = { "Easy, 1-10, 5 Attempts", "Medium, 1-50, 5 Attempts", "Hard, 1-100, 5 Attempts" };
            int choice = CSC160_ConsoleMenu.CIO.PromptForMenuSelection(options, true);
            if (choice == 1)
            {
                return 1;
            } 
            else if (choice == 2)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        private static int ChooseRandomNumber(int min, int max)
        {
            var chooseNum = new Random();
            return chooseNum.Next(min, max);
        }

        private static bool PromptForPlayAgain()
        {
            return CSC160_ConsoleMenu.CIO.PromptForBool("Would you like to play again? (Yes/No", "yes", "no");
        }
        
    }
}
