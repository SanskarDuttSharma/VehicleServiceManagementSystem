using DataAccessLayer.Models;

namespace ServiceLayer.ServiceLayer
{
    public interface IVehicleService
    {
        void Create(Vehicle vehicle);
        void Delete(int id);
        Task<List<Vehicle>> GetDetails();
        void Update(string registrationNumverOfVehicle, Vehicle vehicleToUpdate);
        Vehicle GetDetailsFromRegistrationNumber(string registrationNumber);
    }
}