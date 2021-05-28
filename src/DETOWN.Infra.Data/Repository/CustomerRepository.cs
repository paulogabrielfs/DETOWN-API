using System.Linq;
using DETOWN.Domain.Interfaces;
using DETOWN.Domain.Models;
using DETOWN.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DETOWN.Infra.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public Customer GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}