using BharatMedics.Models;

namespace BharatMedics.Repository.Doctor
{
    public interface IDoctorLogin
    {
        DoctorReg Login(string username, string password);
      
    }
}
