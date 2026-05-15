namespace MyProject.API.DTOs
{
    public class UpdateRegionRequestDto
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
