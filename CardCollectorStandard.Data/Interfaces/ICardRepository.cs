using CardCollectorStandard.Data.Entities;
using System;
using System.Collections.Generic;

namespace CardCollectorStandard.Data.Interfaces
{
    public interface ICardRepository
    {
        IList<Card> GetCardsFromSet(Guid setId);
        IList<CardSet> GetAllCardSets();
        void CreateSet(string SetName, IList<string> cardsToAdd);
        void UpdateSet(Guid setId, string cardToAdd);
        void AddCardToCollection(string cardName);
        void RemoveCardFromCollection(string cardName);
    }
}
