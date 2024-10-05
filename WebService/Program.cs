using WebService.DataAccess.Context;
using WebService.Extensions;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

//------------------------[ Add services to the container ]-----------------------------
void ConfigureServices(IServiceCollection services)
{
    // Add services to the container.
    services.AddControllersWithViews().AddRazorRuntimeCompilation();
    services.AddDatabaseContext<ApplicationDbContext>(builder.Configuration.GetConnectionString("SQLServerConnection"));
    services.AddHelpers();
    services.AddRepositories();
    services.AddUnitOfWork();
    services.AddIdentity();
}
//--------------------------------------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "admin",
    areaName: "admin",
    pattern: "admin/{controller=dashboard}/{action=index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}"
);

app.UseHttpLog();

app.UseConcurrentRequest(2);

app.Run();