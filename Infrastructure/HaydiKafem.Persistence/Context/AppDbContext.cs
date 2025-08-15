using HaydiKafem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HaydiKafem.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Food> Foods { get; set; }
        public DbSet<HotDrink> HotDrinks { get; set; }
        public DbSet<ColdDrink> ColdDrinks { get; set; }
        public DbSet<IceCream> IceCreams { get; set; }
        public DbSet<Desert> Deserts { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<WeekDiscount> WeekDiscounts { get; set; }
    }
}
