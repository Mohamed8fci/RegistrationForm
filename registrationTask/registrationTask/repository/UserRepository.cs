using Microsoft.EntityFrameworkCore;
using registrationTask.Models;

namespace registrationTask.repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<User> Add(User user)
        {
            await _context.AddAsync(user);
            _context.SaveChanges();
            return user;
        }

        public User Delete(User user)
        {
            _context.Remove(user);
            _context.SaveChanges();
            return user;
        }

        public async Task<User> FindById(int id)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public User update(User user)
        {
            _context.Update(user);
            _context.SaveChanges();

            return user;
        }
    }
}
