using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAL
{
    public class OrderDAL : IOrderDAL
    {
        private VehicleServiceManagementSystemContext _dbContext;

        public OrderDAL(VehicleServiceManagementSystemContext dbContext)
        {
            _dbContext = dbContext;
        }

        public OrderDetail GenerateInvoiceForService(int id, int paymentType, int amount)
        {
            /* TODO : CHECK THE FUNCTINALITY AGAIN FOR ASYNC*/
            ServiceDetail currentServiceDetails = _dbContext.ServiceDetails.Where(service => service.Id == id).FirstOrDefault();
            OrderDetail orderDetail = new OrderDetail()
            {
                StartDateTime = currentServiceDetails.StartDateTime,
                EndDateTime = currentServiceDetails.EndDateTime,
                ServiceDetailsId = currentServiceDetails.Id,
                PaymentType = paymentType,
                ServiceDetails = currentServiceDetails,
                Amount = amount
            };

            return orderDetail;
        }
    }
}
