using System.Collections.Generic;
using System.Threading.Tasks;
using GS.Models;
using Microsoft.EntityFrameworkCore;

namespace GS.Repositories
{
    public class REPRESASRepository : IREPRESASRepository
    {
        private readonly ApplicationDBContext _context;

        public REPRESASRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<REPRESAS>> GetAllREPRESASAsync()
        {
            return await _context.REPRESAS.ToListAsync();
        }

        public async Task<REPRESAS> GetREPRESASByIdAsync(int id)
        {
            return await _context.REPRESAS.FindAsync(id);
        }

        public async Task CreateREPRESASAsync(REPRESAS represa)
        {
            _context.REPRESAS.Add(represa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateREPRESASAsync(REPRESAS represa)
        {
            _context.Entry(represa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteREPRESASAsync(int id)
        {
            var represa = await _context.REPRESAS.FindAsync(id);
            if (represa != null)
            {
                _context.REPRESAS.Remove(represa);
                await _context.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<REPRESAS>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<REPRESAS> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(REPRESAS represa)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(REPRESAS represa)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
