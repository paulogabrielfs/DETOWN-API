using System;
using System.Collections.Generic;
using DETOWN.Application.EventSourcedNormalizers;
using DETOWN.Application.ViewModels;

namespace DETOWN.Application.Interfaces
{
    public interface INewsAppService : IDisposable
    {
        void Register(NewsViewModel newsViewModel);

        IEnumerable<NewsViewModel> GetAll();

        //IEnumerable<NewsViewModel> GetAll(int skip, int take);

        //NewsViewModel GetById(Guid id);

        //void update(NewsViewModel newsViewModel);

        //void remove(Guid id);

        //IList<NewsHistoryData> GetAllHistory(Guid id);
    }
}