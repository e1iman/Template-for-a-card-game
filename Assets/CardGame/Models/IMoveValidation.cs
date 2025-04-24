using CardGame.DTOs;

namespace CardGame.Models
{
    public interface IMoveValidation
    {
        bool CanPerformMove(Card card, int stackIndex);
    }
}
