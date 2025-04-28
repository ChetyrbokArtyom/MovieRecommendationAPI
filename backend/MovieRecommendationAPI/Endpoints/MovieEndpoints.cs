using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using MovieRecommendationAPI.Requests;
using MovieRecommendation.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
namespace MovieRecommendationAPI.Endpoints
{
    public static class MovieEndpoints
    {
        public static void MapMovieEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/movies/search", async (
    IMovieService movieService,
    [FromQuery] string? Title,
    [FromQuery] string? Genres, 
    [FromQuery] int Page = 1,
    [FromQuery] int PageSize = 10
) =>
            {
                var genreList = string.IsNullOrEmpty(Genres) ? new List<string>() : Genres.Split(',').ToList();

                var movies = await movieService.SearchMovieByFilter(
                    Title,
                    genreList, 
                    Page,
                    PageSize
                );
                return Results.Ok(movies);
            });
        }
    }
}