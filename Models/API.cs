using System.Net;

namespace BharatMedics.Models
{
    public class API
    {
        public HttpStatusCode HttpStatus { get; set; }

        public bool IsSuccess = true;

        public List<String> ErrorMessages { get; set; }

        public object Result { get; set; }
    }
}
