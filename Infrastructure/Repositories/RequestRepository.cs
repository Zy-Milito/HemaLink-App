using Domain.Interfaces.Repositories;
using Domain.Models;
using Domain.Models.Enums;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RequestRepository<T> : BaseRepository<T>, IRequestRepository<T> where T : BloodRequest
    {
        public RequestRepository(DonationsDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<T>> GetAsync()
        {
            return await _dbContext.Set<T>().Where(br => br.RequestStatus == RequestStatus.Open).ToListAsync();
        }

        public async Task<List<T>> GetAsync(BloodType bloodType)
        {
            return await _dbContext.Set<T>()
                .Where(br => br.RequestStatus == RequestStatus.Open && br.BloodTypesNeeded.Contains(bloodType))
                .ToListAsync();
        }
    }
}
