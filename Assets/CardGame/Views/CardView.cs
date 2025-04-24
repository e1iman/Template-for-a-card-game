using CardGame.DTOs;
using TMPro;
using UnityEngine;

namespace CardGame.Views
{
    public class CardView : MonoBehaviour, ICardView
    {
        [SerializeField]
        TMP_Text text;

        public void Initialize(Card card)
        {
            text.SetText(GetText(card));
        }

        static string GetText(Card card)
        {
            return $"<color={GetColor(card.Suit)}>" + card.Value + "</color>";
        }

        static string GetColor(CardSuit suit)
        {
            switch (suit) {
                case CardSuit.Spades:
                    return "black";
                case CardSuit.Clubs:
                    return "blue";
                case CardSuit.Diamonds:
                    return "orange";
                case CardSuit.Hearts:
                    return "red";
                default:
                    return "white";
            }
        }
    }
}