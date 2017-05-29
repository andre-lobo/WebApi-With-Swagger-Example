using System;
using DataAccess.Utils;
using Entities.Documents;
using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Domains.Documents
{
    public class DocumentDomain
    {
        #region Public Methods

        public async Task<Document> Insert(Document document)
        {
            try
            {
                using (var context = new DocumentsContext())
                {
                    var documentInserted = context.Documents.Add(document);
                    await context.SaveChangesAsync();

                    return await Task.Run(() => documentInserted);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Document> Update(int id, Document document)
        {
            try
            {
                using (var context = new DocumentsContext())
                {
                    var entity = await context.Documents.FirstOrDefaultAsync(d => d.Id == id);
                    if (entity != null)
                    {
                        context.Entry(entity).CurrentValues.SetValues(document);
                        await context.SaveChangesAsync();

                        return await Task.Run(() => document);
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
                    var entity = await context.Documents.FirstOrDefaultAsync(d => d.Id == id);

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

        public async Task<Document> Find(int id)
        {
            try
            {
                using (var context = new DocumentsContext())
                {
                    return await context.Documents.FirstOrDefaultAsync(d => d.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ICollection<Document>> ListAll()
        {
            try
            {
                using (var context = new DocumentsContext())
                {
                    return await context.Documents.ToListAsync();
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
