using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebService.Common.Helper.Implementation;
using WebService.Common.Helper.Interface;
using WebService.DataAccess.Context;
using WebService.DataAccess.Data.Identity;
using WebService.DataAccess.Repository.Implementation;
using WebService.DataAccess.Repository.Interface;
using WebService.DataAccess.UnitOfWork.Implementation;
using WebService.DataAccess.UnitOfWork.Interface;

namespace WebService.Extensions
{
    public static class ServiceExtension
    {
        //-----------------------------[ Inject DbContext ]-------------------------------------
        public static void AddDatabaseContext<TDbContext>(this IServiceCollection services, string? connectionstring) where TDbContext : DbContext
        {
            services.AddDbContext<TDbContext>(options =>
            {
                //---------------------------[ Database Connection ]------------------------------------
                options.UseSqlServer(connectionstring);
                //--------------------------------------------------------------------------------------
            });
        }
        //--------------------------------------------------------------------------------------

        //-----------------------------[ Inject Helper Here ]-----------------------------------
        public static void AddHelpers(this IServiceCollection services)
        {
            services.AddTransient<ICalendarHelper, CalendarHelper>();
            services.AddTransient<IConsoleHelper, ConsoleHelper>();
            services.AddTransient<IPaginationRedirectHelper, PaginationRedirectHelper>();
            services.AddTransient<IPaginationHelper, PaginationHelper>();
            services.AddTransient<IToastrHelper, ToastrHelper>();
        }
        //--------------------------------------------------------------------------------------

        //---------------------------[ Inject Repository Here ]---------------------------------
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
        }
        //--------------------------------------------------------------------------------------

        //--------------------------[ Inject Unit Of Work Here ]--------------------------------
        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        //--------------------------------------------------------------------------------------

        //-------------------------------[ Add Identity ]---------------------------------------
        public static void AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                //-----------------------------------------[ Password Setting ]------------------------------------------------
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                //-------------------------------------------------------------------------------------------------------------
                //------------------------------------------[ Lockout Setting ]------------------------------------------------
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                //-------------------------------------------------------------------------------------------------------------
                //-------------------------------------------[ User Setting ]--------------------------------------------------
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
                //-------------------------------------------------------------------------------------------------------------
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        }
        //--------------------------------------------------------------------------------------
    }
}
