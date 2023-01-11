using VDITest_MuhammadRidwan._1._Data.IRepository;
using VDITest_MuhammadRidwan._1._Data.Repository;
using VDITest_MuhammadRidwan._2._Services.IService;
using VDITest_MuhammadRidwan._2._Services.Service;

namespace VDITest_MuhammadRidwan
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Setup connection for database
            HelperClass.connectionString = builder.Configuration.GetConnectionString("connstring");

            //Registering Dependency Injection
            builder.Services.AddScoped<IMemberRepository, MemberRepository>();
            builder.Services.AddScoped<IMemberService, MemberService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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