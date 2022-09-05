using Microsoft.EntityFrameworkCore;
using Module_21_MVC.Dal;
using Module_21_MVC.Dal.Interfaces;
using Module_21_MVC.Dal.Repositories;
using Module_21_MVC.Service.Implementations;
using Module_21_MVC.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));
builder.Services.AddScoped<IWorkerService, WorkerService>();
builder.Services.AddControllersWithViews();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Worker}/{action=GetWorkers}/{id?}");

app.Run();

