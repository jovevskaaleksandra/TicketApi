using TicketApi.Entities;

namespace TicketApi.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(int userId);

        Task<bool> SaveChangesAsync();
    }
}
