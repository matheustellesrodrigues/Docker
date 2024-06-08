using GS.Models;

namespace GS.Repositories
{
    public interface IOCEANOSRepository
    {
        Task<IEnumerable<OCEANOS>> GetAllAsync();
        Task<OCEANOS> GetByIdAsync(int id);
        Task AddAsync(OCEANOS oceano);
        Task UpdateAsync(OCEANOS oceano);
        Task DeleteAsync(int id);
    }
}
