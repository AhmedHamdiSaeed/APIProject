
using BL.Services;
using DAL.Dbcontext;
using DAL.Entities;
using DAL.Repositories.UserRepo;
using DAL.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.Physical;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace ApiProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDALServices(builder.Configuration);
            builder.Services.AddBLService();
            builder.Services.AddIdentityCore<CustomUser>(options => 
            { 
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<EcommerceContext>();
            builder.Services.AddAuthentication(Options =>
            {
                Options.DefaultAuthenticateScheme="mySchema";
                Options.DefaultChallengeScheme = "mySchema";
            }
                ).AddJwtBearer("mySchema", options =>
                {
                    var key = builder.Configuration.GetValue<string>("sekretKey");
                    var keyInBytes = Encoding.ASCII.GetBytes(key!);
                    var securityKey = new SymmetricSecurityKey(keyInBytes);
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = securityKey
                    };
                });

            builder.Services.AddAuthorization(options => {
                options.AddPolicy("admin",p=>p.RequireClaim(ClaimTypes.Role,"admin"));
            });
            //builder.Services.AddBLServices();
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("p1", builder =>
                {
                    builder.AllowAnyHeader().AllowAnyOrigin().AllowCredentials().AllowAnyMethod();
                }
                    );
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles(
                       new StaticFileOptions
                       {
                           FileProvider = new PhysicalFileProvider(Path.Combine(Environment.CurrentDirectory, "Images")),
                           RequestPath = "/Images"
                       }
                );


            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
