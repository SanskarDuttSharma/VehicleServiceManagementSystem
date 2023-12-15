using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAL
{
    public class VehicleDAL : IVehicleDAL
    {
        private VehicleServiceManagementSystemContext _dbContext;

        public VehicleDAL(VehicleServiceManagementSystemContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Vehicle>> GetDetails()
        {
            List<Vehicle> vehicles = await _dbContext.Vehicles.Include(vehicle => vehicle.ServiceDetails).ToListAsync();
            return vehicles;
        }

        public Vehicle GetDetailsFromRegistrationNumber(string registrationNumber)
        {
            return _dbContext.Vehicles.Where(vehicle => vehicle.VehicleRegistrationPlateNumber == registrationNumber).FirstOrDefault();
        }

        public void Create(Vehicle vehicle)
        {
            _dbContext.Vehicles.Add(vehicle);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Vehicle vehicle = _dbContext.Vehicles.Where(vehicle => vehicle.Id == id).FirstOrDefault();
            _dbContext.Vehicles.Remove(vehicle);
            _dbContext.SaveChanges();
        }

        public void Update(string registrationNumverOfVehicle, Vehicle vehicleToUpdate)
        {
            Vehicle vehicle = _dbContext.Vehicles.Where(vehicle => vehicle.VehicleRegistrationPlateNumber == registrationNumverOfVehicle).FirstOrDefault();
            vehicle.ModelName = vehicleToUpdate.ModelName;
            vehicle.VehicleRegistrationPlateNumber = vehicleToUpdate.VehicleRegistrationPlateNumber;
            _dbContext.SaveChanges();
        }
    }
}
