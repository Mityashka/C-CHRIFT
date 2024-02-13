class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.txt";
        string outputPath = "output.txt";

        try
        {
            string text = File.ReadAllText(inputPath);

            string[] words = text.Split(new char[] { ' ', '\n', '\r', '.', ',', ':', ';', '!', '?', '-', '"', '\'' },
                                                     StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            foreach (string word in words)
            {
                string cleanedWord = word.ToLower();
                if (wordCounts.ContainsKey(cleanedWord))
                {
                    wordCounts[cleanedWord]++;
                }
                else
                {
                    wordCounts[cleanedWord] = 1;
                }
            }

            var sortedWordCounts = wordCounts.OrderByDescending(pair => pair.Value);

            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                foreach (var pair in sortedWordCounts)
                {
                    writer.WriteLine($"{pair.Key}: {pair.Value}");
                }
            }

            Console.WriteLine("Идет подсчет слов..");
        }
        catch (Exception)
        {
            Console.WriteLine("ошибка");
        }
    }
}
