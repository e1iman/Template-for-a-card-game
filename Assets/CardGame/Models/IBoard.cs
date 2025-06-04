using System;
using System.Collections.Generic;
using CardGame.Common;
using CardGame.DTOs;

namespace CardGame.Models
{
    public interface IBoard
    {
        IReadOnlyList<CardStack> CardStacks { get; }
        event Action<MoveInfo> CardMoved;
        Result<MoveInfo> TryMoveCard(Card card, int targetMoveStackIndex);
        void UndoMove();
        bool CanUndoMove();
    }
}
