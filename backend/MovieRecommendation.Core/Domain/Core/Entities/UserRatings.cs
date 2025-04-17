    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRecommendation.Core.Domain.Core.Entities
    {
        public class UserRatings
        {
            [Required]    
            public float Rating { get; set; }
        
            public Guid UserId { get; set; }
            public Users User { get; set; } = null!;
            
            public Guid MovieId { get; set; }

            public Movie Movie { get; set; } = null!;
        }
    }
