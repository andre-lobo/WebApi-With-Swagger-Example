using System;
using DataAccess.Utils;
using Entities.Documents;
using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Domains.Documents
{
    public class GaleryDomain : IGaleryDomain
    {
        #region Public Methods

        public async Task<Galery> Insert(Galery galery)
        {
            try
            {
                using (var context = new DocumentsContext())
                {
                    var galeryInserted = context.Galeries.Add(galery);
                    await context.SaveChangesAsync();

                    return await Task.Run(() => galeryInserted);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Galery> Update(int id, Galery galery)
        {
            try
            {
                using (var context = new DocumentsContext())
                {
                    var entity = await context.Galeries.FirstOrDefaultAsync(g => g.Id == id);
                    if (entity != null)
                    {
                        context.Entry(entity).CurrentValues.SetValues(galery);
                        await context.SaveChangesAsync();

                        return await Task.Run(() => galery);
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
                    var entity = await context.Galeries.FirstOrDefaultAsync(g => g.Id == id);

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

        public async Task<Galery> Find(int id)
        {
            try
            {
                using (var context = new DocumentsContext())
                {
                    return await context.Galeries.FirstOrDefaultAsync(g => g.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ICollection<Galery>> ListAll()
        {
            try
            {
                using (var context = new DocumentsContext())
                {
                    return await context.Galeries.ToListAsync();
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
