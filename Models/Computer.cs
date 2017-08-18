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
        [Required]
        public DateTime PurchaseDate { get; set; }
       
        public DateTime DecomissionDate { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }


    
    }
}