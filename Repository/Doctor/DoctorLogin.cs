using BharatMedics.Models;

namespace BharatMedics.Repository.Doctor
{
    public class DoctorLogin : IDoctorLogin
    {
        Context _context;
        public DoctorLogin(Context context)
        {
            this._context = context;
        }

        public Doctor Login(string email, string password)
        {
            return _context.Doctors.Where(l => l.Email.Equals(email) && l.Password.Equals(password)).FirstOrDefault();
        }
    }
}
