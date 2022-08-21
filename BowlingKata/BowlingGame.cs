namespace BowlingKata
{
    public class BowlingGame : IGame
    {
        private readonly List<int> scores = new();

        public void Roll(int numOfPinsKnocked)
        {
            scores.Add(numOfPinsKnocked);
        }

        public int Score()
        {
            var totalScore = 0;
            for (int i = 0; i < scores.Count; i += 2)
            {
                var firstRollScore = scores.ElementAtOrDefault(i);
                var secondRollScore = scores.ElementAtOrDefault(i + 1);
                var totalScoreOfFrame = firstRollScore + secondRollScore;

                if (totalScoreOfFrame == 10)
                {
                    var firstRollOfNextFrame = scores.ElementAtOrDefault(i + 2);
                    totalScoreOfFrame += firstRollOfNextFrame;
                }

                totalScore += totalScoreOfFrame;
            }

            return totalScore;
        }
    }
}
