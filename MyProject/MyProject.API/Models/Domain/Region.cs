namespace MyProject.API.Models.Domain
{
    public class Region
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }

        public static implicit operator Region(List<Region> v)
        {
            throw new NotImplementedException();
        }
    }
}
