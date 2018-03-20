using AutoMapper;

namespace WinformsMVPTest.Domain.Models
{
	public class CardAutoMapperProfile : Profile
	{
		public CardAutoMapperProfile()
		{
			CreateMap<Data.Entities.CardSet, CardSet>();
			CreateMap<Data.Entities.Card, Card>();
			CreateMap<CardSet, Dtos.SetResponseDto>();
			CreateMap<Card, Dtos.CardResponseDto>();
		}
	}
}
