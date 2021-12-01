using System.Collections.Generic;
using System.Linq;

namespace Lab4
{
    class Analizer
    {
        internal Dictionary<char, double> AnalizeLetterFreq(string fileName)
        {
            var text = new Reader().GetText(fileName);
            var letterFreq = new Dictionary<char, double>();

            foreach (var letter in text)
            {
                if (letterFreq.ContainsKey(letter) == false)
                {
                    letterFreq.Add(letter, text.Count(t => t == letter)/(double)text.Length);
                }
            }

            return letterFreq.OrderBy(i => i.Key)
                .ToDictionary(k => k.Key, v => v.Value); ;
        }

        internal Dictionary<string, double> AnalizeBigrammFreq(string fileName)
        {
            var bigramms = new List<string>();
            var bigrammsWithCount = new Dictionary<string, double>();
            var bigrammsFreq = new Dictionary<string, double>();
            double allFreqSum = 0;


            var text = new Reader().GetText(fileName);

            for (int i = 0; i < text.Length - 2; i++)
            {
                if (text[i] != ' ' && text[i+1] != ' ')
                {
                    bigramms.Add(text[i].ToString() + text[i+1]);
                }
            }

            foreach (var bigramm in bigramms)
            {
                if (bigrammsWithCount.ContainsKey(bigramm) == false)
                {
                    bigrammsWithCount.Add(bigramm, bigramms.Count(b => b == bigramm));
                    allFreqSum += bigramms.Count(b => b == bigramm);
                }
            }

            for (int i = 0; i < bigrammsWithCount.Count; i++)
            {
                bigrammsFreq.Add(bigrammsWithCount.Keys.ToList()[i], bigrammsWithCount.Values.ToList()[i]/allFreqSum);
            }

            return bigrammsFreq.OrderBy(i => i.Key)
                .ToDictionary(k => k.Key, v => v.Value); 
        }

        internal Dictionary<string, double> AnalizeTrigrammFreq(string fileName)
        {
            var trigramms = new List<string>();
            var trigrammsWithCount = new Dictionary<string, double>();
            var trigrammsFreq = new Dictionary<string, double>();
            double allFreqSum = 0;


            var text = new Reader().GetText(fileName);

            for (int i = 0; i < text.Length - 3; i++)
            {
                if (text[i] != ' ' && text[i + 1] != ' ' && text[i + 2] != ' ')
                {
                    trigramms.Add(text[i].ToString() + text[i + 1] + text[i + 2]);
                }
            }

            foreach (var trigramm in trigramms)
            {
                if (trigrammsWithCount.ContainsKey(trigramm) == false)
                {
                    trigrammsWithCount.Add(trigramm, trigramms.Count(b => b == trigramm));
                    allFreqSum += trigramms.Count(b => b == trigramm);
                }
            }

            for (int i = 0; i < trigrammsWithCount.Count; i++)
            {
                trigrammsFreq.Add(trigrammsWithCount.Keys.ToList()[i], trigrammsWithCount.Values.ToList()[i] / allFreqSum);
            }

            return trigrammsFreq.OrderByDescending(i => i.Value)
                .ToDictionary(k => k.Key, v => v.Value);
        }
    }
}
