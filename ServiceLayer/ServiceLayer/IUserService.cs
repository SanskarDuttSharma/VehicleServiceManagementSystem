using DataAccessLayer.Models;

namespace ServiceLayer.ServiceLayer
{
    public interface IUserService
    {
        void Create(User user);
        void Delete(int id);
        List<User> GetAllUsers();
        List<User> Search(string searchedString);
        void Update(int id, User userToUpdate);
        List<User> GetDetailsOfAllCustomers();
        void EnableCustomer(int customerId);
        void DisableCustomer(int customerId);
    }
}