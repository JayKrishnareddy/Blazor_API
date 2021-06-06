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
        public async Task<bool> SaveCustomer(Customer customer)
        {
            await httpClient.PostJsonAsync("api/CreateCustomer", customer);
            return true;
        }
        public async Task<bool> DeleteCustomer(int Id)
        {
            await httpClient.DeleteAsync($"api/Delete?Id={Id}");
            return true;
        }
        public async Task<bool> UpdateCustomer(Customer customer)
        {
            await httpClient.PutJsonAsync("api/UpdateCustomer", customer);
            return true;
        }
    }
}
