using System;
using System.Collections.Generic;
using System.Linq;
using CardGame.Common;
using CardGame.DTOs;

namespace CardGame.Models
{
    public class Board : IBoard
    {
        readonly List<CardStack> cardStacks;
        readonly List<IMoveValidation> moveValidations;
        readonly Stack<MoveInfo> undoHistory = new();

        public Board(List<CardStack> cardStacks, List<IMoveValidation> moveValidations)
        {
            this.cardStacks = cardStacks;
            this.moveValidations = moveValidations;
        }

        public event Action<MoveInfo> CardMoved;

        public IReadOnlyList<CardStack> CardStacks => cardStacks;

        public Result<MoveInfo> TryMoveCard(Card card, int targetMoveStackIndex)
        {
            var moveInfo = MoveCardInternal(card, targetMoveStackIndex).OnSuccess(move => {
                undoHistory.Push(move);
                CardMoved?.Invoke(move);
            });
            return moveInfo;
        }

        public void UndoMove()
        {
            if (undoHistory.TryPop(out MoveInfo lastMove)) {
                MoveCardInternal(lastMove.card, lastMove.fromStackIndex).OnSuccess(CardMoved);
            }
        }

        public bool CanUndoMove()
        {
            return undoHistory.Count > 0;
        }

        Result<MoveInfo> MoveCardInternal(Card card, int stackIndex)
        {
            if (moveValidations.Any(r => !r.CanPerformMove(card, stackIndex))) {
                return Result<MoveInfo>.Failure("Move is not allowed");
            }
            
            foreach (CardStack cardStack in cardStacks) {
                if (cardStack.RemoveCard(card)) {
                    cardStacks[stackIndex].Push(card);
                    var moveInfo = new MoveInfo(card, cardStacks.IndexOf(cardStack), stackIndex);
                    return moveInfo.ToResult();
                }
            }
            return Result<MoveInfo>.Failure("Card is not present in any of a stack");
        }
    }
}
