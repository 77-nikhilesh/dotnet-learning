using System.ComponentModel.DataAnnotations;

namespace MyProject.API.DTOs
{
    public class UpdateWalksRequestDto
    {
        [Required]
        [MinLength(4, ErrorMessage = "Name must be at least 4 characters long")]
        [MaxLength(100, ErrorMessage = "Name must be at most 100 characters long")]
        public required string Name { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Description must be at least 10 characters long")]
        [MaxLength(200, ErrorMessage = "Description must be at most 200 characters long")]
        public required string Description { get; set; }
        [Required]
        public required double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
    }
}
