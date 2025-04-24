using System.Collections.Generic;
using CardGame.DTOs;
using UnityEngine;

namespace CardGame.Views
{
    public class StackView : MonoBehaviour, IStackView
    {
        [SerializeField]
        CardView cardViewPrefab;

        [SerializeField]
        Transform cardsContainer;

        public void DisplayCards(IReadOnlyList<Card> cards)
        {
            foreach (Transform child in transform) {
                Destroy(child.gameObject);
            }

            foreach (Card card in cards) {
                CardView cardView = Instantiate(cardViewPrefab);
                cardView.Initialize(card);
            }
        }
    }
}
