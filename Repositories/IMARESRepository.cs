using GS.Models;

namespace GS.Repositories
{
    public interface IMARESRepository
    {
        Task<IEnumerable<MARES>> GetAllAsync();
        Task<MARES> GetByIdAsync(int id);
        Task AddAsync(MARES mar);
        Task UpdateAsync(MARES mar);
        Task DeleteAsync(int id);
    }

}
