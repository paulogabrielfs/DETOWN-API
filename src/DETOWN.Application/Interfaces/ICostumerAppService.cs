using System;
using System.Collections.Generic;
using DETOWN.Application.EventSourcedNormalizers;
using DETOWN.Application.ViewModels;

namespace DETOWN.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        void Register(CustomerViewModel customerViewModel);
        IEnumerable<CustomerViewModel> GetAll();
        IEnumerable<CustomerViewModel> GetAll(int skip, int take);
        CustomerViewModel GetById(Guid id);
        void Update(CustomerViewModel customerViewModel);
        void Remove(Guid id);
        IList<CustomerHistoryData> GetAllHistory(Guid id);
    }
}
