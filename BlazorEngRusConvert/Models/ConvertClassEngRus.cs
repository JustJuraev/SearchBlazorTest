using System.Text;

namespace BlazorEngRusConvert.Models
{
    public static class ConvertClassEngRus
    {
        private static readonly Dictionary<string, string> RusToEng = new Dictionary<string, string>
{
    {"а", "a"}, {"б", "b"}, {"в", "v"}, {"г", "g"}, {"д", "d"}, {"е", "ye"}, {"ё", "yo"},
    {"ж", "zh"}, {"з", "z"}, {"и", "i"}, {"й", "y"}, {"к", "k"}, {"л", "l"}, {"м", "m"},
    {"н", "n"}, {"о", "o"}, {"п", "p"}, {"р", "r"}, {"с", "s"}, {"т", "t"}, {"у", "u"},
    {"ф", "f"}, {"х", "x"}, {"ц", "ts"}, {"ч", "ch"}, {"ш", "sh"}, {"щ", "shch"},
    {"э", "e"}, {"ю", "yu"}, {"я", "ya"}, {"ы", "si"}, {"цы", "tsi"}
};

        private static readonly Dictionary<string, string> EngToRus = RusToEng
            .OrderByDescending(x => x.Value.Length)
            .ToDictionary(x => x.Value, x => x.Key);

        private static readonly Dictionary<string, string> RusToEng2 = new Dictionary<string, string>
{
    {"а", "a"}, {"б", "b"}, {"в", "v"}, {"г", "g"}, {"д", "d"}, {"е", "ye"}, {"ё", "yo"},
    {"ж", "zh"}, {"з", "z"}, {"и", "i"}, {"й", "y"}, {"к", "k"}, {"л", "l"}, {"м", "m"},
    {"н", "n"}, {"о", "o"}, {"п", "p"}, {"р", "r"}, {"с", "s"}, {"т", "t"}, {"у", "u"},
    {"ф", "f"}, {"х", "h"}, {"ч", "ch"}, {"ш", "sh"}, 
    {"э", "e"}, {"ю", "yu"}, {"я", "ya"}, {"ци", "tsi"}
};

        private static readonly Dictionary<string, string> EngToRus2 = RusToEng2
            .OrderByDescending(x => x.Value.Length)
            .ToDictionary(x => x.Value, x => x.Key);

        private static string ConvertRusToEng(string input, Dictionary<string, string> layoutMap)
        {
            StringBuilder result = new StringBuilder();

            foreach (char c in input)
            {
                if (layoutMap.ContainsKey(c.ToString()))
                {
                    result.Append(layoutMap[c.ToString()]);
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        static string TransliterateToRus(string input, Dictionary<string, string> dictionary)
        {
            StringBuilder result = new StringBuilder();

            int i = 0;
            while (i < input.Length)
            {
                bool matchFound = false;

                foreach (var kvp in dictionary)
                {
                    if (input.Substring(i).StartsWith(kvp.Key))
                    {
                        result.Append(kvp.Value);
                        i += kvp.Key.Length;
                        matchFound = true;
                        break;
                    }
                }

                if (!matchFound)
                {
                    result.Append(input[i]);
                    i++;
                }
            }

            return result.ToString();
        }


        public static List<string> FindWords(string input, List<string> words)
        {
            string convertedInputRus = TransliterateToRus(input, EngToRus);
            string convertedInputEng = ConvertRusToEng(input, RusToEng);
            string convertedInputRus2 = TransliterateToRus(input, EngToRus2);
            string convertedInputEng2 = ConvertRusToEng(input, RusToEng2);

            return words.Where(word =>
                word.Contains(input) ||
                word.Contains(convertedInputRus) ||
                word.Contains(convertedInputEng) || word.Contains(convertedInputRus2) || word.Contains(convertedInputEng2)).ToList();
        }
    }
}
