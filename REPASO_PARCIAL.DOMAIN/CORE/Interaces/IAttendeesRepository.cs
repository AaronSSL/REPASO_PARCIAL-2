using REPASO_PARCIAL.DOMAIN.CORE.Entities;

namespace REPASO_PARCIAL.DOMAIN.CORE.Interaces
{
    public interface IAttendeesRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Attendees>> GetAttendees();
        Task<int> Insert(Attendees attendee);
    }
}