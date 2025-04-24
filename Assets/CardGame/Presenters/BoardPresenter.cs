using CardGame.DTOs;
using CardGame.Models;
using CardGame.Views;

namespace CardGame.Presenters
{
    public class BoardPresenter
    {
        readonly IBoard model;
        readonly IBoardView view;

        public BoardPresenter(IBoardView view, IBoard model)
        {
            this.view = view;
            this.model = model;
        }

        public void Initialize()
        {
            model.CardMoved += Model_OnCardMoved;
            view.UndoButtonClicked += View_OnUndoButtonClicked;

            UpdateUndoButtonVisibility();
        }

        void Model_OnCardMoved(MoveInfo moveInfo)
        {
            UpdateUndoButtonVisibility();
        }

        void View_OnUndoButtonClicked()
        {
            model.UndoMove();
        }

        void UpdateUndoButtonVisibility()
        {
            view.SetUndoButtonVisible(model.CanUndoMove());
        }
    }
}
