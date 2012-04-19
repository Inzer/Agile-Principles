using NUnit.Framework;

namespace Bowling.Tests
{
    [TestFixture]
    public class BowlingTests
    {
        private Game game;

        [SetUp]
        public void Setup()
        {
            game = new Game();
        }

        [Test]
        public void should_return_zero_when_all_rolls_are_gutter_rolls()
        {
            DoRolls(20, 0);
            Assert.AreEqual(0, game.Score);
        }

        [Test]
        public void should_return_twenty_when_all_rolls_drop_one_pin()
        {
            DoRolls(20, 1);
            Assert.AreEqual(20, game.Score);
        }

        [Test]
        public void should_consider_spare_in_total_score()
        {
            DoSpare();
            game.Roll(3);
            DoRolls(17, 0);
            Assert.AreEqual(16, game.Score);
        }

        [Test]
        public void should_consider_strike_in_total_score()
        {
            DoStrike();
            game.Roll(3);
            game.Roll(4);
            DoRolls(17, 0);
            Assert.AreEqual(24, game.Score);
        }

        [Test]
        public void should_return_300_when_all_rolls_are_strikes()
        {
            DoRolls(12, 10);
            Assert.AreEqual(300, game.Score);
        }

        [Test]
        public void should_return_200_when_spares_and_strikes_are_alternated()
        {
            for (int i= 0; i<10;i++)
            {
                if (i % 2 == 0)
                {
                    DoSpare();
                }
                else
                {
                    DoStrike();
                }
            }
            DoSpare();
            Assert.AreEqual(game.Score, 200);
        }

        [Test]
        public void should_return_150_when_all_fives()
        {
            DoRolls(21, 5);
            Assert.AreEqual(game.Score, 150);
        }

        [Test]
        public void should_return_60_for_an_open_turkey()
        {
            DoStrike();
            DoStrike();
            DoStrike();
            Assert.AreEqual(game.Score, 60);
        }

        [Test]
        public void should_return_133_when_I_run_uncle_bobs_scenario()
        {
            DoRolls(1, 1);
            DoRolls(1, 4);
            DoRolls(1, 4);
            DoRolls(1, 5);
            DoRolls(1, 6);
            DoRolls(1, 4);
            DoRolls(1, 5);
            DoRolls(1, 5);
            DoStrike();
            DoRolls(1, 0);
            DoRolls(1, 1);
            DoRolls(1, 7);
            DoRolls(1, 3);
            DoRolls(1, 6);
            DoRolls(1, 4);
            DoStrike();
            DoRolls(1, 2);
            DoRolls(1, 8);
            DoRolls(1, 6);
            Assert.AreEqual(game.Score, 133);
        }

        private void DoRolls(int numberOfRolls, int numberOfPins)
        {
            for (int rollNumber = 0; rollNumber < numberOfRolls; rollNumber++ )
            {
                game.Roll(numberOfPins);
            }
        }

        private void DoSpare()
        {
            game.Roll(3);
            game.Roll(7);
        }

        private void DoStrike()
        {
            game.Roll(10);
        }

        
    }
}