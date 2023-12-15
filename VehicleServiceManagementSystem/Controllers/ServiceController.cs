using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ServiceLayer;
using System.Data;

namespace VehicleServiceManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ServiceController : Controller
    {
        private readonly IServiceDetailsService _serviceDetailsService;

        public ServiceController(IServiceDetailsService serviceDetailsService)
        {
            _serviceDetailsService= serviceDetailsService;
        }

        /// <summary>
        /// Get details an existing services in the system.
        /// </summary>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult ServiceDetails()
        {
            try
            {
                return Ok(_serviceDetailsService.GetDetails());
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Get details an existing service for a vehicle in the system.
        /// </summary>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        [HttpGet("id")]
        [Authorize(Roles = "1")]
        public IActionResult ServiceDetailsByVehicleId(int id)
        {
            try
            {
                return Ok(_serviceDetailsService.GetServiceDetailsForVehicle(id));
            }
            catch(Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Create a service in the system.
        /// </summary>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Create(ServiceDetail serviceDetail)
        {
            try
            {
                _serviceDetailsService.Create(serviceDetail);
                return Ok("Service Added!");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Search a service by service id in the system.
        /// </summary>
        /// <param name="id">The required id.</param>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult SearchByServiceId(int id)
        {
            try
            {
                return Ok(_serviceDetailsService.SerachServiceDetailsById(id));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Delete an existing service Details in the system.
        /// </summary>
        /// <param name="id">Id of the service.</param>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        [HttpDelete]
        [Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            try
            {
                _serviceDetailsService.Delete(id);
                return Ok("Service Deleted!");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Update an existing service in the system.
        /// </summary>
        /// <param name="service">The service with updated information and id.</param>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        [HttpPatch]
        [Authorize(Roles = "1")]
        public IActionResult Update(int id, ServiceDetail service)
        {
            _serviceDetailsService.Update(id, service);
            return Ok("Service Data Updated!");
        }
    }
}
