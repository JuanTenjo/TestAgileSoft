using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TestAgileSoft.Domain.Entities;
using TestAgileSoft.Domain.Ports;
using TestAgileSoft.Infrastructure.Adapters;
using TestAgileSoft.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var DbSecret = config["ConnectionStrings:database"];
var KeyJwtSecret = config["KeyJwt"];
var SchemaName = config["SchemaName"];

builder.Services.AddControllers(opt =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PersistenceContext>(opt =>
{
    opt.UseSqlServer(config.GetConnectionString("database")!, sqlopts =>
    {
        sqlopts.MigrationsHistoryTable("_MigrationHistory", SchemaName);
    });
});

//MAPPP

//SERVICES

var builderSecurity = builder.Services.AddIdentityCore<User>();
var identityBuilder = new IdentityBuilder(builderSecurity.UserType, builder.Services);


identityBuilder.AddEntityFrameworkStores<PersistenceContext>();
identityBuilder.AddSignInManager<SignInManager<User>>();
builder.Services.AddSingleton<ISystemClock, SystemClock>();
builder.Services.AddScoped<IJwtGenerator, JwtGenerator>();
builder.Services.AddScoped<IUserSession, UserSession>();


//AUTORIAZACION
//Validar Token en en headers del request
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KeyJwtSecret!));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateAudience = false,
                        ValidateIssuer = false,
                    };
                });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestAgileSoft v1"));

app.MapControllers();

app.Run();

public partial class Program { }