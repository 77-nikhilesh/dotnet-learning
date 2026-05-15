using MyProject.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using MyProject.API.Data;
using Microsoft.AspNetCore.Http.HttpResults;

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

        public async Task<Walk?> UpdateWalkAsync(Guid id, Walk walk)
        {
            var existingWalk = await _dbContext.Walks.FindAsync(id);
            if (existingWalk == null)
            {
                return null;
            }
            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId = walk.RegionId;

            await _dbContext.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<Walk?> DeleteWalkAsync(Guid id)
        {
            var existingWalk = await _dbContext.Walks.FindAsync(id);
            if (existingWalk == null)
            {
                return null;
            }
            _dbContext.Walks.Remove(existingWalk);
            await _dbContext.SaveChangesAsync();
            return existingWalk;

        }
    }
}