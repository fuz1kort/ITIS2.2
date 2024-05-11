using System.Net;
using LiveStreamingServerNet;
using LiveStreamingServerNet.Flv.Installer;
using LiveStreamingServerNet.Networking.Helpers;
using Microsoft.EntityFrameworkCore;
using TeamHost;
using TeamHost.Context;
using TeamHost.Interfaces;
using TeamHost.Services;

var builder = WebApplication.CreateBuilder(args);

await using var liveStreamingServer = LiveStreamingServerBuilder.Create()
    .ConfigureRtmpServer(options => options.AddFlv())
    .ConfigureLogging(options => options.AddConsole())
    .Build();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddBackgroundServer(liveStreamingServer, new IPEndPoint(IPAddress.Any, 1935));
builder.Services.AddDbContext<EfContext>(opt =>
        opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<EfContext>();
builder.Services.AddScoped<IDbContext, EfContext>();
builder.Services.AddTransient<Migrator>();
builder.Services.AddScoped<IDbSeeder, DbSeeder>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserContext, UserContext>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Profile/Login";
});

var app = builder.Build();

using var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IDbSeeder>();
var migrator = scope.ServiceProvider.GetRequiredService<Migrator>();
await seeder.SeedAsync(new CancellationToken());
await migrator.MigrateAsync();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseWebSockets();
app.UseWebSocketFlv(liveStreamingServer);

app.UseHttpFlv(liveStreamingServer);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area=Home}/{controller=Home}/{action=Index}/{id?}");

app.Run();