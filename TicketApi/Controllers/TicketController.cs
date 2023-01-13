using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketApi.Entities;
using TicketApi.Repositories;

namespace TicketApi.Controllers
{
    [Route("api/tickets")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository ticketRepository;

        public TicketController(ITicketRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        {
            var tickets = await ticketRepository.GetTicketsAsync();
            return Ok(tickets);
        }

        [HttpGet("{ticketId}")]
        public async Task<IActionResult> GetTicket(int ticketId)
        {
            var ticket = await ticketRepository.GetTicketAsync(ticketId);
            return Ok(ticket);
        }

        [HttpPost]
        public void CreateTicket(
            string Title, string Description, double Price)
        {
            ticketRepository.CreateTicket(Title, Description, Price);
            ticketRepository.SaveChangesAsync();

        }
        
    }
}
