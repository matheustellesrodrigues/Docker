using System.Collections.Generic;
using System.Threading.Tasks;
using GS.Models;
using Microsoft.EntityFrameworkCore;

namespace GS.Repositories
{
    public class RIOSRepository : IRIOSRepository
    {
        private readonly ApplicationDBContext _context;

        public RIOSRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RIOS>> GetAllRIOSAsync()
        {
            return await _context.RIOS.ToListAsync();
        }

        public async Task<RIOS> GetRIOSByIdAsync(int id)
        {
            return await _context.RIOS.FindAsync(id);
        }

        public async Task CreateRIOSAsync(RIOS rio)
        {
            _context.RIOS.Add(rio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRIOSAsync(RIOS rio)
        {
            _context.Entry(rio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRIOSAsync(int id)
        {
            var rio = await _context.RIOS.FindAsync(id);
            if (rio != null)
            {
                _context.RIOS.Remove(rio);
                await _context.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<RIOS>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RIOS> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(RIOS rio)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(RIOS rio)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
