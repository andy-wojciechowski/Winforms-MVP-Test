﻿using System;
using System.Collections.Generic;
using System.Linq;
using CardCollectorStandard.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardCollectorStandard.Data
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
    public class CardRepository : ICardRepository
    {
        private CardContext DataContext { get; set; }

        public CardRepository()
        {
            this.DataContext = new CardContext(new DbContextOptions<CardContext>());
        }

        public void AddCardToCollection(string cardName)
        {
            var cardToUpdate = (from card in DataContext.Cards
                                where card.Name == cardName
                                select card).FirstOrDefault();
            DataContext.Update(cardToUpdate);
            cardToUpdate.IsOwned = true;
            DataContext.SaveChanges();
        }

        public void CreateSet(string SetName, IList<string> cardsToAdd)
        {
            var setId = Guid.NewGuid();
            DataContext.CardSets.Add(new CardSet
            {
                ID = setId,
                Name = SetName
            });
            DataContext.SaveChanges();

            foreach(var card in cardsToAdd)
            {
                DataContext.Cards.Add(new Card
                {
                    SetID = setId,
                    Name = card,
                    IsOwned = false
                });
            }

            DataContext.SaveChanges();
        }

        public IList<CardSet> GetAllCardSets()
        {
            return DataContext.CardSets.ToList();
        }

        public IList<Card> GetCardsFromSet(Guid setId)
        {
            return (from card in DataContext.Cards
                    where card.SetID == setId
                    select card).ToList();
        }

        public void UpdateSet(Guid setId, string cardToAdd)
        {
            DataContext.Cards.Add(new Card
            {
                SetID = setId,
                Name = cardToAdd,
                IsOwned = false
            });
            DataContext.SaveChanges();
        }

        public void RemoveCardFromCollection(string cardName)
        {
            var cardToUpdate = (from card in DataContext.Cards
                                where card.Name == cardName
                                select card).FirstOrDefault();
            DataContext.Update(cardToUpdate);
            cardToUpdate.IsOwned = false;
            DataContext.SaveChanges();
        }
    }
}
