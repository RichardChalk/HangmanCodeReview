using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanCodeReview
{
    class WordGenerator
    {
        private readonly string[] words = { "programmering", "utveckling", "lärande", "teknik", "dator" };
        private Random random = new Random();

        public string GetRandomWord()
        {
            return words[random.Next(words.Length)];
        }
    }

}
