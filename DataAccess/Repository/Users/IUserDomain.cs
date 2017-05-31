using Entities.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repository.Users
{
    public interface IUserRepository
    {
        Task<User> Insert(User user);
        Task<User> Update(int id, User user);
        Task Delete(int id);
        Task<User> Find(int id);
        Task<ICollection<User>> ListAll();
    }
}
