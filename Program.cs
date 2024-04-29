using IntelliStocks.Persistence;
using Microsoft.EntityFrameworkCore;

namespace _2TDSPK
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container(caixa) de inje��o de dependencia
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<OracleDbContext>(
                options =>
                {
                    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection"));
                }
            );

            //builder.Services.AddSingleton - o garcom pega dentro da caixa e entrega direto para o Arhut
            //builder.Services.AddScoped - o gracom pega na caixa assa novamente e entrega
            //builder.Services.AddTransient - o churrasqueiro coloca a carne na churrasqueira

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}