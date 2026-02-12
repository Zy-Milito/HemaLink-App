using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IAccountRepository<T> : IBaseRepository<T> where T : Account
    {
        Task<T?> GetAsync(string email);
    }
}
