namespace Bowling
{
    public class Game
    {
        private readonly int[] rolls = new int[21];
        private int currentRoll;
        private int score;

        public void Roll(int pins)
        {
            score += pins;
            rolls[currentRoll++] = pins;
        }

        public int Score
        {
            get
            {
                score = 0;
                int rollIndex = 0;
                for(int frameCount = 0; frameCount<10; frameCount++)
                {
                    if (IsStrike(rollIndex))
                    {
                        score += 10 + GetStrikeBonus(rollIndex);
                        rollIndex++;
                    }
                    else if (IsSpare(rollIndex))
                    {
                        score += 10 + GetSpareBonus(rollIndex);
                        rollIndex += 2;
                    }
                    else
                    {
                        score += GetFrameScore(rollIndex);
                        rollIndex += 2;                        
                    }
                }
                return score;
            }
        }

        private bool IsStrike(int rollIndex)
        {
            return rolls[rollIndex] == 10;
        }

        private bool IsSpare(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] == 10;
        }

        private int GetFrameScore(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1];
        }

        private int GetSpareBonus(int rollIndex)
        {
            return rolls[rollIndex + 2];
        }

        private int GetStrikeBonus(int rollIndex)
        {
            return rolls[rollIndex + 1] + rolls[rollIndex + 2];
        }
    }
}