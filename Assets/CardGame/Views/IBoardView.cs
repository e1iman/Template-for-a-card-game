using System;

namespace CardGame.Views
{
    public interface IBoardView
    {
        public event Action UndoButtonClicked;
        public void SetUndoButtonVisible(bool isVisible);
    }
}
