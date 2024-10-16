using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using REPASO_PARCIAL.DOMAIN.CORE.Entities;
using REPASO_PARCIAL.DOMAIN.CORE.Interaces;
using REPASO_PARCIAL.DOMAIN.INFRAESTRUCTURE.Data;

namespace REPASO_PARCIAL.DOMAIN.INFRAESTRUCTURE.Repositories
{
    public class OrganizerRepository : IOrganizerRepository
    {
        private readonly EventManagementDbContext _dbContext;
        public OrganizerRepository(EventManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Organizers>> GetOrganizers()
        {
            var organizerss = await _dbContext.Organizers.ToListAsync();
            return organizerss;
        }

        public async Task<int> Insert(Organizers organizers)
        {
            await _dbContext.Organizers.AddAsync(organizers);
            int rows = await _dbContext.SaveChangesAsync();

            return rows > 0 ? organizers.Id : -1;
        }

        public async Task<bool> Delete(int id)
        {
            var organizer = await _dbContext
                            .Organizers
                            .FirstOrDefaultAsync(c => c.Id == id);

            if (organizer == null) return false;

            int rows = await _dbContext.SaveChangesAsync();
            return (rows > 0);

            //_dbContext.Category.Remove(category);

        }
    }
}
