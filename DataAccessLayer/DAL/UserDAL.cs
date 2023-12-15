using DataAccessLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAL
{
    public class UserDAL : IUserDAL
    {
        private readonly VehicleServiceManagementSystemContext _dbContext;

        public UserDAL(VehicleServiceManagementSystemContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetDetailsOfAllCustomers()
        {
            string sqlQuery = "EXECUTE sp_GetCustomers";
            List<User> customers = _dbContext.Users.FromSqlRaw(sqlQuery).ToList();
            return customers;
        }

        public List<User> GetDetailsOfAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public void Create(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            User user = _dbContext.Users.Where(user => user.Id == id).FirstOrDefault();
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public void Update(int id, User userToUpdate)
        {
            User User = _dbContext.Users.Where(user => user.Id == id).FirstOrDefault();
            User.FirstName = userToUpdate.FirstName;
            User.LastName = userToUpdate.LastName;
            User.Email = userToUpdate.Email;
            User.Address = userToUpdate.Address;
            User.Password = userToUpdate.Password;
            User.Status = userToUpdate.Status;
            _dbContext.SaveChanges();
        }

        public List<User> Search(string searchedString)
        {
            List<User> SearchedData = _dbContext.Users.Where(User => User.FirstName.Contains(searchedString)).ToList();
            return SearchedData;
        }

        public void DisableCustomer(int customerId)
        {
            User User = _dbContext.Users.Where(user => user.Id == customerId).FirstOrDefault();
            User.Status = false;
            _dbContext.SaveChanges();
        }

        public void EnableCustomer(int customerId)
        {
            User User = _dbContext.Users.Where(user => user.Id == customerId).FirstOrDefault();
            User.Status = true;
            _dbContext.SaveChanges();
        }
    }
}
