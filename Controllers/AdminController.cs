using BharatMedics.Models;
using BharatMedics.Repository.AdminRepo;
using BharatMedics.Repository.DrugRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BharatMedics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IAdminReg adminReg;
        private readonly IDrugRepo drugRepo;
        public AdminController(IAdminReg adminReg, IDrugRepo _drugrepo)
        {
            this.adminReg = adminReg;
            drugRepo = _drugrepo;
        }

        [HttpPost("Admin_Registration")]
        [AllowAnonymous]
        public ActionResult AddAdmin(Admin admin)
        {
            string result = adminReg.AdminReg(admin);
            if (result == "Admin Added Successfully")
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDrugsAsync()
        {
            var drugs = await drugRepo.GetAllAsync();
            return Ok(drugs);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetDrugAsync(int id)
        {
            var drug = await drugRepo.GetAsync(id);
            return Ok(drug);
        }

        [HttpPost]
        public async Task<IActionResult> AddDrugAsync([FromBody] Models.Drug drug)
        {
            var drugCreate = new Models.Drug
            {
                DrugName = drug.DrugName,
                Price = drug.Price,
                DateCreated = drug.DateCreated,
                ExpiryDate = drug.ExpiryDate
            };

            await drugRepo.AddAsync(drugCreate);
            return Ok(drugCreate);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDrugAsync(int id, [FromBody] Drug drug)
        {
            var existingDrug = await drugRepo.GetAsync(id);
            if(existingDrug == null)
            {
                return Ok("existing drug not found with this id");
            }
            var updateDrug = await drugRepo.UpdateAsync(id, drug);
            return Ok(updateDrug);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteDrugAsync(int id)
        {
            var existingDrug = await drugRepo.GetAsync(id);
            if (existingDrug == null)
            {
                return Ok("existing drug not found with this id");
            }
            var deleteDrug = await drugRepo.DeleteAsync(id);
            return Ok(deleteDrug);
        }
    }
}
