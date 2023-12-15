using DataAccessLayer.Models;

namespace DataAccessLayer.DAL
{
    public interface IServiceDAL
    {
        void Create(ServiceDetail serviceDetails);
        void Delete(int id);
        List<ServiceDetail> GetDetails();
        void Update(int id, ServiceDetail serviceToUpdate);
        List<ServiceDetail> GetServiceDetailsForVehicle(int vehicleId);
        void GetFeedback(int id, string customerFeedback);
        ServiceDetail SerachServiceDetailsById(int id);
    }
}