using MVC_App.Abstract;
using MVC_App.Concrete;
using MVC_App.Data;

DollarValues.GetLastDollarValues();
AppDatabase.InitializeDatabase();
AppDatabase.UpdateAmounts();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IOperationManager, OperationManager>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();