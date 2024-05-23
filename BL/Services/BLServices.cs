using BL.Managers.Categories;
using BL.Managers.Products;
using BL.Managers.ShoppingCarts;
using BL.Managers.Users;
using DAL.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public static class BLServices
    {
        public static void AddBLService(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<IUserManager,UserManager>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<ICategoryManager,CategoryManager>();
            services.AddScoped<ICartManager, CartManager>();
        }
    }
}
