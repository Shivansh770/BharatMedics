using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BharatMedics.Models
{
    public class Supplier
    {
        [Key]
        public int SuppilerId { get; set; }

        public string SuppilerName { get; set; }

        public string Email { get; set; }

        public int quantity { get; set; }
        public int? DrugId { get; set; }

        [ForeignKey("DrugId")] 
        public virtual Drug Drugs { get; set; }
    }
}
