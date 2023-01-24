using Microsoft.EntityFrameworkCore;
using TicketApi.DbContexts;
using TicketApi.Entities;

namespace TicketApi.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly TicketContext _ticketContext;

        public UserRepository(TicketContext ticketContext)
        {
            _ticketContext = ticketContext;
        }

        public async Task<User> GetUserAsync(int userId)
        {
            return await _ticketContext.Users.Where(c => c.Id == userId).FirstOrDefaultAsync() ??
                throw new ArgumentNullException(nameof(userId));
            
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _ticketContext.Users.OrderBy(c => c.Username).ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _ticketContext.SaveChangesAsync() >= 0);
        }

      
    }
}
