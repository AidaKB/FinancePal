using FinancePal.Data;
using FinancePal.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancePal.Repositories
{
    public class UserRepository
    {
        private readonly FinancePalDbContext dbContext;

        public UserRepository(FinancePalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> CreateAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> DeleteAsync(int id)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return null;
            }
            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();
            return user;

        }

        public async Task<List<User>> GetAllAsync()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<User> UpdateAsync(int id, User userObject)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return null;
            }

            user.FirstName = userObject.FirstName;
            user.LastName = userObject.LastName;
            user.Email = userObject.Email;

            await dbContext.SaveChangesAsync();
            return user;
        }
    }
}
