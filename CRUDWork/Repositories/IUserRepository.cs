using CRUDWork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDWork.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListUsers();
        Task<bool> AddUser(User userToAdd);
        Task<User> GetUser(Guid? id);
        Task<bool> UpdateUser(Guid? id, User userToUpdate);
        Task<bool> DeleteUser(Guid? id);
    }
}
