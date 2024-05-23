using DAL.Dbcontext;
using DAL.Repositories.Categories;
using DAL.Repositories.Products;
using DAL.Repositories.ShppingCart;
using DAL.Repositories.UserRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public static class ServicesExtension
    {
        public static void AddDALServices(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("EcommerceDB");
            services.AddDbContext<EcommerceContext>(Options=>Options.UseSqlServer(connectionString));
            services.AddScoped<IUserRepo,UserRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<ICartRepo,CartRepo>();
        }
    }
}
