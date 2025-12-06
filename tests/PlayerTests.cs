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
        /// </summary>
        private ILogger<Player> CreateLogger()
        {
            // Create a logger factory that stays alive for the whole test.
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

            Assert.Equal(100, player.Health);
        }

        [Fact]
        public void PlayerTakesDamageCorrectly()
        {
            var logger = CreateLogger();
            var player = new Player("Hero", logger);

            player.TakeDamage(30); 

            Assert.Equal(70, player.Health);
        }

        [Fact]
        public void PlayerHealsCorrectly()
        {
            var logger = CreateLogger();
            var player = new Player("Hero", logger);

            player.Heal(20);

            Assert.Equal(120, player.Health);
        }
    }
}
