using Kodexempel.Domain;

namespace Kodexempel.Application.Interfaces;

public interface ICustomerRepository
{
    Task<List<Customer>> GetCustomers();
    Task UpdateCustomer(Customer customer);
}