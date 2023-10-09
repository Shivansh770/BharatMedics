using BharatMedics.Models;

namespace BharatMedics.Repository.SupplierRepo
{
    public interface ISupplierRepo
    {
        
        Task<Supplier> AddSupplierAsync(Supplier supplier);
        Task<Supplier> UpdateSupplierAsync(int supplierId, Supplier supplier);
        Task<Supplier> DeleteSupplierAsync(int supplierId);
        Task<Supplier> GetSupplierAsync(int supplierId);

        Task<IEnumerable<Supplier>> GetAllSupplierAsync();
    }
}
