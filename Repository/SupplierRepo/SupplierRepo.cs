using BharatMedics.Models;
using Microsoft.EntityFrameworkCore;

namespace BharatMedics.Repository.SupplierRepo
{
    public class SupplierRepo : ISupplierRepo
    {
        Context context;
        public SupplierRepo(Context context)
        {
            this.context = context;
        }

        public async Task<Supplier> AddSupplierAsync(Supplier supplier)
        {
            await context.Suppliers.AddAsync(supplier);
            await context.SaveChangesAsync();
            return supplier;
        }

        public async Task<Supplier> DeleteSupplierAsync(int supplierId)
        {
            var existingSupplier = await context.Suppliers.FindAsync();
            if (existingSupplier == null)
            {
                return null;
            }
            context.Suppliers.Remove(existingSupplier);
            await context.SaveChangesAsync();
            return existingSupplier;
        }

        public async Task<IEnumerable<Supplier>> GetAllSupplierAsync()
        {
            return await context.Suppliers.ToListAsync();
        }

        public async Task<Supplier> GetSupplierAsync(int supplierId)
        {
            return await context.Suppliers.FirstOrDefaultAsync(x => x.SuppilerId == supplierId);
        }

        public async Task<Supplier> UpdateSupplierAsync(int supplierId, Supplier supplier)
        {
            var existingSupplier = await context.Suppliers.FindAsync(supplierId);
            if (existingSupplier == null)
            {
                return null;
            }
            existingSupplier.SuppilerName = supplier.SuppilerName;
            existingSupplier.Email = supplier.Email;
            existingSupplier.quantity = supplier.quantity;
            existingSupplier.DrugId = supplier.DrugId;
            existingSupplier.Drugs = supplier.Drugs;
            await context.SaveChangesAsync();
            return existingSupplier;
        }
    }
}
