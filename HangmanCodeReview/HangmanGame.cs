using HangmanCodeReview.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanCodeReview
{
    class HangmanGame : IHangmanGame
    {
        private GameStatus gameStatus;
        private WordGenerator wordGenerator;

        public HangmanGame()
        {
            wordGenerator = new WordGenerator();
            string wordToGuess = wordGenerator.GetRandomWord();
            gameStatus = new GameStatus(wordToGuess);
        }

        public void Play()
        {
            Console.WriteLine("Välkommen till Hänga gubbe!");
            Console.WriteLine("Du har totalt 6 liv. Gissa bokstäver för att hitta rätt ord.");

            while (gameStatus.Lives > 0 && !gameStatus.IsWordGuessed())
            {
                DisplayGameStatus();
                char guess = GetGuess();

                if (gameStatus.GuessedLetters.Contains(guess))
                {
                    Console.WriteLine("Du har redan gissat den bokstaven. Försök igen.");
                    continue;
                }

                gameStatus.GuessedLetters.Add(guess);
                ProcessGuess(guess);
            }

            DisplayResult();
        }

        private void DisplayGameStatus()
        {
            Console.WriteLine("\nOrdet: " + new string(gameStatus.GuessedWord));
            Console.WriteLine("Gissade bokstäver: " + string.Join(", ", gameStatus.GuessedLetters));
            Console.WriteLine($"Liv kvar: {gameStatus.Lives}");
        }

        private char GetGuess()
        {
            Console.Write("Gissa en bokstav: ");
            return Console.ReadLine().ToLower()[0];
        }

        private void ProcessGuess(char guess)
        {
            if (gameStatus.IsGuessCorrect(guess))
            {
                gameStatus.UpdateGuessedWord(guess);
                Console.WriteLine("Rätt gissat!");
            }
            else
            {
                gameStatus.DecreaseLife();
                Console.WriteLine("Fel gissat! Du förlorade ett liv.");
            }
        }

        private void DisplayResult()
        {
            if (gameStatus.IsWordGuessed())
            {
                Console.WriteLine($"\nGrattis! Du gissade ordet: {gameStatus.WordToGuess}");
            }
            else
            {
                Console.WriteLine($"\nTyvärr, du har inga liv kvar. Ordet var: {gameStatus.WordToGuess}");
            }
        }
    }
}
