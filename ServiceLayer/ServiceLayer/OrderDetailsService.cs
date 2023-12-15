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
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IOrderDAL _orderDAL;

        public OrderDetailsService(IOrderDAL orderDAL)
        {
            _orderDAL = orderDAL;
        }

        public OrderDetail GenerateInvoiceForService(int id, int paymentType, int amount)
        {
            return _orderDAL.GenerateInvoiceForService(id, paymentType, amount);
        }
    }
}
