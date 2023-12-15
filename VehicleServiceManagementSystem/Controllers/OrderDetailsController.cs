using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ServiceLayer;

namespace VehicleServiceManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderDetailsController : Controller
    {
        private readonly IOrderDetailsService _orderDetailsService;

        public OrderDetailsController(IOrderDetailsService orderDetailsService)
        {
            _orderDetailsService = orderDetailsService;
        }

        /// <summary>
        /// Get the order deatils for a service.
        /// </summary>
        /// <param name="SearchedString">The required registration number.</param>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        [HttpGet("{SearchedString}")]
        [Authorize(Roles = "1")]
        public IActionResult SearchByRegistrationNumber(int serviceDetailsId, int paymentType, int amount)
        {
            try
            {
                return Ok(_orderDetailsService.GenerateInvoiceForService(serviceDetailsId, paymentType, amount));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
