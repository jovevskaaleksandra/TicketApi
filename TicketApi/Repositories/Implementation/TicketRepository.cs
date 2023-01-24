using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketApi.DbContexts;
using TicketApi.Entities;

namespace TicketApi.Repositories.Implementation
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketContext _ticketContext;
        private readonly IUserRepository _userRepository;

        public TicketRepository(TicketContext ticketContext, IUserRepository userRepository)
        {
            _ticketContext = ticketContext;
            _userRepository = userRepository;
        }
        public async Task AddTicketToUserAsync(int userId, int ticketId)
        {
            var user = await _userRepository.GetUserAsync(userId);
            var ticket = await _ticketContext.Tickets.Where(c => c.Id == ticketId).FirstOrDefaultAsync() ??
                throw new ArgumentNullException(nameof(ticketId));
            if (user != null)
            {
                user.Tickets.Add(ticket);
            }
        }

        public void CreateTicket(string Title, string Description, string Price)
        {
            Ticket ticket = new Ticket();
            ticket.Title = Title;
            ticket.Description = Description;
            ticket.Price = Price;
            _ticketContext.Tickets.Add(ticket);
        }

        public async Task DeleteTicketAsync(int ticketId)
        {
            var ticket = await GetTicketAsync(ticketId);
            _ticketContext.Remove(ticket);
            await _ticketContext.SaveChangesAsync();
        }

        public async Task<Ticket> GetTicketAsync(int ticketId)
        {
            var test = await _ticketContext.Tickets.Where(c => c.Id == ticketId).FirstOrDefaultAsync() ??
                throw new ArgumentNullException(nameof(ticketId));
            return test;
        }

        public async Task<IEnumerable<Ticket>> GetTicketsAsync()
        {
            return await _ticketContext.Tickets.OrderBy(c => c.Title).ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _ticketContext.SaveChangesAsync() >= 0);
        }
    }
}
