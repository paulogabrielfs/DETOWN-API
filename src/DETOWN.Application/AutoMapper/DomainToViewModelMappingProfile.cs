using AutoMapper;
using DETOWN.Application.ViewModels;
using DETOWN.Domain.Models;

namespace DETOWN.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<News, NewsViewModel>();
        }
    }
}
