using BharatMedics.Models;

namespace BharatMedics.Repository.AdminRepo
{
    public class AdminLogin : IAdminLogin
    {
        Context context;
        public AdminLogin(Context context)
        {
            this.context = context;
        }
        public Admin Login(long phn, string password)
        {
           
           return context.Admins.FirstOrDefault(l => l.PhoneNumber == phn && l.Password == password);
        }
    }
}
