using AutoMapper;
using WinformsMVPTest.ViewModels;
using WinformsMVPTest.Domain.Dtos;

namespace WinformsMVPTest
{
    public class MVPTestAutoMapperProfile : Profile
    {
        public MVPTestAutoMapperProfile()
        {
            CreateMap<CardResponseDto, CardViewModel>();
        }
    }
}
