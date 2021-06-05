using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.CustomerService;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        #region Property
        private readonly ICustomerService _customerService;
        #endregion

        #region Constructor
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        #endregion

        #region Get All Data
        /// <summary>
        /// Get All the Cutomer Data from Database
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllCustomer))]
        public IActionResult GetAllCustomer()
        {
            try
            {
                var result = _customerService.GetAllCustomers();
               return result is not null ? Ok(result) : Content("No Data Found");
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region PostData
        /// <summary>
        /// Save record to Database.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost(nameof(CreateCustomer))]
        public IActionResult CreateCustomer([Required]Customer customer)
        {
            try
            {
                _customerService.InsertCustomer(customer); return Ok("File Upload Success");
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// Update recors to Database
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateCustomer))]
        public IActionResult UpdateCustomer(Customer customer)
        {
            try
            {
                _customerService.UpdateCustomer(customer); return Ok("Update done");

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete the record from database.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete(nameof(Delete))]
        public IActionResult Delete(int Id)
        {
            try
            {
                _customerService.DeleteCustomer(Id); return Ok("Deleted Success");
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
