using MyProject.API.Models.Domain;

namespace MyProject.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync(string? filterOn=null,string? filterQuery=null, string? SortBy=null, bool? isAscending=true);
        Task<Region?> GetByIdAsync(Guid id);

        Task<Region> CreateAsync(Region region);

        Task<Region?> UpdateAsync(Guid id, Region region);
        Task<Region?> DeleteAsync(Guid id);
    }
}
