using BharatMedics.Repository.SupplierRepo;
using Microsoft.AspNetCore.Mvc;

namespace BharatMedics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : Controller
    {
        private readonly ISupplierRepo supplierRepo;

        public SupplierController(ISupplierRepo _supplierRepo)
        {
            supplierRepo = _supplierRepo;
        }

        #region Get all suppliers

        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var suppliers = await supplierRepo.GetAllSupplierAsync();
            return Ok(suppliers);
        }

        #endregion

        #region Get Specific Supplier
        [HttpGet]
        [Route("{supplierId:int}")]

        public async Task<IActionResult> GetSupplier(int supplierId)
        {
            var supplier = await supplierRepo.GetSupplierAsync(supplierId);
            return Ok(supplier);
        }
        #endregion

        #region Add New Supplier
        [HttpPost]

        public async Task<IActionResult> AddSupplier([FromBody] Models.Supplier supplier)
        {
            var supplierCreate = new Models.Supplier
            {
                SuppilerName = supplier.SuppilerName,
                Email = supplier.Email,
                Drugs = supplier.Drugs,

            };

            await supplierRepo.AddSupplierAsync(supplierCreate);
            return Ok(supplierCreate);

        }

        #endregion

        [HttpPut]
        public async Task<IActionResult> UpdateSupplier(int supplierId, [FromBody] Models.Supplier supplier)
        {
            var existingSupplier = await supplierRepo.GetSupplierAsync(supplierId);
            if(existingSupplier == null)
            {
                return Ok("existing supplpier not found with this id");
            }
            var updateSupplier = await supplierRepo.UpdateSupplierAsync(supplierId, supplier);
            return Ok(updateSupplier);
        }

        [HttpDelete]
        [Route("{supplierId:int}")]
        public async Task<IActionResult> DeleteSupplier(int supplierId)
        {
            var existingDrug = await supplierRepo.GetSupplierAsync(supplierId);
            if(existingDrug == null)
            {
                return Ok("existing supplier not found with this id");
            }
            var deleteSupplier = await supplierRepo.DeleteSupplierAsync(supplierId);
            return Ok(deleteSupplier);

        }

        


    }
}
