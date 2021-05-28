using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DETOWN.Application.EventSourcedNormalizers;
using DETOWN.Application.Interfaces;
using DETOWN.Application.ViewModels;
using DETOWN.Domain.Commands;
using DETOWN.Domain.Core.Bus;
using DETOWN.Domain.Interfaces;
using DETOWN.Domain.Specifications;
using DETOWN.Infra.Data.Repository.EventSourcing;

namespace DETOWN.Application.Services
{
    public class NewsAppService : INewsAppService
    {
        private readonly IMapper _mapper;
        private readonly INewsRepository _newsRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public NewsAppService(IMapper mapper, INewsRepository newsRepository, IMediatorHandler bus, IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _newsRepository = newsRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<NewsViewModel> GetAll()
        {
            return _newsRepository.GetAll().ProjectTo<NewsViewModel>(_mapper.ConfigurationProvider);
        }

        public void Register(NewsViewModel newsViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewCustomerCommand>(newsViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}