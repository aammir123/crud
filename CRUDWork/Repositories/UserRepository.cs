using CRUDWork.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDWork.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskDBContext _taskDB;
        public UserRepository(TaskDBContext taskDB)
        {
            _taskDB = taskDB;
        }
        public async Task<IEnumerable<User>> ListUsers()
        {            
            return (await _taskDB.User.Include(u => u.RDepartmentNavigation).ToListAsync());
        }

        public async Task<bool> AddUser(User userToAdd)
        {
            try
            {
                await _taskDB.User.AddAsync(userToAdd);
                await _taskDB.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<User> GetUser(Guid? id)
        {
            var user = await _taskDB.User.Include(u => u.RDepartmentNavigation)
                                         .SingleOrDefaultAsync(m => m.RowId == id);
            return user;
        }

        public async Task<bool> UpdateUser(Guid? id, User userToUpdate)
        {
            try
            {
                var user = await _taskDB.User.Where(e => e.RowId == id).FirstOrDefaultAsync();
                if(user != null)
                {
                    user.FirstName = userToUpdate.FirstName;
                    user.LastName = userToUpdate.LastName;
                    user.Address = userToUpdate.Address;
                    user.Country = userToUpdate.Country;
                    user.Description = userToUpdate.Description;
                    user.RDepartment = userToUpdate.RDepartment;                  

                    _taskDB.Attach(user);
                    _taskDB.Entry(user).Property(e => e.FirstName).IsModified = true;
                    _taskDB.Entry(user).Property(e => e.LastName).IsModified = true;
                    _taskDB.Entry(user).Property(e => e.Address).IsModified = true;
                    _taskDB.Entry(user).Property(e => e.Country).IsModified = true;
                    _taskDB.Entry(user).Property(e => e.Description).IsModified = true;
                    _taskDB.Entry(user).Property(e => e.RDepartment).IsModified = true;

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

        public async Task<bool> DeleteUser(Guid? id)
        {
            try
            {
                var user = await _taskDB.User.Where(e => e.RowId == id).FirstOrDefaultAsync();
                if (user != null)
                {                
                    _taskDB.User.Remove(user);
                    await _taskDB.SaveChangesAsync();
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
