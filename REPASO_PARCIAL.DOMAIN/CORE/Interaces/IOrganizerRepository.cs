using REPASO_PARCIAL.DOMAIN.CORE.Entities;

namespace REPASO_PARCIAL.DOMAIN.CORE.Interaces
{
    public interface IOrganizerRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Organizers>> GetOrganizers();
        Task<int> Insert(Organizers organizers);
    }
}