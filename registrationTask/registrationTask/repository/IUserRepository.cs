using registrationTask.Models;

namespace registrationTask.repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> FindById(int id);
        Task<User> Add(User user);

        User update(User user);
        User Delete(User user);
    }
}
