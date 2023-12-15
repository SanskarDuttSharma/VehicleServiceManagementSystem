using DataAccessLayer.Models;

namespace DataAccessLayer.DAL
{
    public interface IUserDAL
    {
        void Create(User user);
        void Delete(int id);
        List<User> GetDetailsOfAllUsers();
        List<User> Search(string searchedString);
        void Update(int id, User userToUpdate);
        List<User> GetDetailsOfAllCustomers();
        void EnableCustomer(int customerId);
        void DisableCustomer(int customerId);
    }
}