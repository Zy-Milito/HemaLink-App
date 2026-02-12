using Domain.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.UserRepositories
{
    public class AccountRepository<T> : BaseRepository<T>, IAccountRepository<T> where T : Account
    {
        public AccountRepository(DonationsDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<T?> GetAsync(string email)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
