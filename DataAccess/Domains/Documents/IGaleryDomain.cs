using Entities.Documents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Domains.Documents
{
    public interface IGaleryDomain
    {
        Task<Galery> Insert(Galery category);
        Task<Galery> Update(int id, Galery category);
        Task Delete(int id);
        Task<Galery> Find(int id);
        Task<ICollection<Galery>> ListAll();
    }
}
