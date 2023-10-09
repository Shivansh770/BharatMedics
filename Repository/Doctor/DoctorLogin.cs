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

        public Models.Doctor Login(string email, string pwd)
        {
            return _context.Doctors.FirstOrDefault(l => l.Email.Equals(email) && l.Password.Equals(pwd));
        }
    }
}
