using DETOWN.Domain.Models;

namespace DETOWN.Domain.Specifications
{
    public class CustomerFilterPaginatedSpecification : BaseSpecification<Customer>
    {
        public CustomerFilterPaginatedSpecification(int skip, int take)
            : base(i => true)
        {
            ApplyPaging(skip, take);
        }
    }
}
