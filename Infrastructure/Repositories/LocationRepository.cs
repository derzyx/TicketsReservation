using Application.IRepositories;
using Domain.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly Context context;

        public LocationRepository(Context _context)
        {
            context = _context;
        }

        public Task<Location> AddAsync(Location entity)
        {
            throw new NotImplementedException();
        }

        public Task<Location?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
