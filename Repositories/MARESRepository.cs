using System.Collections.Generic;
using System.Threading.Tasks;
using GS.Models;
using Microsoft.EntityFrameworkCore;

namespace GS.Repositories
{
    public class MARESRepository : IMARESRepository
    {
        private readonly ApplicationDBContext _context;

        public MARESRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MARES>> GetAllMARESAsync()
        {
            return await _context.MARES.ToListAsync();
        }

        public async Task<MARES> GetMARESByIdAsync(int id)
        {
            return await _context.MARES.FindAsync(id);
        }

        public async Task CreateMARESAsync(MARES mar)
        {
            _context.MARES.Add(mar);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMARESAsync(MARES mar)
        {
            _context.Entry(mar).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMARESAsync(int id)
        {
            var mar = await _context.MARES.FindAsync(id);
            if (mar != null)
            {
                _context.MARES.Remove(mar);
                await _context.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<MARES>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MARES> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(MARES mar)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(MARES mar)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

