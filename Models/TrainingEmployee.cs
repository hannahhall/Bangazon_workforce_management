using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BangazonHR.Models
{
    public class TrainingEmployee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TrainingProgramId { get; set; }
        public TrainingProgram TrainingProgram { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}