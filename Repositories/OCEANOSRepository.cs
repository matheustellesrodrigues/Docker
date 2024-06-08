using System.Collections.Generic;
using System.Threading.Tasks;
using GS.Models;
using Microsoft.EntityFrameworkCore;

namespace GS.Repositories
{
    public class OCEANOSRepository : IOCEANOSRepository
    {
        private readonly ApplicationDBContext _context;

        public OCEANOSRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OCEANOS>> GetAllOCEANOSAsync()
        {
            return await _context.OCEANOS.ToListAsync();
        }

        public async Task<OCEANOS> GetOCEANOSByIdAsync(int id)
        {
            return await _context.OCEANOS.FindAsync(id);
        }

        public async Task CreateOCEANOSAsync(OCEANOS oceano)
        {
            _context.OCEANOS.Add(oceano);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOCEANOSAsync(OCEANOS oceano)
        {
            _context.Entry(oceano).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOCEANOSAsync(int id)
        {
            var oceano = await _context.OCEANOS.FindAsync(id);
            if (oceano != null)
            {
                _context.OCEANOS.Remove(oceano);
                await _context.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<OCEANOS>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OCEANOS> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(OCEANOS oceano)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(OCEANOS oceano)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
