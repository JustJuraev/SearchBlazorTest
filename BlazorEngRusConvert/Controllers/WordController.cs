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
            var result = ConvertClass.FindWords(input, _context.Words.Select(x => x.Text).ToList());
            return Ok(result);
        }

       
    }
}
