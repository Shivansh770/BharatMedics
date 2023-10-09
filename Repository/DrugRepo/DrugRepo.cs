using BharatMedics.Models;
using Microsoft.EntityFrameworkCore;

namespace BharatMedics.Repository.DrugRepo
{
    public class DrugRepo : IDrugRepo
    {
        Context context;

        public DrugRepo(Context context)
        {
            this.context = context;
        }
        public async Task<Drug> AddAsync(Drug drug)
        {
            await context.Drugs.AddAsync(drug);
            await context.SaveChangesAsync();
            return drug;
        }

        public async Task<Drug> DeleteAsync(int id) 
        {
            var existingDrug = await context.Drugs.FindAsync(id);
            if (existingDrug == null)
            {
                return null;
            }
            context.Drugs.Remove(existingDrug);
            await context.SaveChangesAsync();
            return existingDrug;
        }

        public async Task<IEnumerable<Drug>> GetAllAsync()
        {
            return await context.Drugs.ToListAsync();
        }

        public async Task<Drug> GetAsync(int id)
        {
            return await context.Drugs.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Drug> UpdateAsync(int id, Drug drug)
        {
            var existingDrug = await context.Drugs.FindAsync(id);
            if (existingDrug == null)
            {
                return null;
            }
            existingDrug.DrugName = drug.DrugName;
            existingDrug.Price = drug.Price;
            existingDrug.DateCreated = drug.DateCreated;
            existingDrug.ExpiryDate = drug.ExpiryDate;
            await context.SaveChangesAsync();
            return existingDrug;
        }
    }
}
