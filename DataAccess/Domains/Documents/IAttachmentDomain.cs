using Entities.Documents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Domains.Documents
{
    public interface IAttachmentDomain
    {
        Task<Attachment> Insert(Attachment attachment);
        Task<Attachment> Update(int id, Attachment attachment);
        Task Delete(int id);
        Task<Attachment> Find(int id);
        Task<ICollection<Attachment>> ListAll();
    }
}
