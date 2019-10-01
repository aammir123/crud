using CRUDWork.Entities;
using CRUDWork.Models;
using CRUDWork.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDWork.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        //private readonly ModelStateDictionary  _modelState;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
            //_modelState = modelState;
        }
        public async Task<IEnumerable<DepartmentViewModel>> ListDepartments()
        {
            return (await _departmentRepository.ListDepartments());
        }
        //protected bool ValidateDepartment(Department departmentToValidate)
        //{
        //    if (departmentToValidate.Name.Trim().Length == 0)
        //        _modelState.AddModelError("Name", "Name is required.");           
        //    return _modelState.IsValid;
        //}
        public async Task<bool> AddDepartment(Department departmentToCreate)
        {
            
            //if (!ValidateDepartment(departmentToCreate))
            //    return false;          
            try
            {
                await _departmentRepository.AddDepartment(departmentToCreate);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<Department> GetDepartment(Guid? id)
        {
            return (await _departmentRepository.GetDepartment(id));
        }

        public async Task<bool> UpdateDepartment(Guid? id, Department departmentToUpdate)
        {
            try
            {
                await _departmentRepository.UpdateDepartment(id, departmentToUpdate);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteDepartment(Guid? id)
        {
            try
            {
                var result = await _departmentRepository.DeleteDepartment(id);
                return result;
            }
            catch
            {
                return false;
            }            
        }
    }
}
