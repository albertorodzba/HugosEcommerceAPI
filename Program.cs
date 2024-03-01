
using System.Text;
using hugosEcommerce_api.Database;
using hugosEcommerce_api.Filters;
using hugosEcommerce_api.Helpers.FilesValidator;
using hugosEcommerce_api.Models;
using hugosEcommerce_api.Services.Jwt;
using hugosEcommerce_api.Services.Storage;
using hugosEcommerce_api.Utils.Secrets;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

builder.Services.AddControllers( (config) => config.Filters.Add(typeof(GlobalExceptionHandler)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDatabaseConfig, DatabaseConfig>();
builder.Services.AddScoped<IStorageService, GoogleCloudStorageService>();
builder.Services.AddScoped<IFileValidator, FileValidator>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
// builder.Services.AddScoped<IStorageService, FirebaseStorageService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option => option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(EnvironmentVariables.JWTSecret))
    });

builder.Services.AddAuthorization(
    options => {
        options.AddPolicy("Admin", policy => policy.RequireClaim("roleType", "1"));
        options.AddPolicy("Customer", policy => policy.RequireClaim("roleType", "2"));
    }
);


builder.Services.AddCors(options =>
{ 
    options.AddPolicy(name: "corsPolicy", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseCors("corsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
