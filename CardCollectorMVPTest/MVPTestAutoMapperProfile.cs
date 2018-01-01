using AutoMapper;
using CardCollectorMVPTest.ViewModels;
using CardCollectorStandard.Domain.Dtos;

namespace CardCollectorMVPTest
{
    public class MVPTestAutoMapperProfile : Profile
    {
        public MVPTestAutoMapperProfile()
        {
            CreateMap<CardResponseDto, CardViewModel>();
        }
    }
}
