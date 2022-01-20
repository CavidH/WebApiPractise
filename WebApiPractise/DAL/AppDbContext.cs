using Microsoft.EntityFrameworkCore;
using WebApiPractise.Models;

namespace WebApiPractise.DAL
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)   
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
