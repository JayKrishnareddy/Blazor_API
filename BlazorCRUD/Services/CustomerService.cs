using BlazorCRUD.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BlazorCRUD.Services
{
    public class CustomerService : ICustomerService
    {
        #region Property
        private readonly HttpClient httpClient;
        #endregion

        #region Constructor
        public CustomerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        #endregion

        public async Task<List<Customer>> GetCustomers() => await httpClient.GetJsonAsync<List<Customer>>("api/GetAllCustomer");
        public async Task<string> SaveCustomer(Customer customer)
        {
            if(customer.Id is 0)
            {
                await httpClient.PostJsonAsync("api/CreateCustomer", customer);
                return "Customer Saved";
            }
            else
            {
                await httpClient.PutJsonAsync("api/UpdateCustomer", customer);
                return "Customer Updated";

            }
        }
        public async Task<bool> DeleteCustomer(int Id)
        {
            await httpClient.DeleteAsync($"api/Delete?Id={Id}");
            return true;
        }
    }
}
