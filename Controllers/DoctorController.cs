using BharatMedics.Repository.Doctor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BharatMedics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorReg doctorReg;
        public DoctorController(IDoctorReg _doctorReg)
        {
            doctorReg = _doctorReg;
        }

        [HttpPost("Doctor_Registration")]
        [AllowAnonymous]
        public ActionResult AddFarmer(Models.Doctor doctor)
        {
            string result = doctorReg.DoctorRegister(doctor);
            if (result == "Doctor Added Successfully")
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
