using BharatMedics.Models;

namespace BharatMedics.Repository.AdminRepo
{
    public interface IAdminLogin
    {
        Admin Login(long phn, string password);
    }
}
