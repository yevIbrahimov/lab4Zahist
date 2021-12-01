using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab4
{
    class AphinShifr
    {
        private readonly int _a = 5, _b = 11;
        private readonly List<char> _alphabet = new List<char>(){
            'а', 'б', 'в', 'г', 'ґ', 'д', 'е',
            'є', 'ж', 'з', 'и', 'і', 'ї', 'й', 'к',
            'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т',
            'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь',
            'ю', 'я'
        };

        public string Coder(string text)
        {
            string codedChars = "";
            var textWithNoPunctuation = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            textWithNoPunctuation = Regex.Replace(textWithNoPunctuation, @"[ \r\n\t]", "");
            textWithNoPunctuation = Regex.Replace(textWithNoPunctuation, @"[0-9]", "");
            textWithNoPunctuation = Regex.Replace(textWithNoPunctuation, @"[a-z]", "");
            textWithNoPunctuation = textWithNoPunctuation.ToLower();

            foreach (var letter in textWithNoPunctuation)
            {
                char codedLetter = _alphabet[(_alphabet.IndexOf(letter) * _a + _b) % _alphabet.Count];
                codedChars += codedLetter.ToString();
            }

            var w = codedChars;
            return codedChars.ToString();
        }

        public string Decoder(string codedText)
        {
            string decodedChars = "";

            foreach (var letter in codedText)
            {
                char decodedLetter = _alphabet[(_alphabet.IndexOf(letter) - _b) * InvertionNumber(_a) % _alphabet.Count];
                decodedChars += decodedLetter.ToString();
            }

            return decodedChars;
        }

        private int InvertionNumber(int a)
        {
            var pairs = new Dictionary<int, int>();
            for (int i = 0; i < _alphabet.Count; i++)
            {
                for (int j = 0; j < _alphabet.Count; j++)
                {
                    if (i * j % _alphabet.Count == 1)
                    {
                        pairs.Add(i, j);
                    }
                }
            }

            return pairs.FirstOrDefault(x => x.Key == a).Value;
        }
    }
}
