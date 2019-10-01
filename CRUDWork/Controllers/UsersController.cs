using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDWork.Entities;
using CRUDWork.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CRUDWork.Controllers
{
    public class UsersController : Controller
    {
        private readonly TaskDBContext _context;

        private readonly IUserService  _userService;
        private readonly IDepartmentService  _departmentService;

        public UsersController(IUserService userService,IDepartmentService departmentService)
        {
            _userService = userService;
            _departmentService = departmentService;
        }
        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _userService.ListUsers());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public async Task<IActionResult> Create()
        {
            var depts = await _departmentService.ListDepartments();
            ViewData["RDepartment"] = new SelectList(depts, "RowId", "Name");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Country,Address,Description,RDepartment")] User user)
        {
            if (ModelState.IsValid)
            {
                await _userService.AddUser(user);                
                return RedirectToAction(nameof(Index));
            }
            ViewData["RDepartment"] = new SelectList(_context.Department, "RowId", "Name", user.RDepartment);
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            var depts = await _departmentService.ListDepartments();
            ViewData["RDepartment"] = new SelectList(depts, "RowId", "Name", user.RDepartment);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("RowId,FirstName,LastName,Country,Address,Description,RDepartment")] User user)
        {
            if (id != user.RowId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {                
                await _userService.UpdateUser(id, user);                                                   
                return RedirectToAction(nameof(Index));
            }
            ViewData["RDepartment"] = new SelectList(_context.Department, "RowId", "Name", user.RDepartment);
            return View(user);
        }
               
        [HttpGet]        
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userService.DeleteUser(id);
            return Json(result);            
        }       
    }
}
