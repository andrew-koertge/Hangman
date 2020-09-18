using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    
    public class ProgramUI
    {
        List<char> correctGuess = new List<char>();
        List<char> wrongGuess = new List<char>();
        public void Run()
        {
            Console.WriteLine("Welcome to hangman! \n" +
                              "Would you like to play a game? (y/n)");
            string selection = Console.ReadLine();
            if (selection == "y")
            {
                WordGenerator word = new WordGenerator();
                PlayGame(word.GetWord());
            } else
            {
                Console.WriteLine("Goodbye");
                Console.ReadLine();
            }
        }
        
        public void PlayGame(string selectedWordUpper)
        {
            StringBuilder displayToPlayer = new StringBuilder(selectedWordUpper.Length);
            
            for (int i = 0; i < selectedWordUpper.Length; i++)
            {
                displayToPlayer.Append('*');
            }

            int lives = 5;
            bool won = false;
            int lettersRevealed = 0;
            string input;
            char guess;

            while (!won && lives > 0)
            {
                //checks only first letter guessed
                Console.Write("Guess a letter: ");
                input = Console.ReadLine().ToUpper();
                guess = input[0];

                //determines if letter has been guessed before
                if (correctGuess.Contains(guess)) //if guessed letter is in the word
                {
                    Console.WriteLine("You've already tried '{0}', and it was correct!", guess);
                    //continue;
                }
                else if (wrongGuess.Contains(guess)) //if guessed letter is not in the word
                {
                    Console.WriteLine("You've already tried '{0}', and it was wrong!", guess);
                    //continue;
                }

                //determines if guessed letter is in the word
                if (selectedWordUpper.Contains(guess))
                {
                    correctGuess.Add(guess);

                    //cycles through the word to determine if it's there
                    for (int i = 0; i < selectedWordUpper.Length; i++)
                    {
                        if (selectedWordUpper[i] == guess)
                        {
                            //displays to the user if letter is correct
                            displayToPlayer[i] = selectedWordUpper[i];
                            lettersRevealed++;
                        }
                    }
                }
                else //if guess is wrong
                {
                    wrongGuess.Add(guess);
                    Console.WriteLine("Nope, there's no '{0}' in it!", guess);
                    lives--;
                    Console.WriteLine("Chances remaining: " + lives);
                }

                //displays current correctly guessed letters
                Console.WriteLine(displayToPlayer.ToString());

                //checks to see if you've guessed all correct letters and won
                if (lettersRevealed == selectedWordUpper.Length)
                {
                    won = true;
                }
            }
            if (won)
            {
                Console.WriteLine("You won!");
            }
            else
            {
                Console.WriteLine("You lost! It was '{0}'", selectedWordUpper);
                Console.WriteLine("Press ENTER to exit...");
                Console.ReadLine();
            }
           
        }
    }
}
