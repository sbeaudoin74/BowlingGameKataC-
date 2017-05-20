using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingKata
{
    [TestClass]
    public class BowlingGameTests
    {
        private BowlingGame g;

        [TestInitialize]
        public void setUp()
        {
            g = new BowlingGame();
        }

        public void rollMany(int numRolls, int pins)
        {
            for (int i = 0; i < numRolls; i++)
            {
                g.roll(pins);
            }
        }

        [TestMethod]
        public void testGutterGame()
        {
            rollMany(20, 0);

            Assert.AreEqual(0, g.score());
        }

        [TestMethod]
        public void testAllOnes()
        {
            rollMany(20, 1);

            Assert.AreEqual(20, g.score());
        }

        [TestMethod]
        public void testRollOneTwoThreeFourEqualsTen()
        {
            g.roll(1);
            g.roll(2);
            g.roll(3);
            g.roll(4);

            Assert.AreEqual(10, g.score());
        }

        [TestMethod]
        public void testSpareAndThenThreeEqualsSixteen()
        {
            g.roll(6);
            g.roll(4);
            g.roll(3);

            Assert.AreEqual(16, g.score());
        }

        [TestMethod]
        public void testStrikeAndThenEightAndThenOneEqualsTwentyEight()
        {
            g.roll(10);
            g.roll(8);
            g.roll(1);

            Assert.AreEqual(28, g.score());
        }

        [TestMethod]
        public void testPseudoStrike()
        {
            g.roll(0);
            g.roll(10);
            g.roll(4);
            g.roll(3);

            Assert.AreEqual(21, g.score());
        }

        [TestMethod]
        public void testPerfectGame()
        {
            rollMany(12, 10);

            Assert.AreEqual(300, g.score());
        }
    }
}
