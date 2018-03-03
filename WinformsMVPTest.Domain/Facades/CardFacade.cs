using AutoMapper;
using WinformsMVPTest.Domain.Dtos;
using WinformsMVPTest.Domain.Interfaces.Facades;
using WinformsMVPTest.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WinformsMVPTest.Domain.Facades
{
    public class CardFacade : ICardFacade
    {
        public ICardService CardService { get; set; }

        public void AddCardToCollection(string cardToAdd)
        {
            this.CardService.AddCardToCollection(cardToAdd);
        }

        public void CreateSet(CreateSetRequestDto request)
        {
            this.CardService.CreateSet(request.SetName, request.CardsToAdd);
        }

        public IList<SetResponseDto> GetAllCardSets()
        {
            return this.CardService.GetAllCardSets().Select(x => Mapper.Map<SetResponseDto>(x)).ToList();
        }

        public IList<CardResponseDto> GetCardsFromSet(Guid setID)
        {
            return this.CardService.GetCardsFromSet(setID).Select(x => Mapper.Map<CardResponseDto>(x)).ToList();
        }

        public void UpdateSet(UpdateSetRequestDto request)
        {
            this.CardService.UpdateSet(request.SetID, request.CardToAdd);
        }

        public void RemoveCardFromCollection(string cardtoRemove)
        {
            this.CardService.RemoveCardFromCollection(cardtoRemove);
        }
    }
}
