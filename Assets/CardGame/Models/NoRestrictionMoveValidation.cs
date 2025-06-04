using CardGame.DTOs;

namespace CardGame.Models
{
    public class NoRestrictionMoveValidation : IMoveValidation
    {
        public bool CanPerformMove(Card card, int stackIndex)
        {
            return true;
        }
    }
}
