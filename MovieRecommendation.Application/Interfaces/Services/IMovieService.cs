using MovieRecommendation.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.Application.Interfaces.Services
{
    public interface IMovieService
    {
        Task<MovieDTO> AddMoviesAsync(CreateMovieDTO movieDTO);
        Task<IEnumerable<MovieDTO>> SearchMovieByFilter(string? title, List<string>? genres, int page, int pageSize);
    }
}
