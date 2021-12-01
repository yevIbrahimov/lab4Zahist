namespace Lab4
{
    class TextProcessing
    {
        private readonly string _firstText = "ivanFrankoMoisey.txt";
        private readonly string _secondText = "mykhayloKotsiubynskyyTini.txt";
        public void OneLetterFreq()
        {
            var firstText = new Analizer().AnalizeLetterFreq(_firstText);
            var secondText = new Analizer().AnalizeLetterFreq(_secondText);

            new WriteToLog().WriteTextToLog(firstText, "log1.txt");
            new WriteToLog().WriteTextToLog(secondText, "log1.txt");
        }

        public void BigrammFreq()
        {
            var firstText = new Analizer().AnalizeBigrammFreq(_firstText);
            var secondText = new Analizer().AnalizeBigrammFreq(_secondText);

            new WriteToLog().WriteTextToLog(firstText, "log2.txt");
            new WriteToLog().WriteTextToLog(secondText, "log2.txt");
        }

        public void TrigrammFreq()
        {
            var firstText = new Analizer().AnalizeTrigrammFreq(_firstText);
            var secondText = new Analizer().AnalizeTrigrammFreq(_secondText);

            new WriteToLog().WriteTextToLog(firstText, "log3.txt");
            new WriteToLog().WriteTextToLog(secondText, "log3.txt");
        }
    }
}
