using System.ComponentModel.DataAnnotations;
namespace MovieRecommendation.Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
    
        [Required]
        public string Title { get; set; } = null!;
        
        [Required]
        public string Genre { get; set; } = null!;
        
        public float? MeanRating { get; set; }
        
        [Required]
        public ICollection<UserRatings> Ratings { get; set; } = new List<UserRatings>();
    }
}
