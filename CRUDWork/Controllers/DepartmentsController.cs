using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDWork.Entities;
using CRUDWork.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDWork.Controllers
{
    public class DepartmentsController : Controller
    {       

        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _departmentService.ListDepartments();
            return View(list);
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _departmentService.GetDepartment(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Address,Description,Active")] Department department)
        {            
            if (ModelState.IsValid)
            {
                await _departmentService.AddDepartment(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _departmentService.GetDepartment(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("RowId,Name,Address,Description")] Department department)
        {
            if (id != department.RowId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _departmentService.UpdateDepartment(id, department);
                return RedirectToAction(nameof(Index));
            }            
            return View(department);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _departmentService.DeleteDepartment(id);
            return Json(result);
        }        
    }
}
