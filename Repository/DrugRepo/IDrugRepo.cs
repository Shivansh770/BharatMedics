using BharatMedics.Models;

namespace BharatMedics.Repository.DrugRepo
{
    public interface IDrugRepo
    {
        Task<IEnumerable<Drug>> GetAllAsync();
        Task<Drug> GetAsync(int id);
        Task<Drug> AddAsync(Drug drug);
        Task<Drug> UpdateAsync(int id, Drug drug);
        Task<Drug> DeleteAsync(int id);
    }
}
