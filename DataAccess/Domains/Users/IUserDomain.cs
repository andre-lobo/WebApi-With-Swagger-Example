using Entities.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Domains.Users
{
    public interface IUserDomain
    {
        Task<User> Insert(User user);
        Task<User> Update(int id, User user);
        Task Delete(int id);
        Task<User> Find(int id);
        Task<ICollection<User>> ListAll();
    }
}
