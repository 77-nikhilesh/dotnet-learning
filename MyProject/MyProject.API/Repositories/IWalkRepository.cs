using MyProject.API.Models.Domain;

namespace MyProject.API.Repositories
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAllWalksAsync();
        Task<Walk> CreateWalkAsync(Walk walk);

        Task<List<Walk>> GetWalkByIdAsync(Guid id);
        Task<Walk?> UpdateWalkAsync(Guid id, Walk walkDomainModel);
        Task<Walk?> DeleteWalkAsync(Guid id);
    }
}
