using TicketApi.Entities;

namespace TicketApi.Repositories
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetTicketsAsync();
        Task<Ticket> GetTicketAsync(int ticketId);

        void CreateTicket(string Title, string Description, string Price);
        Task DeleteTicketAsync(int ticketId);

        Task AddTicketToUserAsync(int userId, int ticketId);

        Task<bool> SaveChangesAsync();

    }
}
