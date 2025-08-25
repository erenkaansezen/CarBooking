using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web.Domain.Entities;

namespace Web.Persistence.Context
{
    public class WebContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Sezen;initial Catalog=WebSezenCoRentACar;integrated Security=true;TrustServerCertificate=True");
        }
        public DbSet<About> abouts { get; set; }
        public DbSet<Banner> banners { get; set; }
        public DbSet<Brand> brands { get; set; }
        public DbSet<Car> cars { get; set; }
        public DbSet<CarDescription> carDescriptions { get; set; }
        public DbSet<CarFeature> carFeatures { get; set; }
        public DbSet<CarPricing> carPricings { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Feature> features { get; set; }
        public DbSet<FooterAddress> footerAddresses { get; set; }
        public DbSet<Location> locations { get; set; }
        public DbSet<Pricing> pricings { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<SocialMedia> socialMedias { get; set; }
        public DbSet<Testimonial> testimonials { get; set; }
    }
}
