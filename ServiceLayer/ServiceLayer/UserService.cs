using DataAccessLayer.DAL;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ServiceLayer
{
    public class UserService : IUserService
    {
        private readonly IUserDAL _userDAL;

        public UserService(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public List<User> GetAllUsers()
        {
            return _userDAL.GetDetailsOfAllUsers();
        }

        public List<User> GetDetailsOfAllCustomers()
        {
            return _userDAL.GetDetailsOfAllCustomers();
        }

        public void Create(User user)
        {
            _userDAL.Create(user);
        }

        public void Delete(int id)
        {
            _userDAL.Delete(id);
        }

        public void Update(int id, User userToUpdate)
        {
            _userDAL.Update(id, userToUpdate);
        }

        public List<User> Search(string searchedString)
        {
            return _userDAL.Search(searchedString);
        }

        public void DisableCustomer(int customerId)
        {
            _userDAL.DisableCustomer(customerId);
        }

        public void EnableCustomer(int customerId)
        {
            _userDAL.EnableCustomer(customerId);
        }
    }
}
