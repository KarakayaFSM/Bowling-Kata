using FluentAssertions;

namespace BowlingKata.Tests
{
    [TestFixture]
    public class BowlingKataTests
    {
        private IGame game;

        [SetUp]
        public void Init()
        {
            game = new BowlingGame();
        }

        [Test]
        public void Should_Return_Zero_When_Zero_Pins_Knocked()
        {
            RollZeros(20);
            game.Score().Should().Be(0);
        }

        [Test]
        public void Should_Return_One_When_One_Pin_Knocked()
        {
            RollZeros(19);
            Roll(1);
            game.Score().Should().Be(1);
        }

        [Test]
        public void Should_Add_Bonus_To_Score_When_Spare()
        {
            Roll(5, 5, 1);
            RollZeros(17);

            game.Score().Should().Be((10 + 1) + 1); // 12

        }

        private void Roll(params int[] knockedPinsArray)
        {
            foreach (int knockedPinCount in knockedPinsArray)
            {
                game.Roll(knockedPinCount);
            }
        }

        private void RollZeros(int numOfRolls)
        {
            for (int i = 0; i < numOfRolls; i++)
            {
                game.Roll(0);
            }
        }

        [Test]
        public void Should_Add_Bonus_To_Score_When_Double_Spare()
        {
            Roll(5, 5, 5, 5, 1);
            RollZeros(15);
            game.Score().Should().Be((10 + 5) + (10 + 1) + 1); // 15 + 11 + 1 = 27
        }

        [Test]
        public void Should_Add_Bonus_To_Score_When_Strike()
        {
            Roll(10, 1, 1);
            RollZeros(16);
            game.Score().Should().Be((10 + 2) + 1 + 1); // 12 + 2 = 14
        }
    }
}
