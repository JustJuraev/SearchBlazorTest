namespace BlazorEngRusConvert.Models
{
    public class ConvertClassResult
    {
        public static List<string> FindWords(string input, List<string> words)
        {
            var list = ConvertClass.FindWords(input, words);
            var listengrus = ConvertClassEngRus.FindWords(input, words);
            foreach(var word in listengrus) 
                if(!list.Contains(word))
                    list.Add(word);

            return list;
        }
    }
}
