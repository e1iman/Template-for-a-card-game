using System;
using System.Collections.Generic;
using CardGame.DTOs;

namespace CardGame.Models
{
    public interface ICardStack
    {
        IReadOnlyList<Card> Cards { get; }
        void Push(Card card);
        bool RemoveCard(Card card);
        event Action<IReadOnlyList<Card>> CardsUpdated;
    }
}
