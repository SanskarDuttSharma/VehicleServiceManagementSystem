using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ServiceLayer;
using System.Data;

namespace VehicleServiceManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        /// <summary>
        /// Get details an existing vehicles in the system.
        /// </summary>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        [HttpGet]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> Details()
        {
            try
            {
                return Ok(await _vehicleService.GetDetails());
            }
            catch(Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Create a vehicle in the system.
        /// </summary>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Create(Vehicle vehicle)
        {
            try
            {
                _vehicleService.Create(vehicle);
                return Ok("User Added!");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Search a vehicle by registration number in the system.
        /// </summary>
        /// <param name="SearchedString">The required registration number.</param>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult SearchByRegistrationNumber(String SearchedString)
        {
            try
            {
                return Ok(_vehicleService.GetDetailsFromRegistrationNumber(SearchedString));
            }
            catch(Exception exception) 
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Delete an existing vehicle in the system.
        /// </summary>
        /// <param name="id">Id of the Vehicle.</param>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        [HttpDelete]
        [Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            try
            {
                _vehicleService.Delete(id);
                return Ok("Vehicle Deleted!");
            }
            catch(Exception exception) 
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Update an existing vehicle in the system.
        /// </summary>
        /// <param name="vehicle">The vehicle with updated information and registration number.</param>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        [HttpPatch]
        [Authorize(Roles = "1")]
        public IActionResult Update(string registrationNumverOfVehicle, Vehicle vehicle)
        {
            _vehicleService.Update(registrationNumverOfVehicle, vehicle);
            return Ok("Vehicle Data Updated!");
        }
    }
}
