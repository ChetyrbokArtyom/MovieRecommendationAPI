namespace MovieRecommendationAPI.Requests;

public record SearchMovieRequest(
    string? Title,
    List<string>? Genres,
    int Page = 1,
    int PageSize = 10
);
