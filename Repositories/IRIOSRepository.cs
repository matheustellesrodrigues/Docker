using GS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS.Repositories
{
    public interface IRIOSRepository
    {
        Task<IEnumerable<RIOS>> GetAllAsync();
        Task<RIOS> GetByIdAsync(int id);
        Task AddAsync(RIOS rio);
        Task UpdateAsync(RIOS rio);
        Task DeleteAsync(int id);
    }
}
