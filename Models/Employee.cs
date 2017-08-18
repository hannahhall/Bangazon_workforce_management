using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BangazonHR.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public bool IsSupervisor { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public Department Department { get; set; }
        public ICollection<Computer> Computers { get; set; }
        public ICollection<TrainingEmployee> TrainingEmployees { get; set; }

    }
}