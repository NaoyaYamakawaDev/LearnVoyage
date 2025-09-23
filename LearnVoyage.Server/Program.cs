using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using LearnVoyage.Server.Data;
using Microsoft.Extensions.Options;
using LearnVoyage.Server.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// add custome Service class to DI container
builder.Services.AddScoped<UserService>();

// add db context to the container
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbcontext")));

// cross origin resouce sharingの設定　異なるプロジェクト同士が連携するための設定local hostのwasmのapi通信を許可する
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5172")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// corsの有効
app.UseCors();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapGet("/api/users", async (AppDbContext db) =>
{
    return await db.Users.ToListAsync();
});

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
