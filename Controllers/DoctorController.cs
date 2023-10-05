using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BharatMedics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        [HttpPost("Doctor_Registration")]
        [AllowAnonymous]
        public ActionResult AddFarmer(Models.Doctor doctor)
        {
            string result = doctorReg.DoctorReg(doctor);
            if (result == "Doctor Added Successfully")
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
