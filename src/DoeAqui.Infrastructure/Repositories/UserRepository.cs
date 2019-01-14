using System.Linq;
using DoeAqui.Domain.AggregateModels.UserAggregate;
using DoeAqui.Domain.AggregateModels.UserAggregate.Repository;
using DoeAqui.Infrastructure.Context;

namespace DoeAqui.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DoeAquiContext context)
            : base(context) { }

        public User GetByEmail(string email)
        {
            return Context.Set<User>().FirstOrDefault(u => u.Email == email);
        }
    }
}