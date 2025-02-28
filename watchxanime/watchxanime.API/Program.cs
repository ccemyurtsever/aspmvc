using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using watchxanime.API.Services.UserServices;
using watchxanime.Business;
using watchxanime.Business.Concete;
using watchxanime.DataAccsess.Abstract;
using watchxanime.DataAccsess.Context;
using watchxanime.DataAccsess.Repositories;

//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(MyAllowSpecificOrigins, policy =>
//    {
//        // policy.WithOrigins("https://localhost:7142;http://localhost:5248") 
//        policy.AllowAnyOrigin()
//        .AllowAnyHeader()
//        .AllowAnyMethod();
//    });
//});

// CORS yapılandırması
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin() // Tüm kaynaklara izin ver
            .AllowAnyMethod() // Herhangi bir HTTP metoduna izin ver
            .AllowAnyHeader()); // Herhangi bir başlığa izin ver
});


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>),typeof(GenericManager<>));
// Add services to the container.
builder.Services.AddDbContext<watchxanimeContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<watchxanimeContext>();
builder.Services.Configure<IdentityOptions>(options =>
{
    // Şifre ayarları
    options.Password.RequiredLength = 8; // Minimum 8 karakter
    options.Password.RequireNonAlphanumeric = false; // Alfanümerik olmayan karakter gereksinimi kapalı
    options.Password.RequireDigit = true; // Şifrede en az bir rakam zorunlu
    options.Password.RequireUppercase = true; // Şifrede en az bir büyük harf zorunlu
    options.Password.RequireLowercase = true; // Şifrede en az bir küçük harf zorunlu

    // Kullanıcı ayarları
    options.User.RequireUniqueEmail = true; // E-posta benzersiz olmalı
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+/"; // Kullanıcı adında izin verilen karakterler

    // Kilitlenme ayarları
    options.Lockout.MaxFailedAccessAttempts = 5; // Maksimum hatalı giriş sayısı
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15); // Kilitlenme süresi (15 dakika)
    options.Lockout.AllowedForNewUsers = true; // Yeni kullanıcılar için kilitlenme aktif
});

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = true; // sadece https
    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidIssuer = "watchXanime",
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings:Secret").Value ?? "")),
        ValidateLifetime = true
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerGen(option =>
//{
//    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
//    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        In = ParameterLocation.Header,
//        Description = "Please enter a valid token",
//        Name = "Authorization",
//        Type = SecuritySchemeType.Http,
//        BearerFormat = "JWT",
//        Scheme = "Bearer"
//    });
//    option.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type=ReferenceType.SecurityScheme,
//                    Id="Bearer"
//                }
//            },
//            new string[]{}
//        }
//    });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
//app.UseRouting();
//app.UseCors(MyAllowSpecificOrigins); // static dosyalardan once tanimlanacak
app.UseAuthorization();

app.MapControllers();

app.Run();
