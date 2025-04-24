using System;
using System.Collections.Generic;
using CardGame.DTOs;

namespace CardGame.Models
{
    public interface IBoard
    {
        IReadOnlyList<CardStack> CardStacks { get; }
        event Action<MoveInfo> CardMoved;
        void MoveCard(Card card, int stackIndex);
        void UndoMove();
        bool CanUndoMove();
    }
}
