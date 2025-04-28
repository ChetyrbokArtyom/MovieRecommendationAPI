using Microsoft.EntityFrameworkCore;
using MovieRecommendation.Application.Interfaces.Repositories;
using MovieRecommendation.Application.Interfaces.Services;
using MovieRecommendation.Infrastructure.Data;
using MovieRecommendation.Infrastructure.Repositories;
using MovieRecommendation.Application.Services;
using MovieRecommendation.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using MovieRecommendationAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("ApplicationDbContext"))
);


builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUserRatingRepository, UserRatingRepository>();
builder.Services.AddScoped<IRatingService, RatingService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();


app.UseCors("AllowAll");

app.MapPost("/movies", async ([FromBody] CreateMovieDTO movieDto, IMovieService movieService) =>
{
    var movie = await movieService.AddMoviesAsync(movieDto);
    return Results.Created($"/movies/{movie.Id}", movie);
});

app.MapGet("/", () => "Hello World!");
app.MapMovieEndpoints(); 

app.Run();
