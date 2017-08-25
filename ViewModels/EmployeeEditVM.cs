using System.Collections.Generic;
using System.Linq;
using BangazonHR.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BangazonHR.ViewModels
{
    public class EmployeeEditViewModel
    {
        public Employee Employee { get; set; }

        public List<TrainingProgram> TrainingPrograms { get; set; }

        public List<Computer> Computers { get; set; }

        public int ComputerId { get; set; }

        public EmployeeEditViewModel()
        {
            TrainingPrograms = new List<TrainingProgram>();
            Computers = new List<Computer>();
        }
    }
}