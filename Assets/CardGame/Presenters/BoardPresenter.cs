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
        }

        void Model_OnCardMoved(MoveInfo moveInfo)
        {
            view.SetUndoButtonVisible(model.CanUndoMove());
        }

        void View_OnUndoButtonClicked()
        {
            model.UndoMove();
        }
    }
}
