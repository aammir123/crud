using CRUDWork.Entities;
using CRUDWork.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDWork.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentViewModel>> ListDepartments();
        Task<bool> AddDepartment(Department departmentToCreate);
        Task<Department> GetDepartment(Guid? id);
        Task<bool> UpdateDepartment(Guid? id, Department departmentToUpdate);
        Task<bool> DeleteDepartment(Guid? id);
    }
}
