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
            text.SetText(card.ToString());
        }
    }
}
