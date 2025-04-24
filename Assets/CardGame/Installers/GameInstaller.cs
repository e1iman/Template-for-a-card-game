using System.Collections.Generic;
using System.Linq;
using CardGame.DTOs;
using CardGame.Extensions;
using CardGame.Models;
using CardGame.Presenters;
using CardGame.Views;
using UnityEngine;

namespace CardGame.Installers
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField]
        BoardView boardView;

        [SerializeField]
        StackView stackViewPrefab;

        [SerializeField]
        Transform stackViewsContainer;

        Board board;

        void Start()
        {
            var cardStacks = new List<CardStack> {
                new(new List<Card> {
                    new(CardValue.Ace, CardSuit.Clubs),
                    new(CardValue.Two, CardSuit.Clubs),
                    new(CardValue.Three, CardSuit.Clubs),
                    new(CardValue.Four, CardSuit.Clubs)
                }),
                new(new List<Card> {
                    new(CardValue.Ace, CardSuit.Diamonds),
                    new(CardValue.Two, CardSuit.Diamonds),
                    new(CardValue.Three, CardSuit.Diamonds)
                }),
                new(new List<Card> {
                    new(CardValue.Ace, CardSuit.Hearts),
                    new(CardValue.Two, CardSuit.Hearts)
                }),
                new(new List<Card> {
                    new(CardValue.Ace, CardSuit.Spades)
                }),
                new(new List<Card>())
            };

            var moveValidations = new List<IMoveValidation>() {
                new DefaultMoveValidation(),
            };

            board = new Board(cardStacks, moveValidations);

            var boardPresenter = new BoardPresenter(boardView, board);

            foreach (Transform child in stackViewsContainer) {
                Destroy(child.gameObject);
            }

            foreach (CardStack cardStack in board.CardStacks) {
                StackView stackView = Instantiate(stackViewPrefab, stackViewsContainer);
                var stackPresenter = new StackPresenter(stackView, cardStack);
                stackPresenter.Initialize();
            }
            boardPresenter.Initialize();
        }

        // Debug random move
        public void MakeRandomMove()
        {
            CardStack randomStackWithCards = board.CardStacks.GetRandomElement(s => s.Cards.Count > 0);
            Card cardToMove = randomStackWithCards.Cards.Last();
            while (true) {
                int stackIndex = Random.Range(0, board.CardStacks.Count);
                if (board.CardStacks[stackIndex].Cards.Contains(cardToMove)) {
                    continue;
                }
                board.MoveCard(cardToMove, stackIndex);
                return;
            }
        }
    }
}
