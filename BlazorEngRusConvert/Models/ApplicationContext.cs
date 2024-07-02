using Microsoft.EntityFrameworkCore;

namespace BlazorEngRusConvert.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Word> Words { get; set; }
    }
}
