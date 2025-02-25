using BLL.Services.MainPage;
using DAL;
using DAL.Repositories.Languages;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using DAL.Repositories.Users;
using BLL.Services.Users.Auth;
using BLL.Services.Users.JWT;
using BLL.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = new ConfigurationBuilder()
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("AspNetCore_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
    .Build();

builder.Services.AddDbContextFactory<AppDbContext>(options =>
{
    string connectionString = configuration.GetConnectionString("LocalConnection") ?? String.Empty;

    options.UseSqlServer(connectionString);
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddScoped<IMainPageService, MainPageService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.MapControllers();

app.Run();
