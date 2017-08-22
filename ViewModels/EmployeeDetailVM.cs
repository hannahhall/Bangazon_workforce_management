using System.Collections.Generic;
using BangazonHR.Models;

namespace BangazonHR.ViewModels
{
    public class EmployeeDetailViewModel
    {
        public Employee Employee { get; set; }

        public List<TrainingProgram>  TrainingPrograms { get; set; }

        public EmployeeDetailViewModel()
        {
            TrainingPrograms = new List<TrainingProgram>();
        }
    }
}