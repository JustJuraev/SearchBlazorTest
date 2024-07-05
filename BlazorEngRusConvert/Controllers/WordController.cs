using BlazorEngRusConvert.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEngRusConvert.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private ApplicationContext _context;

        public WordController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Words.Select(x => x.Text).ToList());
        }

        [HttpPost]
        public IActionResult GetWordsByInput([FromBody]string input)
        {
            List<string> words = new List<string>();
            if (input.Length >= 4)
            {
                words = ConvertClassResult.FindWords(input, _context.Words.Select(x => x.Text).ToList());
            }
            else
            {
                words = _context.Words.Where(x => x.Text.Contains(input)).Select(x => x.Text).ToList();
            }
          //  var result = ConvertClassResult.FindWords(input, _context.Words.Select(x => x.Text).ToList());
            return Ok(words);
        }

        //[HttpPost("generate")]
        //public IActionResult Generate()
        //{
            
        //    var list = GenerateRandomWords(50000);
        //    _context.Words.AddRange(list);
        //    _context.SaveChanges();
        //    return Ok("Yee bitch");
        //}

        //private List<Word> GenerateRandomWords(int count)
        //{
        //    Random random = new Random();
        //    const string chars = "фываапролджэюбьтимсчяйцукенгшщзхъ";
        //    List<Word> words = new List<Word>(count);

        //    for (int i = 0; i < count; i++)
        //    {
        //        int wordLength = random.Next(3, 11); // Случайная длина слова от 3 до 10 символов
        //        string word = new string(Enumerable.Repeat(chars, wordLength)
        //                                           .Select(s => s[random.Next(s.Length)]).ToArray());
        //        Word w = new Word
        //        {
        //            Text = word,
        //        };
        //        words.Add(w);
        //    }

        //    return words;
        //}
    }
}
