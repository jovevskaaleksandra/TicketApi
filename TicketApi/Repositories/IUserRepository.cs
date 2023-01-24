using TicketApi.Entities;

namespace TicketApi.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserAsync(int userId);

        Task<bool> SaveChangesAsync();
    }
}
