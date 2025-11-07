using MyExpenditure.Model;

namespace MyExpenditure.Interfaces
{
    public interface IExpenditureRepository
    {
        Task<IEnumerable<Expenditure>> GetAllAsync();
        Task<Expenditure?> GetByIdAsync(int id);
        Task AddAsync(Expenditure expenditure);
        Task UpdateAsync(Expenditure expenditure);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
