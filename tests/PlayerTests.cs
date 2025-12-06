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
        /// Creates a logger for testing.
        /// We keep this simple: console logger with Info level so that if something
        /// goes wrong, we can see log output in the CI logs.
        /// </summary>
        private ILogger<Player> CreateLogger()
        {
            // Create a logger factory that stays alive for the whole test run.
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole(); // lets logs appear in GitHub Actions
                builder.SetMinimumLevel(LogLevel.Information);
            });

            return loggerFactory.CreateLogger<Player>();
        }

        [Fact]
        public void PlayerStartsWithFullHealth()
        {
            var logger = CreateLogger();
            var player = new Player("Hero", logger);

            // New players should always start at 100 HP.
            Assert.Equal(100, player.Health);
        }

        [Fact]
        public void PlayerTakesDamageCorrectly()
        {
            var logger = CreateLogger();
            var player = new Player("Hero", logger);

            player.TakeDamage(30);

            // Health should drop from 100 to 70 after taking 30 damage.
            Assert.Equal(70, player.Health);
        }

        [Fact]
        public void PlayerHealsCorrectly()
        {
            var logger = CreateLogger();
            var player = new Player("Hero", logger);

            player.Heal(20);

            // Health should increase from 100 to 120 when healed by 20.
            Assert.Equal(120, player.Health);
        }
    }
}
