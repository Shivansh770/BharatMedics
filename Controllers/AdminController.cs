using BharatMedics.Models;
using BharatMedics.Repository.AdminRepo;
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
        public AdminController(IAdminReg adminReg)
        {
            this.adminReg = adminReg;
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
    }
}
