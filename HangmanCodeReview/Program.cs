using HangmanCodeReview.Interfaces;

namespace HangmanCodeReview
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IHangmanGame game = new HangmanGame();
            game.Play();
        }
    }
}
