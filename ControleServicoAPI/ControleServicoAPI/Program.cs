global using ControleServicoAPI.Data;
using ControleServicoAPI.Migrations;
using ControleServicoAPI.Models;
using ControleServicoAPI.services;
using ControleServicoAPI.UtilityService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IControleServico, CadServicoService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddCors(options =>

    options.AddPolicy(name:"CadServicoOrigins", policy =>
    {
        policy.WithOrigins("https://controle-servico-ui.vercel.app").AllowAnyMethod().AllowAnyHeader();
    }));
   

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x=>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("XuH6vd1ZKYs3T5WqhCsI9ZRdA7bUwFo8LvL3PCGb91tBj4xKyeMR6clgQNoD2ETh")),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
    });

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CadServicoOrigins");

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
