using System;
using UnityEngine;
using UnityEngine.UI;

namespace CardGame.Views
{
    public class BoardView : MonoBehaviour, IBoardView
    {
        [SerializeField]
        Button button;

        void Start()
        {
            button.onClick.AddListener(() => UndoButtonClicked?.Invoke());
        }

        public event Action UndoButtonClicked;

        public void SetUndoButtonVisible(bool isVisible)
        {
            button.gameObject.SetActive(isVisible);
        }
    }
}
