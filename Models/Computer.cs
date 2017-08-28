using System;
using System.ComponentModel.DataAnnotations;

namespace BangazonHR.Models
{
    public class Computer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Display(Name = "Purchase Date")]
        [Required]
        public DateTime PurchaseDate { get; set; }
        [Display(Name = "Decommision Date")]
        public DateTime DecomissionDate { get; set; }

        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public bool Taken { get; set; }


    
    }
}