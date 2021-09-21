using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class BowlingGameYard
    {
        private int Score;
        private int[] rolls = new int[21];
        private int currentRole = 0;

        public void roll(int pins)
        {
            rolls[currentRole] = pins;
            currentRole += 1;
        }


        public int score()
        {
            var firstBallInFrame = 0;

            for(var frame = 0; frame < 10; frame++)
            {
                if (isStrike(firstBallInFrame))
                {
                    CalculateStrikeScore( firstBallInFrame);
                    firstBallInFrame += 1;
                }
                else if (isSpare(firstBallInFrame))
                {
                    CalculateSpareScore(firstBallInFrame);
                    firstBallInFrame += 2;
                }
                else
                {
                    CalculateNormalFrame(firstBallInFrame);
                    firstBallInFrame += 2;
                }
            }

            return Score;
        }

        private void CalculateNormalFrame(int firstBallInFrame)
        {
            Score += rolls[firstBallInFrame] + rolls[firstBallInFrame + 1];
        }

        private void CalculateSpareScore(int firstBallInFrame)
        {
            Score += 10 + rolls[firstBallInFrame + 2];
        }

        private int CalculateStrikeScore( int firstBallInFrame)
        {
            Score += 10 + rolls[firstBallInFrame + 1] + rolls[firstBallInFrame + 2];
            return Score;
        }

        private bool isSpare(int firstBallInFrame)
        {
            return (rolls[firstBallInFrame] + rolls[firstBallInFrame + 1]) == 10;
        }

        private bool isStrike(int firstBallInFrame)
        {
            return rolls[firstBallInFrame] == 10;
        }
    }
}
