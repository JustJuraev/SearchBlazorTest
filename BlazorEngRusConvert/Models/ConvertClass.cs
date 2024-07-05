using System.Collections.ObjectModel;
using System.Text;

namespace BlazorEngRusConvert.Models
{
    public static class ConvertClass
    {
        public static readonly Dictionary<char, char> RussianToEnglish = new Dictionary<char, char>
{
    {'а', 'f'}, {'б', ','}, {'в', 'd'}, {'г', 'u'}, {'д', 'l'}, {'е', 't'}, {'ё', '`'},
    {'ж', ';'}, {'з', 'p'}, {'и', 'b'}, {'й', 'q'}, {'к', 'r'}, {'л', 'k'}, {'м', 'v'},
    {'н', 'y'}, {'о', 'j'}, {'п', 'g'}, {'р', 'h'}, {'с', 'c'}, {'т', 'n'}, {'у', 'e'},
    {'ф', 'a'}, {'х', '['}, {'ц', 'w'}, {'ч', 'x'}, {'ш', 'i'}, {'щ', 'o'}, {'ъ', ']'},
    {'ы', 's'}, {'ь', 'm'}, {'э', '\''}, {'ю', '.'}, {'я', 'z'}, {'А', 'F'}, {'Б', '<'},
    {'В', 'D'}, {'Г', 'U'}, {'Д', 'L'}, {'Е', 'T'}, {'Ё', '~'}, {'Ж', ':'}, {'З', 'P'},
    {'И', 'B'}, {'Й', 'Q'}, {'К', 'R'}, {'Л', 'K'}, {'М', 'V'}, {'Н', 'Y'}, {'О', 'J'},
    {'П', 'G'}, {'Р', 'H'}, {'С', 'C'}, {'Т', 'N'}, {'У', 'E'}, {'Ф', 'A'}, {'Х', '{'},
    {'Ц', 'W'}, {'Ч', 'X'}, {'Ш', 'I'}, {'Щ', 'O'}, {'Ъ', '}'}, {'Ы', 'S'}, {'Ь', 'M'},
    {'Э', '\"'}, {'Ю', '>'}, {'Я', 'Z'}
};

        public static readonly Dictionary<char, char> EnglishToRussian = RussianToEnglish.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

        public static string ConvertLayout(string input, Dictionary<char, char> layoutMap)
        {
            return new string(input.Select(c => layoutMap.ContainsKey(c) ? layoutMap[c] : c).ToArray());
        }

        // private static readonly Dictionary<char, string> RusToEng = new Dictionary<char, string>
        //{
        //    {'а', "a"}, {'б', "b"}, {'в', "v"}, {'г', "g"}, {'д', "d"}, {'е', "e"}, {'ё', "yo"},
        //    {'ж', "zh"}, {'з', "z"}, {'и', "i"}, {'й', "y"}, {'к', "k"}, {'л', "l"}, {'м', "m"},
        //    {'н', "n"}, {'о', "o"}, {'п', "p"}, {'р', "r"}, {'с', "s"}, {'т', "t"}, {'у', "u"},
        //    {'ф', "f"}, {'х', "kh"}, {'ц', "ts"}, {'ч', "ch"}, {'ш', "sh"}, {'щ', "shch"}, {'ъ', ""},
        //    {'ы', "y"}, {'ь', ""}, {'э', "e"}, {'ю', "yu"}, {'я', "ya"}
        //};

        //private static readonly Dictionary<string, char> EngToRus = RusToEng
        //    .OrderByDescending(x => x.Value.Length)
        //    .ToDictionary(x => x.Value, x => x.Key);

        public static List<string> FindWords(string input, List<string> words)
        {
            string convertedInputRus = ConvertLayout(input, EnglishToRussian);
            string convertedInputEng = ConvertLayout(input, RussianToEnglish);

            return words.Where(word =>
                word.Contains(input) ||
                word.Contains(convertedInputRus) ||
                word.Contains(convertedInputEng)).ToList();
        }
    }
}
