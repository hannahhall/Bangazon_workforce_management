using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BangazonHR.Data;
using BangazonHR.Models;
using BangazonHR.ViewModels;

namespace BangazonHR.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly BangazonContext _context;

        public EmployeeController(BangazonContext context)
        {
            _context = context;    
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            var bangazonContext = _context.Employee.Include(e => e.Department);
            return View(await bangazonContext.ToListAsync());
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vm = new EmployeeDetailViewModel();
            vm.Employee = await _context.Employee
                .Include(e => e.Department)
                .Include(e => e.Computers)
                .Include(e => e.TrainingEmployees)
                .SingleOrDefaultAsync(m => m.Id == id);
            
            foreach (var training in vm.Employee.TrainingEmployees)
            {
                TrainingProgram program = await _context.TrainingProgram
                    .SingleOrDefaultAsync(t => t.Id == training.TrainingProgramId);
                vm.TrainingPrograms.Add(program);
            }
            
            if (vm.Employee == null)
            {
                return NotFound();
            }

            return View(vm);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Name");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,IsSupervisor,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vm = new EmployeeEditViewModel((int) id, _context);
            vm.Employee = await _context.Employee
                .Include(e => e.Department)
                .Include(e => e.Computers)
                .Include(e => e.TrainingEmployees)
                    .ThenInclude(t => t.TrainingProgram)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (vm.Employee == null)
            {
                return NotFound();
            }
            
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Name", vm.Employee.DepartmentId);
            // ViewData["ComputerId"] = new SelectList(vm.Computers, "Id", "Model");
            return View(vm);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeEditViewModel vm)
        {
            if (id != vm.Employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(vm.Employee);
                    
                    Computer oldComputer = _context.Computer.SingleOrDefault(c => c.EmployeeId == id);
                    Computer newComputer = _context.Computer.SingleOrDefault(c => c.Id == vm.ComputerId[0]);
                    if (oldComputer != newComputer)
                    {
                        oldComputer.EmployeeId = null;
                        newComputer.EmployeeId = id;
                        _context.Update(newComputer);
                        _context.Update(oldComputer);
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(vm.Employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Name", vm.Employee.DepartmentId);
            return View(vm);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Department)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.SingleOrDefaultAsync(m => m.Id == id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}
