using MyProject.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using MyProject.API.Data;

namespace MyProject.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly MyProjectDbContext _dbContext;
        public SQLWalkRepository(MyProjectDbContext DbContext)
        {
            this._dbContext = DbContext;
        }

        public async Task<List<Walk>> GetAllWalksAsync()
        {
            return await _dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<List<Walk>> GetWalkByIdAsync(Guid id)
        {
            return await _dbContext.Walks.Include("Difficulty").Include("Region").Where(w => w.Id == id).ToListAsync();
        }
        public async Task<Walk> CreateWalkAsync(Walk walk)
        {
            await _dbContext.Walks.AddAsync(walk);
            await _dbContext.SaveChangesAsync();
            return walk;
        }


    }
}
    