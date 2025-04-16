using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.Application.DTOs
{
    public class UpdateGenresDTO
    {
        public Guid UserId { get; set; }
        public string Genres { get; set; } = null!;
    }
}
