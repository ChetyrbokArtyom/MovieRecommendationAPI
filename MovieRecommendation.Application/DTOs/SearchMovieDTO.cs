using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.Application.DTOs
{
    public class SearchMovieDTO
    {
        public string Title { get; set; } = null!;
        public string? Genre { get; set; }
    }
}
