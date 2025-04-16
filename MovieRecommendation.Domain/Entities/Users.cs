using System.ComponentModel.DataAnnotations;
namespace MovieRecommendation.Domain.Entities
{
    public class Users
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Login { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        public string? Genres { get; set; }

        public ICollection<UserRatings> Ratings { get; set; } = new List<UserRatings>();
    }
}
