using DataAccessLayer.Models;

namespace DataAccessLayer.DAL
{
    public interface IVehicleDAL
    {
        void Create(Vehicle vehicle);
        Vehicle GetDetailsFromRegistrationNumber(string registrationNumber);
        void Delete(int id);
        Task<List<Vehicle>> GetDetails();
        void Update(string registrationNumverOfVehicle, Vehicle vehicleToUpdate);
    }
}