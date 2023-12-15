using DataAccessLayer.Models;

namespace DataAccessLayer.DAL
{
    public interface IOrderDAL
    {
        OrderDetail GenerateInvoiceForService(int id, int paymentType, int amount);
    }
}