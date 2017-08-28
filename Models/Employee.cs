using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BangazonHR.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]

        [Required]
        public string LastName { get; set; }
        [Display(Name = "Supervisor")]
        [Required]
        public bool IsSupervisor { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Computer> Computers { get; set; }
        public ICollection<TrainingEmployee> TrainingEmployees { get; set; }

    }
}