using CRUDWork.Entities;
using CRUDWork.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDWork.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        //private readonly ModelStateDictionary  _modelState;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            //_modelState = modelState;
        }
        public async Task<IEnumerable<User>> ListUsers()
        {
            return (await _userRepository.ListUsers());
        }
        //protected bool ValidateDepartment(Department departmentToValidate)
        //{
        //    if (departmentToValidate.Name.Trim().Length == 0)
        //        _modelState.AddModelError("Name", "Name is required.");           
        //    return _modelState.IsValid;
        //}
        public async Task<bool> AddUser(User userToCreate)
        {

            //if (!ValidateDepartment(departmentToCreate))
            //    return false;          
            try
            {
                await _userRepository.AddUser(userToCreate);
            }
            catch
            {
                return false;
            }
            return true;
        }        
        public async Task<bool> UpdateUser(Guid? id, User userToUpdate)
        {
            try
            {
                await _userRepository.UpdateUser(id, userToUpdate);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public async Task<User> GetUser(Guid? id)
        {
            return (await _userRepository.GetUser(id));
        }
        public async Task<bool> DeleteUser(Guid? id)
        {
            try
            {
                await _userRepository.DeleteUser(id);
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}
