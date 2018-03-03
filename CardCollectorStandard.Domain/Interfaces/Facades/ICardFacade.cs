﻿using CardCollectorStandard.Domain.Dtos;
using System;
using System.Collections.Generic;

namespace CardCollectorStandard.Domain.Interfaces.Facades
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
}
