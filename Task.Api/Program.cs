
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Task.Core;
using Task.Infrastructure.Contracts;
using Task.Infrastructure.Repos;
using Task.Service.ProductService;
using Task.Service.ProductService.Dto;

namespace Task.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            //builder.Services.AddTransient<IFileService, FileService>();
            builder.Services.AddAutoMapper(typeof(ProductProfile));
            builder.Services.AddScoped<IProductService, ProductService>();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
