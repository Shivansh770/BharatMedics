using BharatMedics.Models;
using Microsoft.EntityFrameworkCore;

namespace BharatMedics.Repository.AdminRepo
{
    public class adminReg : IAdminReg
    {
        Context _context;
        public adminReg(Context context)
        {
            _context = context;
        }

        public string AdminReg(Admin admin)
        {
            try
            {
                long phn = admin.PhoneNumber;
                if (_context.Admins.Any(a => a.PhoneNumber == phn))
                {
                    string error = "Admin already exist";
                    return error;
                }
                _context.Admins.Add(admin);
                _context.SaveChanges();
                return "Admin Added Successfully";
            }
            catch (Exception ex)
            {
                return "Not Able To Add admin Retry";
            }
        }
    }
}
