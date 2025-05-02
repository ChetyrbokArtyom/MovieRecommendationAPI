using Microsoft.AspNetCore.Mvc;
using MovieRecommendation.Application.DTOs;
using MovieRecommendation.Application.Interfaces.Services;

namespace MovieRecommendationAPI.Endpoints
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/user/Register", async (
                IUserService userService,
                [FromBody] RegisterUserDTO dto
            ) =>
            {
                try
                {
                    var token = await userService.RegisterUserAsync(dto);
                    return Results.Ok(new { Token = token });
                }
                catch (InvalidOperationException ex)
                {
                    return Results.BadRequest(new { Error = ex.Message });
                }
            });
        }
    }
}
