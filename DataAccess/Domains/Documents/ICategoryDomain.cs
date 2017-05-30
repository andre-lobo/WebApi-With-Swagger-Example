using Entities.Documents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Domains.Documents
{
    public interface ICategoryDomain
    {
        Task<Category> Insert(Category category);
        Task<Category> Update(int id, Category category);
        Task Delete(int id);
        Task<Category> Find(int id);
        Task<ICollection<Category>> ListAll();
    }
}
