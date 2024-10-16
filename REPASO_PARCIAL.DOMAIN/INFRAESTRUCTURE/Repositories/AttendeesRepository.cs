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
    public class AttendeesRepository : IAttendeesRepository
    {
        private readonly EventManagementDbContext _eventManagementDbContext;

        public AttendeesRepository(EventManagementDbContext dbContext)
        {
            _eventManagementDbContext = dbContext;
        }

        // Obtener todos los asistentes
        public async Task<IEnumerable<Attendees>> GetAttendees()
        {
            var attendees = await _eventManagementDbContext.Attendees.ToListAsync();
            return attendees;
        }

        // Insertar un nuevo asistente
        public async Task<int> Insert(Attendees attendee)
        {
            await _eventManagementDbContext.Attendees.AddAsync(attendee);
            int rows = await _eventManagementDbContext.SaveChangesAsync();

            return rows > 0 ? attendee.Id : -1;
        }

        // Eliminar un asistente
        public async Task<bool> Delete(int id)
        {
            var attendee = await _eventManagementDbContext.Attendees.FirstOrDefaultAsync(c => c.Id == id);

            if (attendee == null) return false;

            _eventManagementDbContext.Attendees.Remove(attendee);
            int rows = await _eventManagementDbContext.SaveChangesAsync();

            return (rows > 0);
        }

    }
}
