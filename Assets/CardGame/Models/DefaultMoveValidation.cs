using CardGame.DTOs;

namespace CardGame.Models
{
    public class DefaultMoveValidation : IMoveValidation
    {
        public bool CanPerformMove(Card card, int stackIndex)
        {
            return true;
        }
    }
}
