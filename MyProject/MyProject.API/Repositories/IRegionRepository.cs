using MyProject.API.Models.Domain;

namespace MyProject.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<List<Region>> GetByIdAsync(Guid id);

        Task<List<Region>> CreateAsync(Region region);

        Task<List<Region>> UpdateAsync(Guid id, Region region);
        Task<List<Region>> DeleteAsync(Guid id);
    }
}
