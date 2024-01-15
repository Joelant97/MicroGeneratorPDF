using Microsoft.EntityFrameworkCore;
using TemplateManagerAPI.Interfaces;
using TemplateManagerAPI.Models;
using TemplateManagerAPI.Services;

namespace TemplateManagerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ITemplateMGR, TemplateService>();

            //Add the DBContext for ASP.NET Core 6 
            builder.Services.AddDbContext<TemplatemgrContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDatabase")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}