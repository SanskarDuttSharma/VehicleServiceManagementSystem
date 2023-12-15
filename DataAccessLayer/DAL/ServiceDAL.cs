using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAL
{
    public class ServiceDAL : IServiceDAL
    {
        private VehicleServiceManagementSystemContext _dbContext;

        public ServiceDAL(VehicleServiceManagementSystemContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ServiceDetail> GetDetails()
        {
            return _dbContext.ServiceDetails.Include(service => service.Attendee ).ToList(); //.Include(service => service.Vehicle).
        }

        public void Create(ServiceDetail serviceDetails)
        {
            _dbContext.ServiceDetails.Add(serviceDetails);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            ServiceDetail service = _dbContext.ServiceDetails.Where(service => service.Id == id).FirstOrDefault();
            _dbContext.ServiceDetails.Remove(service);
            _dbContext.SaveChanges();
        }

        public void Update(int id, ServiceDetail serviceToUpdate)
        {
            ServiceDetail service = _dbContext.ServiceDetails.Where(service => service.Id == id).FirstOrDefault();
            service.StartDateTime = serviceToUpdate.StartDateTime;
            service.IssuesMentioned = serviceToUpdate.IssuesMentioned;
            _dbContext.SaveChanges();
        }

        public void GetFeedback(int id, string customerFeedback)
        {
            ServiceDetail service = _dbContext.ServiceDetails.Where(service => service.Id == id).FirstOrDefault();
            service.FeedBack = customerFeedback;
            _dbContext.SaveChanges();
        }

        public List<ServiceDetail> GetServiceDetailsForVehicle(int vehicleId)
        {
            List<ServiceDetail> serviceDetails = _dbContext.ServiceDetails.Where(service => service.VehicleId == vehicleId).ToList();
            return serviceDetails;
        }

        public ServiceDetail SerachServiceDetailsById(int id)
        {
            return _dbContext.ServiceDetails.Where(service => service.Id == id).FirstOrDefault();
        }
    }
}
