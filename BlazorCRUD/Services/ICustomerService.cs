using BlazorCRUD.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorCRUD.Services
{
   public interface ICustomerService
   {
       Task<List<Customer>> GetCustomers();
        Task<bool> SaveCustomer(Customer customer);
   }
}
