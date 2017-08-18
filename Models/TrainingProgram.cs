using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BangazonHR.Models
{
    public class TrainingProgram
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Start Date")]
        [Required]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [Required]
        public DateTime EndDate { get; set; }
        public ICollection<TrainingEmployee> TrainingEmployees{ get; set; }
    }
}