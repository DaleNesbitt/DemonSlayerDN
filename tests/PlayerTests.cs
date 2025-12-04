using DemonSlayer;
using Microsoft.Extensions.Logging;
using Xunit;

namespace DemonSlayer.Tests
{
    /// <summary>
    /// Unit tests for the Player class.
    /// </summary>
    public class PlayerTests
    {
        /// <summary>
        /// Helper method that creates a logger for testing.
        /// This is a simple console logger so we can see log output in CI.
        /// </summary>
        private ILogger<Player> CreateLogger()
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.SetMinimumLevel(LogLevel.Information);
            });

            return loggerFactory.CreateLogger<Player>();
        }

        [Fact]
        public void PlayerStartsWithFullHealth()
        {
            // Arrange — create a player with a logger
            var logger = CreateLogger();
            var player = new Player("Hero", logger);

            // Assert — new players always start with 100 HP
            Assert.Equal(100, player.Health);
        }

        [Fact]
        public void PlayerTakesDamageCorrectly()
        {
            // Arrange
            var logger = CreateLogger();
            var player = new Player("Hero", logger);

            // Act
            player.TakeDamage(30);

            // Assert
            Assert.Equal(70, player.Health);
        }

        [Fact]
        public void PlayerHealsCorrectly()
        {
            // Arrange
            var logger = CreateLogger();
            var player = new Player("Hero", logger);

            // Act
            player.Heal(20);

            // Assert
            Assert.Equal(120, player.Health);
        }
    }
}
