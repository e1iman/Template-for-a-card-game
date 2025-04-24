using System.Collections.Generic;
using CardGame.DTOs;

namespace CardGame.Views
{
    public interface IStackView
    {
        void DisplayCards(IReadOnlyList<Card> cards);
    }
}
