namespace CardGame.DTOs
{
    public struct MoveInfo
    {
        public readonly Card card;
        public readonly int fromStackIndex;
        public readonly int toStackIndex;

        public MoveInfo(Card card, int fromStackIndex, int toStackIndex)
        {
            this.card = card;
            this.fromStackIndex = fromStackIndex;
            this.toStackIndex = toStackIndex;
        }
    }
}
