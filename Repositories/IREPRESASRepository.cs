using GS.Models;

namespace GS.Repositories
{
    public interface IREPRESASRepository
    {
        Task<IEnumerable<REPRESAS>> GetAllAsync();
        Task<REPRESAS> GetByIdAsync(int id);
        Task AddAsync(REPRESAS represa);
        Task UpdateAsync(REPRESAS represa);
        Task DeleteAsync(int id);
    }
}
