using AutoMapper;
using WinformsMVPTest.Data.Interfaces;
using WinformsMVPTest.Domain.Interfaces.Services;
using WinformsMVPTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WinformsMVPTest.Domain.Services
{
    public class CardService : ICardService
    {
        public ICardRepository CardRepository { get; set; }

        public void AddCardToCollection(string cardToAdd)
        {
            this.CardRepository.AddCardToCollection(cardToAdd);
        }

        public void CreateSet(string setName, IList<string> cardsToAdd)
        {
            this.CardRepository.CreateSet(setName, cardsToAdd);
        }

        public IList<CardSet> GetAllCardSets()
        {
            return this.CardRepository.GetAllCardSets().Select(x => Mapper.Map<CardSet>(x)).ToList();
        }

        public IList<Card> GetCardsFromSet(Guid setID)
        {
            return this.CardRepository.GetCardsFromSet(setID).Select(x => Mapper.Map<Card>(x)).ToList();
        }

        public void UpdateSet(Guid setID, string cardToAdd)
        {
            this.CardRepository.UpdateSet(setID, cardToAdd);
        }

        public void RemoveCardFromCollection(string cardToRemove)
        {
            this.CardRepository.RemoveCardFromCollection(cardToRemove);
        }
    }
}
