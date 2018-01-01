using System;
using System.Collections.Generic;
using System.Linq;
using CardCollectorStandard.Domain.Dtos;
using CardCollectorStandard.Domain.Services;
using AutoMapper;

namespace CardCollectorStandard.Domain.Facades
{
    public interface ICardFacade
    {
        void AddCardToCollection(string cardToAdd);
        void RemoveCardFromCollection(string cardToAdd);
        void CreateSet(CreateSetRequestDto request);
        void UpdateSet(UpdateSetRequestDto request);
        IList<SetResponseDto> GetAllCardSets();
        IList<CardResponseDto> GetCardsFromSet(Guid setID);
    }
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
            //TODO: Implement this
        }
    }
}
