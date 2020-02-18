using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    //DbContext is a class from Entity Framework.
    //Need to let know this is available as a service, done in Startup.cs class
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Value> Values { get; set; }

        public DbSet<User> Users { get; set; }
    }
}