using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanCodeReview
{
    class GameStatus
    {
        public string WordToGuess { get; private set; }
        public char[] GuessedWord { get; private set; }
        public int Lives { get; private set; }
        public List<char> GuessedLetters { get; private set; }

        public GameStatus(string wordToGuess)
        {
            WordToGuess = wordToGuess;
            GuessedWord = new string('_', wordToGuess.Length).ToCharArray();
            Lives = 6;
            GuessedLetters = new List<char>();
        }

        public void UpdateGuessedWord(char guess)
        {
            for (int i = 0; i < WordToGuess.Length; i++)
            {
                if (WordToGuess[i] == guess)
                {
                    GuessedWord[i] = guess;
                }
            }
        }

        public void DecreaseLife()
        {
            Lives--;
        }

        public bool IsGuessCorrect(char guess)
        {
            return WordToGuess.Contains(guess);
        }

        public bool IsWordGuessed()
        {
            return new string(GuessedWord) == WordToGuess;
        }
    }
}
