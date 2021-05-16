using CatMash.API.Models;

namespace CatMash.API.Utility
{
    public class ScoreCalculator
    {
        private static readonly int WIN_WEIGHT = 10;

        public static Score CalculateScore(int winVoteCount)
        {
            return new Score
            {
                VoteCount = winVoteCount,
                TotalScore = winVoteCount * WIN_WEIGHT
            };
        }
    }
}
