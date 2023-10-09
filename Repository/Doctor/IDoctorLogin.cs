using BharatMedics.Models;

namespace BharatMedics.Repository.Doctor
{
    public interface IDoctorLogin
    {
        Models.Doctor Login(string username, string password);
      
    }
}
