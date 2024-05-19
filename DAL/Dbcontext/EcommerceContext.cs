using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace DAL.Dbcontext
{
    public class EcommerceContext : IdentityDbContext<CustomUser>
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Cart>Carts => Set<Cart>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Order>Orders => Set<Order>();

        public EcommerceContext() { }
        public EcommerceContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //    List<Product> products = new List<Product>() {
            //    new Product(){Id=1,Name="p1",Description="desc1"},
            //    new Product(){Id=2,Name="p2",Description="desc2"},
            //    new Product(){Id=3,Name="p3",Description="desc3"},
            //    new Product(){Id=4,Name="p4",Description="desc4"},
            //    new Product(){Id=5,Name="p4",Description="desc5"},
            //    new Product(){Id=6,Name="p4",Description="desc6"},
            //    new Product(){Id=7,Name="p",Description="desc6"},
            //    new Product(){Id=8,Name="p",Description="desc6"},
            //    new Product(){Id=9,Name="p",Description="desc9"}



            //};

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EcommerceContext).Assembly);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductColor>(entity=>entity.HasKey(o =>new{ o.ProductId, o.Color }));
            modelBuilder.Entity<ProductImages>(entity => entity.HasKey(o => new { o.ProductId, o.ImageUrl }));
            //modelBuilder.Entity<Product>().HasData(products);
        }
    }
}
