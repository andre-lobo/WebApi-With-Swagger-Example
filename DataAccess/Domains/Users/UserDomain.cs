using System;
using DataAccess.Utils;
using Entities.Users;
using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Repository.Users;

namespace DataAccess.Domains.Users
{
    public class UserDomain : IUserRepository
    {
        #region Public Methods

        public async Task<User> Insert(User user)
        {
            try
            {
                using (var context = new DocumentsContext())
                {
                    user.Password = Encryption.Encrypt(user.Password);
                    var userInserted = context.Users.Add(user);
                    await context.SaveChangesAsync();

                    return await Task.Run(() => userInserted);
                }                 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> Update(int id, User user)
        {
            try
            {
                using (var context = new DocumentsContext())
                {
                    var entity = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
                    if (entity != null)
                    {
                        user.Password = Encryption.Encrypt(user.Password);
                        context.Entry(entity).CurrentValues.SetValues(user);
                        await context.SaveChangesAsync();

                        return await Task.Run(() => user);
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
                    var entity = await context.Users.FirstOrDefaultAsync(u => u.Id == id);

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

        public async Task<User> Find(int id)
        {
            try
            {
                using (var context = new DocumentsContext())
                {
                    return await context.Users.FirstOrDefaultAsync(u => u.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ICollection<User>> ListAll()
        {
            try
            {
                using (var context = new DocumentsContext())
                {
                    return await context.Users.ToListAsync();
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
