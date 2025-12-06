using DemonSlayer;
using Microsoft.Extensions.Logging;
using Xunit;

namespace DemonSlayer.Tests
{
    /// <summary>
    /// Unit tests for the Player class.
    /// Includes both console logging (for CI visibility)
    /// and an in-memory logger (for verifying log messages).
    /// </summary>
    public class PlayerTests
    {
        /// <summary>
        /// Creates a console logger for testing.
        /// We keep this simple: a console logger with Information level.
        /// This ensures log output appears inside the CI logs if anything fails.
        /// </summary>
        private ILogger<Player> CreateConsoleLogger()
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole(); // Allows logs to appear in GitHub Actions
                builder.SetMinimumLevel(LogLevel.Information);
            });

            return loggerFactory.CreateLogger<Player>();
        }

        [Fact]
        public void PlayerStartsWithFullHealth()
        {
            var logger = CreateConsoleLogger();
            var player = new Player("Hero", logger);

            // New players should always start at 100 HP.
            Assert.Equal(100, player.Health);
        }

        [Fact]
        public void PlayerTakesDamageCorrectly()
        {
            var logger = CreateConsoleLogger();
            var player = new Player("Hero", logger);

            player.TakeDamage(30);

            // Health should drop from 100 to 70 after taking 30 damage.
            Assert.Equal(70, player.Health);
        }

        [Fact]
        public void PlayerHealsCorrectly()
        {
            var logger = CreateConsoleLogger();
            var player = new Player("Hero", logger);

            player.Heal(20);

            // Health should increase from 100 to 120 when healed by 20.
            Assert.Equal(120, player.Health);
        }

        // ------------------------------
        // Logging Verification Test
        // ------------------------------

        [Fact]
        public void PlayerCreation_WritesLogMessage()
        {
            // Arrange: use the in-memory test logger
            var logger = new TestLogger<Player>();

            // Act: create a player (this should trigger a log entry)
            var player = new Player("Dale", logger);

            // Assert: at least one log message exists
            Assert.NotEmpty(logger.Messages);

            // Bonus: check that the log includes the player name
            Assert.Contains("Dale", logger.Messages[0]);
        }
    }
}
