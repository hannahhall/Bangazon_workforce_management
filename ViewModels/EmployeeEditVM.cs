using System.Collections.Generic;
using System.Linq;
using BangazonHR.Models;
using BangazonHR.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BangazonHR.ViewModels
{
    public class EmployeeEditViewModel
    {
        public Employee Employee { get; set; }

        public List<TrainingProgram> TrainingPrograms { get; set; }

        public SelectList Computers { get; set; }
        [Display(Name = "Computer")]
        public int[] ComputerId { get; set; }

        public EmployeeEditViewModel() {}

        public EmployeeEditViewModel(int id, BangazonContext context)
        {
            // TrainingPrograms = new List<TrainingProgram>();
            // ComputerIds = new int[1];
            Computer[] computers = context.Computer.Where(c => c.EmployeeId == null || c.EmployeeId == id).ToArray();
            ComputerId = context.Computer.Where(c => c.EmployeeId == id).Select(c => c.Id).ToArray();
            Computers = new SelectList(computers, "Id", "Model", ComputerId[0]);
        }
    }
}