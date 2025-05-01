using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieRecommendation.Application.DTOs;
using MovieRecommendation.Application.Interfaces.Repositories;
using MovieRecommendation.Application.Interfaces.Services;
using MovieRecommendation.Application.Services;
using MovieRecommendation.Infrastructure.Data;
using MovieRecommendation.Infrastructure.Repositories;
using MovieRecommendation.Infrastructure.Services;
using MovieRecommendationAPI.Endpoints;
using System.Text;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// ---------- Services ----------
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("ApplicationDbContext")));

builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUserRatingRepository, UserRatingRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IRatingService, RatingService>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

// ---------- Authentication ----------
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization();

// ---------- CORS ----------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

// ---------- Endpoints ----------
app.MapPost("/movies", async ([FromBody] CreateMovieDTO movieDto, IMovieService movieService) =>
{
    var movie = await movieService.AddMoviesAsync(movieDto);
    return Results.Created($"/movies/{movie.Id}", movie);
});

app.MapGet("/", () => "Hello World!");
app.MapMovieEndpoints(); 

app.Run();
