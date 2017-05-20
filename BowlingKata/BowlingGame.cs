using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata
{
    class BowlingGame
    {
        int scoreTotal = 0;
        int[] rolls = new int[21];
        int currentRoll = 0;

        public void roll (int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public int score ()
        {
            int frameIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (isStrike(frameIndex))
                {
                    scoreTotal += strikeBonus(frameIndex);
                    frameIndex++;
                }
                else if (isSpare(frameIndex))
                {
                    scoreTotal += spareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    scoreTotal += rolls[frameIndex] + rolls[frameIndex + 1];
                    frameIndex += 2;
                }
            }

            return scoreTotal;
        }

        private int spareBonus(int frameIndex)
        {
            return 10 + rolls[frameIndex + 2];
        }

        private int strikeBonus(int frameIndex)
        {
            return 10 + rolls[frameIndex + 1] + rolls[frameIndex + 2];
        }

        private bool isStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }

        private bool isSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }
    }
}
