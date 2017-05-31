using System;
using DataAccess.Utils;
using Entities.Documents;
using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Repository.Documents;

namespace DataAccess.Domains.Documents
{
    public class CategoryDomain : ICategoryRepository
    {
        #region Public Methods

        public async Task<Category> Insert(Category category)
        {
            try
            {
                using (var context = new DocumentsContext())
                {
                    var categoryInserted = context.Categories.Add(category);
                    await context.SaveChangesAsync();

                    return await Task.Run(() => categoryInserted);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Category> Update(int id, Category category)
        {
            try
            {
                using (var context = new DocumentsContext())
                {
                    var entity = await context.Categories.FirstOrDefaultAsync(a => a.Id == id);
                    if (entity != null)
                    {
                        context.Entry(entity).CurrentValues.SetValues(category);
                        await context.SaveChangesAsync();

                        return await Task.Run(() => category);
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
                    var entity = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);

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

        public async Task<Category> Find(int id)
        {
            try
            {
                using (var context = new DocumentsContext())
                {
                    return await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ICollection<Category>> ListAll()
        {
            try
            {
                using (var context = new DocumentsContext())
                {
                    return await context.Categories.ToListAsync();
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
