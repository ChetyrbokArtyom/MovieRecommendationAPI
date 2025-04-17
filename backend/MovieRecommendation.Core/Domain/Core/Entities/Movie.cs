using System.ComponentModel.DataAnnotations;
namespace MovieRecommendation.Core.Domain.Core.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }
    
        [Required]
        public string Title { get; set; } = null!;
        
        [Required]
        public string Genre { get; set; } = null!;
        
        public float? MeanRating { get; set; }
        
        [Required]
        public ICollection<UserRatings> Ratings { get; set; } = new List<UserRatings>();
    }
}
