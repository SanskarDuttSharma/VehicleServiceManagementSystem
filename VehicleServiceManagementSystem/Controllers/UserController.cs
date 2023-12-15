using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Data;

namespace VehicleServiceManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get details an existing users in the system.
        /// </summary>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        [HttpGet]
        [Authorize(Roles = "1")]

        public IActionResult Details()
        {
            try
            {
                return Ok(_userService.GetAllUsers());
            }
            catch(Exception exception) 
            { 
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Get details an existing customers in the system.
        /// </summary>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult DetailsOfCustomers()
        {
            try
            {
                return Ok(_userService.GetDetailsOfAllCustomers());
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Create a User in the system.
        /// </summary>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Create(User user)
        {
            try
            {
                _userService.Create(user);
                return Ok("User Added!");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }


        /// <summary>
        /// Search a user by name in the system.
        /// </summary>
        /// <param name="SearchedString">The required name.</param>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult SearchByName(String SearchedString)
        {
            try
            {
                return Ok(_userService.Search(SearchedString));
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }

        /// <summary>
        /// Delete an existing user in the system.
        /// </summary>
        /// <param name="id">Id of the user.</param>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        [HttpDelete]
        [Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            try
            {
                _userService.Delete(id);
                return Ok("User Deleted!");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Update an existing user in the system.
        /// </summary>
        /// <param name="user">The user with updated information and id of user.</param>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        [HttpPatch]
        [Authorize(Roles = "1")]
        public IActionResult Update(int idOfUser, User user)
        {
            try
            {
                _userService.Update(idOfUser, user);
                return Ok("Data Updated!");
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }

        /// <summary>
        /// Enable an existing user in the system.
        /// </summary>
        /// <param name="customerId">Id of user.</param>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        [HttpPatch]
        [Authorize(Roles = "1")]
        public IActionResult Enable(int customerId)
        {
            try
            {
                _userService.EnableCustomer(customerId);
                return Ok("User Enabled!");
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }

        /// <summary>
        /// Disable an existing user in the system.
        /// </summary>
        /// <param name="customerId">Id of user.</param>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        [HttpPatch]
        [Authorize(Roles = "1")]
        public IActionResult Disable (int customerId)
        {
            try
            {
                _userService.DisableCustomer(customerId);
                return Ok("User Disabled!");
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }
    }
}
