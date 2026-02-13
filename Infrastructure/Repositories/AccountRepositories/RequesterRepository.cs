using Domain.Models;

namespace Infrastructure.Repositories.UserRepositories
{
    public class RequesterRepository : AccountRepository<Requester>
    {
        public RequesterRepository(DonationsDbContext dbContext) : base(dbContext)
        {

        }
    }
}
