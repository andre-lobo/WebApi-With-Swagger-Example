using Entities.Documents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Domains.Documents
{
    public interface IDocumentDomain
    {
        Task<Document> Insert(Document category);
        Task<Document> Update(int id, Document category);
        Task Delete(int id);
        Task<Document> Find(int id);
        Task<ICollection<Document>> ListAll();
    }
}
