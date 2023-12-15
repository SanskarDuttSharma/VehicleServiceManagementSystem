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
    public class ServiceDetailsService : IServiceDetailsService
    {
        private readonly IServiceDAL _serviceDAL;

        public ServiceDetailsService(IServiceDAL serviceDAL)
        {
            _serviceDAL = serviceDAL;
        }

        public List<ServiceDetail> GetDetails()
        {
            return _serviceDAL.GetDetails();
        }

        public void Create(ServiceDetail serviceDetails)
        {
            _serviceDAL.Create(serviceDetails);
        }

        public void Delete(int id)
        {
            _serviceDAL.Delete(id);
        }

        public void Update(int id, ServiceDetail serviceToUpdate)
        {
            _serviceDAL.Update(id, serviceToUpdate);
        }

        public void GetFeedback(int id, string customerFeedback)
        {
            _serviceDAL.GetFeedback(id, customerFeedback);
        }

        public List<ServiceDetail> GetServiceDetailsForVehicle(int vehicleId)
        {
            return _serviceDAL.GetServiceDetailsForVehicle(vehicleId);
        }

        public ServiceDetail SerachServiceDetailsById(int id)
        {
            return _serviceDAL.SerachServiceDetailsById(id);
        }
    }
}
