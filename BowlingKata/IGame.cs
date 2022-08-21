namespace BowlingKata
{
    public interface IGame
    {
        void Roll(int numOfPinsKnocked);
        int Score();
    }
}
