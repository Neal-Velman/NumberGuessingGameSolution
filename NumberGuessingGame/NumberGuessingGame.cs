using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace NumberGuessingGame
{
    /*
    * -------------------------------------------------------------------------------------
    * NOTE FOR THE GRADER
    * The secret number (answer) being printed to the console at the
    * beginning is for debug and demonstration purposes only
    * It will be removed for the final submission of this assignment
    * -------------------------------------------------------------------------------------
    */
    internal class NumberGuessingGame
    {
        public static void Run()
        {
            bool isInvalid = true;
            int guesses;
            int randNum;
            int difficultyMax;
            List<int> guessVector = [];
            do
            {
                int difficulty = MenuSelect();
                if (difficulty == 1)
                {
                    randNum = ChooseRandomNumber(1, 11);
                    difficultyMax = 10;
                } 
                else if (difficulty == 2)
                {
                    randNum = ChooseRandomNumber(1, 51);
                    difficultyMax = 50;
                }
                else
                {
                    randNum = ChooseRandomNumber(1, 101);
                    difficultyMax = 100;
                }
                Console.WriteLine($"The secret number is {randNum}\n");
                guessVector.Clear();
                for (guesses = 5; guesses > 0; guesses--)
                {
                    bool guessAgain = false;
                    int guess;
                    do
                    {
                        guess = CSC160_ConsoleMenu.CIO.PromptForInt($"\nGuess a number between 1 and {difficultyMax}\n", 1, difficultyMax);
                        for (int i = 0; i < guessVector.Count(); i++)
                        {
                            if (guess == guessVector.ElementAt(i))
                            {
                                guessAgain = true;
                                Console.WriteLine($"You've already guessed {guess}. Please try again.\n");
                                break;
                            } else
                            {
                                guessAgain = false;
                            }
                        }
                    } while (guessAgain);
                    
                    guessVector.Add(guess);

                    if (guess == randNum)
                    {
                        Console.WriteLine($"You guessed the correct number! It was: {randNum}! It took you {5 - (guesses-1)} guesses!\n");
                        break;
                    } 
                    else if (guess > randNum)
                    {
                        Console.WriteLine("Your guess was too high! Try again.\n");
                    } 
                    else if (guess < randNum)
                    {
                        Console.WriteLine("Your guess was too low! Try again.\n");
                    } 
                    Console.WriteLine($"You have {guesses-1} remaining guesses.\n");
                    if (guesses - 1 == 0)
                    {
                        Console.WriteLine("You ran out of guesses and didn't get the number! Better luck next time.");
                    }
                }
                isInvalid = PromptForPlayAgain();

            } while (isInvalid);
            Console.WriteLine("\nThank you for playing my game! Have a good day!");
        }
        

        private static int MenuSelect()
        {
            string[] options = { "Easy, 1-10, 5 Attempts", "Medium, 1-50, 5 Attempts", "Hard, 1-100, 5 Attempts" };
            return CSC160_ConsoleMenu.CIO.PromptForMenuSelection(options, true);
        }

        private static int ChooseRandomNumber(int min, int max)
        {
            var chooseNum = new Random();
            return chooseNum.Next(min, max);
        }

        private static bool PromptForPlayAgain()
        {
            return CSC160_ConsoleMenu.CIO.PromptForBool("Would you like to play again? (Yes/No)\n", "yes", "no");
        }
    }
}
