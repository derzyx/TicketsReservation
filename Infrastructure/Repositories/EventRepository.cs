using Application.IRepositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly Context context;

        public EventRepository(Context _context)
        {
            context = _context;
        }

        public async Task<Event> AddAsync(Event ev)
        {
            context.Events.AddAsync(ev);
            await context.SaveChangesAsync();

            return ev;
        }

        public async Task<ICollection<Event>> GetAll()
        {
            return await context.Events.ToListAsync();
        }

        public async Task<Event?> GetByIdAsync(Guid id)
        {
            return await context.Events.FirstOrDefaultAsync(e => e.Id == id);
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
