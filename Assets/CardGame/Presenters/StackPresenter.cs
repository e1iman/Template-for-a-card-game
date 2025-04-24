using System.Collections.Generic;
using CardGame.DTOs;
using CardGame.Models;
using CardGame.Views;

namespace CardGame.Presenters
{
    public class StackPresenter
    {
        readonly ICardStack model;
        readonly IStackView view;

        public StackPresenter(IStackView view, ICardStack model)
        {
            this.view = view;
            this.model = model;
        }

        public void Initialize()
        {
            model.CardsUpdated += Model_OnCardsUpdated;
            view.DisplayCards(model.Cards);
        }

        void Model_OnCardsUpdated(IReadOnlyList<Card> cards)
        {
            view.DisplayCards(model.Cards);
        }
    }
}
