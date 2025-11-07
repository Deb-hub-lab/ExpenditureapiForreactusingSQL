using Microsoft.EntityFrameworkCore;
using MyExpenditure.Data;
using MyExpenditure.Interfaces;
using MyExpenditure.Model;

namespace MyExpenditure.Repositories
{
    public class ExpenditureRepository : IExpenditureRepository
    {
        private readonly ApplicationDbContext _context;

        public ExpenditureRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Expenditure>> GetAllAsync()
        {
            return await _context.Expenditures.ToListAsync();
        }

        public async Task<Expenditure?> GetByIdAsync(int id)
        {
            return await _context.Expenditures.FindAsync(id);
        }

        public async Task AddAsync(Expenditure expenditure)
        {
            await _context.Expenditures.AddAsync(expenditure);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Expenditure expenditure)
        {
            _context.Entry(expenditure).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var expenditure = await _context.Expenditures.FindAsync(id);
            if (expenditure != null)
            {
                _context.Expenditures.Remove(expenditure);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Expenditures.AnyAsync(e => e.Id == id);
        }
    }
}
