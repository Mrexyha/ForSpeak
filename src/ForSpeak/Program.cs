using BLL.Services.Languages;
using DAL;
using DAL.Repositories.Languages;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using DAL.Repositories.Users;
using BLL.Services.Users.Auth;
using BLL.Services.Users.JWT;
using BLL.Mapping;
using Microsoft.Extensions.Configuration;
using BLL.Services.Lessons;
using DAL.Repositories.Lessons;
using BLL.Services.Users.User;
using BLL.Services.Tasks.Theory;
using DAL.Repositories.Tasks.Theory;
using BLL.Services.Tasks.Vocabulary;
using DAL.Repositories.Tasks.Vocabulary;
using DAL.Repositories.Tasks.Quiz;
using BLL.Services.Tasks.Quiz;
using DAL.Repositories.Tasks.Reading;
using BLL.Services.Tasks.Reading;
using DAL.Repositories.Tasks.Speaking;
using BLL.Services.Tasks.Speaking;
using BLL.Services.Progress;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using DAL.Repositories.Modules;
using BLL.Services.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile(
       $"appsettings.{builder.Environment.EnvironmentName}.json",
       optional: true, reloadOnChange: true
    );

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection")));

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = true;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                                          Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "¬вед≥ть `Bearer {тут ваш токен}`"
    });
    c.AddSecurityRequirement(new()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddScoped<ILanguageService, LanguageService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.AddScoped<ILessonRepository, LessonRepository>();
builder.Services.AddScoped<ILessonsService, LessonsService>();

builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
builder.Services.AddScoped<IModuleService, ModuleService>();

builder.Services.AddScoped<ITheoryModuleService, TheoryModuleService>();
builder.Services.AddScoped<ITheoryModuleRepository, TheoryModuleRepository>();

builder.Services.AddScoped<IVocabularyModuleRepository, VocabularyModuleRepository>();
builder.Services.AddScoped<IVocabularyModuleService, VocabularyModuleService>();

builder.Services.AddScoped<IQuizModuleRepository, QuizModuleRepository>();
builder.Services.AddScoped<IQuizModuleService, QuizModuleService>();

builder.Services.AddScoped<IReadingModuleRepository, ReadingModuleRepository>();
builder.Services.AddScoped<IReadingModuleService, ReadingModuleService>();

builder.Services.AddScoped<ISpeakingModuleRepository, SpeakingModuleRepository>();
builder.Services.AddScoped<ISpeakingModuleService, SpeakingModuleService>();

builder.Services.AddScoped<IUserLessonProgressService, UserLessonProgressService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUserService, UserService>();

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

app.UseCors(policy => policy
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
