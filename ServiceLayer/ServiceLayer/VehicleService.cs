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
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleDAL _vehicleDAL;

        public VehicleService(IVehicleDAL vehicleDAL)
        {
            _vehicleDAL = vehicleDAL;
        }
        public async Task<List<Vehicle>> GetDetails()
        {
            return await _vehicleDAL.GetDetails();
        }

        public void Create(Vehicle vehicle)
        {
            _vehicleDAL.Create(vehicle);
        }

        public void Delete(int id)
        {
            _vehicleDAL.Delete(id);
        }

        public void Update(string registrationNumverOfVehicle, Vehicle vehicleToUpdate)
        {
            _vehicleDAL.Update(registrationNumverOfVehicle, vehicleToUpdate);
        }
        public Vehicle GetDetailsFromRegistrationNumber(string registrationNumber)
        {
            return _vehicleDAL.GetDetailsFromRegistrationNumber(registrationNumber);
        }

    }
}
