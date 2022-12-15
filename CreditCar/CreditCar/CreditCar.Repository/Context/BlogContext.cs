using CreditCar.Entity.Models;
using Microsoft.EntityFrameworkCore;



namespace CreditCar.Repository.Context
{
    public partial class BlogContext : DbContext
    {
        public BlogContext()
        {
        }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }

        public virtual DbSet<Post> Post { get; set; } = null!;

       
    }
}
