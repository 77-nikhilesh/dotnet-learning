namespace MyProject.API.DTOs
{
    public class AddRegionRequestDto
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public string? RegionImageUrl { get; set; }

    }
}
