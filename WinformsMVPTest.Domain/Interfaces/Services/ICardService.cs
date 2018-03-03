using WinformsMVPTest.Domain.Models;
using System;
using System.Collections.Generic;

namespace WinformsMVPTest.Domain.Interfaces.Services
{
    public interface ICardService
    {
        void AddCardToCollection(string cardToAdd);
        void RemoveCardFromCollection(string cardToRemove);
        void CreateSet(string setName, IList<string> cardsToAdd);
        IList<CardSet> GetAllCardSets();
        IList<Card> GetCardsFromSet(Guid setID);
        void UpdateSet(Guid setID, string cardToAdd);
    }
}
