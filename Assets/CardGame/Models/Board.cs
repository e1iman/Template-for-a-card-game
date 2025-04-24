using System;
using System.Collections.Generic;
using CardGame.DTOs;

namespace CardGame.Models
{
    public class Board : IBoard
    {
        readonly List<CardStack> cardStacks;
        readonly Stack<MoveInfo> undoHistory = new();

        public Board(List<CardStack> cardStacks)
        {
            this.cardStacks = cardStacks;
        }

        public event Action<MoveInfo> CardMoved;

        public IReadOnlyList<CardStack> CardStacks => cardStacks;

        public void MoveCard(Card card, int stackIndex)
        {
            MoveInfo? moveInfo = MoveCardInternal(card, stackIndex);
            if (moveInfo.HasValue) {
                undoHistory.Push(moveInfo.Value);
            }
        }

        public void UndoMove()
        {
            if (undoHistory.TryPop(out MoveInfo lastMove)) {
                MoveCardInternal(lastMove.card, lastMove.fromStackIndex);
            }
        }

        public bool CanUndoMove()
        {
            return undoHistory.Count > 0;
        }

        MoveInfo? MoveCardInternal(Card card, int stackIndex)
        {
            foreach (CardStack cardStack in cardStacks) {
                if (cardStack.RemoveCard(card)) {
                    cardStacks[stackIndex].Push(card);
                    var moveInfo = new MoveInfo(card, cardStacks.IndexOf(cardStack), stackIndex);
                    CardMoved?.Invoke(moveInfo);
                    return moveInfo;
                }
            }
            return null;
        }
    }
}
