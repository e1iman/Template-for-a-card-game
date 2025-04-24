using System;
using System.Collections.Generic;
using CardGame.DTOs;

namespace CardGame.Models
{
    public class CardStack : ICardStack
    {
        readonly List<Card> cards;

        public CardStack(List<Card> cards)
        {
            this.cards = cards;
        }

        public IReadOnlyList<Card> Cards => cards;

        public void Push(Card card)
        {
            cards.Add(card);
            CardsUpdated?.Invoke(cards);
        }

        public bool RemoveCard(Card card)
        {
            bool result = cards.Remove(card);
            if (result) {
                CardsUpdated?.Invoke(cards);
            }
            return result;
        }

        public event Action<IReadOnlyList<Card>> CardsUpdated;
    }
}
