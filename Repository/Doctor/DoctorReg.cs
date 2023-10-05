using BharatMedics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BharatMedics.Repository.Doctor
{
    public class DoctorReg : IDoctorReg
    {
        Context _context;

        public DoctorReg(Context context)
        {
            _context = context;
        }

        public string Doctor(Doctor doctor)
        {
            try
            {
                string email = doctor.Email;
                if(_context.Doctors.Any(a => a.Email == email))
                {
                    string error = "Doctor already exist";
                    return error;
                }
                _context.Doctors.Add(doctor);
                _context.SaveChanges();
                return "Doctor Added Successfully";
            }
            catch (Exception ex)
            {
                return "Not able to Add the Doctor Retry";
            }
        }

       
    }
}
