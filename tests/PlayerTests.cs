using System;
using DemonSlayer;
using Xunit;

namespace DemonSlayer.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void PlayerStartsWithCorrectHealth()
        {
            var p = new Player(100);
            Assert.Equal(100, p.Health);
        }

        [Fact]
        public void TakingDamageReducesHealth()
        {
            var p = new Player(100);
            p.TakeDamage(30);
            Assert.Equal(70, p.Health);
        }

        [Fact]
        public void HealthDoesNotGoBelowZero()
        {
            var p = new Player(50);
            p.TakeDamage(100);
            Assert.Equal(0, p.Health);
        }

        [Fact]
        public void AddingScoreIncreasesScore()
        {
            var p = new Player(100);
            p.AddScore(10);
            Assert.Equal(10, p.Score);
        }

        [Fact]
        public void CreatingPlayerWithZeroHealthThrows()
        {
            Assert.Throws<ArgumentException>(() => new Player(0));
        }
    }
}
