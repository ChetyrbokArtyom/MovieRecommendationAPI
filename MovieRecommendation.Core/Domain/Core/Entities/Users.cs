using System.ComponentModel.DataAnnotations;
namespace MovieRecommendation.Core.Domain.Core.Entities
{
    public class Users
    {
        [Key]
        public Guid UserId { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string Login { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        public string? Genres { get; set; }

        public ICollection<UserRatings> Ratings { get; set; } = new List<UserRatings>();
    }
}
