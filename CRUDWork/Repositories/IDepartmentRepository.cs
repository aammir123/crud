using CRUDWork.Entities;
using CRUDWork.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDWork.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<DepartmentViewModel>> ListDepartments();
        Task<bool> AddDepartment(Department departmentToAdd);
        Task<Department> GetDepartment(Guid? id);
        Task<bool> UpdateDepartment(Guid? id, Department departmentToUpdate);
        Task<bool> DeleteDepartment(Guid? id);
    }
}
