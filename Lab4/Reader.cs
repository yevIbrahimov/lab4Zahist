using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab4
{
    class Reader
    {
        internal string GetText(string fileName)
        {
            string path = @"D:\lab4\" + fileName;
            var allText = File.ReadAllText(path, Encoding.Default).ToLower();
            var textWithNoPunctuation = new string(allText.Where(c => !char.IsPunctuation(c)).ToArray());
            textWithNoPunctuation = Regex.Replace(textWithNoPunctuation, @"[ \r\n\t]", " ");
            textWithNoPunctuation = Regex.Replace(textWithNoPunctuation, @"[0-9]", "");
            textWithNoPunctuation = Regex.Replace(textWithNoPunctuation, @"[a-z]", "");

            return textWithNoPunctuation;
        }
    }
}
