using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class WordGenerator
    {
        public string NewWord { get; set; }
        public WordGenerator() {  }

        public WordGenerator(string newWord)
        {
            newWord = NewWord;
        }

        public string GetWord()
        {
            Random randomWord = new Random();
            string[] newWord = { "Generic", "Quiz", "Lemon", "Wonderful", "Purple", "Monkey", "Dishwasher" };
            string selectedWord = newWord[randomWord.Next(0, newWord.Length)];
            string selectedWordUpper = selectedWord.ToUpper();
            return selectedWordUpper;
        }
    }
}
