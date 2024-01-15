using Microsoft.EntityFrameworkCore;
using myProjectMVC.Models;

namespace myProjectMVC.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<City> Cities { get; set; }
    }
   

}
