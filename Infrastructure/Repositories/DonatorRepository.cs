using Domain.Models;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DonatorRepository<T> : BaseRepository<T> where T : Donator
    {
        public DonatorRepository(DonationsDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<T?> GetAsync(string email)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
