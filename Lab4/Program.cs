namespace Lab4
{
    class Program
    {
        private static readonly TextProcessing TextProcessing = new TextProcessing();
        static void Main()
        {
            TextProcessing.OneLetterFreq();
            TextProcessing.BigrammFreq();
            TextProcessing.TrigrammFreq();
        }
    }
}
