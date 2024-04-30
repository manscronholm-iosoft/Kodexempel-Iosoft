using Kodexempel.Application.Interfaces;
using Kodexempel.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kodexempel.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly KodexempelContext _context;

    public CustomerRepository(KodexempelContext context)
    {
        _context = context;
    }

    public async Task<List<Customer>> GetCustomers()
    {
        return await _context.Customers.ToListAsync();
    }
    
    public async Task UpdateCustomer(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }
}