using System;
using DataAccess.Utils;
using Entities.Documents;
using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Repository.Documents;

namespace DataAccess.Domains.Documents
{
    public class AttachmentDomain : IAttachmentRepository
    {
        #region Public Methods

        public async Task<Attachment> Insert(Attachment attachment)
        {
            try
            {
                using (var context = new DocumentsContext())
                {
                    var attachmentInserted = context.Attachments.Add(attachment);
                    await context.SaveChangesAsync();

                    return await Task.Run(() => attachmentInserted);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Attachment> Update(int id, Attachment attachment)
        {
            try
            {
                using (var context = new DocumentsContext())
                {
                    var entity = await context.Attachments.FirstOrDefaultAsync(a => a.Id == id);
                    if (entity != null)
                    {
                        context.Entry(entity).CurrentValues.SetValues(attachment);
                        await context.SaveChangesAsync();

                        return await Task.Run(() => attachment);
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                using (var context = new DocumentsContext())
                {
                    var entity = await context.Attachments.FirstOrDefaultAsync(a => a.Id == id);

                    if (entity != null)
                    {
                        context.Entry(entity).State = EntityState.Deleted;
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Attachment> Find(int id)
        {
            try
            {
                using (var context = new DocumentsContext())
                {
                    return await context.Attachments.FirstOrDefaultAsync(a => a.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ICollection<Attachment>> ListAll()
        {
            try
            {
                using (var context = new DocumentsContext())
                {
                    return await context.Attachments.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
