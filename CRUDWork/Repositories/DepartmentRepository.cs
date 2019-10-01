using CRUDWork.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CRUDWork.Models;
using System;

namespace CRUDWork.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly TaskDBContext _taskDB;
        public DepartmentRepository(TaskDBContext taskDB)
        {
            _taskDB = taskDB;
        }
        public async Task<IEnumerable<DepartmentViewModel>> ListDepartments()
        {
            var result = await _taskDB.Department
                                  .Include(user => user.User)
                                  .Select(e => new DepartmentViewModel
                                  { 
                                    Name= e.Name,
                                    Address = e.Address,
                                    RowId = e.RowId,
                                    Active = (e.Active == 1 ? "Yes" : "No"),
                                    Description = e.Description,
                                    NoOfUsers = e.User.Count()                                    
                                  }).ToListAsync();
            
            return (result);
        }

        public async Task<bool> AddDepartment(Department departmentToAdd)
        {
            try
            {
                await _taskDB.Department.AddAsync(departmentToAdd);
                await _taskDB.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Department> GetDepartment(Guid? id)
        {
            var dept = await _taskDB.Department.Where(e => e.RowId == id).FirstOrDefaultAsync();
            return dept;
        }

        public async Task<bool> UpdateDepartment(Guid? id, Department departmentToUpdate)
        {
            try
            {
                var dept = await _taskDB.Department.Where(e => e.RowId == id).FirstOrDefaultAsync();
                if (dept != null)
                {
                    dept.Name = departmentToUpdate.Name;
                    dept.Description = departmentToUpdate.Description;
                    dept.Address = departmentToUpdate.Address;

                    _taskDB.Attach(dept);
                    _taskDB.Entry(dept).Property(e => e.Name).IsModified = true;
                    _taskDB.Entry(dept).Property(e => e.Description).IsModified = true;
                    _taskDB.Entry(dept).Property(e => e.Address).IsModified = true;

                    await _taskDB.SaveChangesAsync();

                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteDepartment(Guid? id)
        {
            try
            {
                var dept = await _taskDB.Department.Where(e => e.RowId == id).FirstOrDefaultAsync();
                if (dept != null)
                {
                    _taskDB.Department.Remove(dept);
                    await _taskDB.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
