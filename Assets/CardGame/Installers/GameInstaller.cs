using System.Collections.Generic;
using CardGame.DTOs;
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

            var board = new Board(cardStacks);

            var boardPresenter = new BoardPresenter(boardView, board);

            foreach (Transform child in stackViewsContainer) {
                Destroy(child.gameObject);
            }
            
            foreach (CardStack cardStack in board.CardStacks) {
                var stackView = Instantiate(stackViewPrefab, stackViewsContainer);
                var stackPresenter = new StackPresenter(stackView, cardStack);
                stackPresenter.Initialize();
            }
            boardPresenter.Initialize();
        }
    }
}
