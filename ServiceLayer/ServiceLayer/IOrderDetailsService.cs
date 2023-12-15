using DataAccessLayer.Models;

namespace ServiceLayer.ServiceLayer
{
    public interface IOrderDetailsService
    {
        OrderDetail GenerateInvoiceForService(int id, int paymentType, int amount);
    }
}