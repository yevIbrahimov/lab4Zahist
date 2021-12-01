using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab4
{
    class WriteToLog
    {
        internal void WriteTextToLog(Dictionary<char, double> text, string logName)
        {
            using (StreamWriter sw = new StreamWriter(@"D:\lab4\" + logName, true, Encoding.Default))
            {
                foreach (var item in text.Keys)
                {
                    sw.WriteLine(item == ' ' ? "пробіл" : item.ToString());
                }

                foreach (var item in text.Values)
                {
                    sw.WriteLine(item);
                }

                sw.WriteLine(new string('=', 50));
            }
        }

        internal void WriteTextToLog(Dictionary<string, double> text, string logName)
        {
            using (StreamWriter sw = new StreamWriter(@"D:\lab4\" + logName, true, Encoding.Default))
            {
                foreach (var item in text.Keys)
                {
                    sw.WriteLine(item);
                }

                foreach (var item in text.Values)
                {
                    sw.WriteLine(item);
                }

                sw.WriteLine(new string('=', 50));
            }
        }
    }
}
