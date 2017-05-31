using Entities.Documents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repository.Documents
{
    public interface IGaleryRepository
    {
        Task<Galery> Insert(Galery category);
        Task<Galery> Update(int id, Galery category);
        Task Delete(int id);
        Task<Galery> Find(int id);
        Task<ICollection<Galery>> ListAll();
    }
}
