using Microsoft.Extensions.Logging;

namespace DemonSlayer
{
    /// <summary>
    /// Represents a player in the DemonSlayer game.
    /// </summary>
    public class Player
    {
        // Here I store the logger so the Player class can write log messages.
        private readonly ILogger<Player> _logger;

        /// <summary>
        /// The name of the player.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The health points of the player.
        /// </summary>
        public int Health { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        /// <param name="logger">
        /// The logger injected into this class so we can output useful runtime information.
        /// </param>
        public Player(string name, ILogger<Player> logger)
        {
            _logger = logger; // Save the logger for use later.

            Name = name;
            Health = 100;

            // Log when the player is created — this will show up in GitHub Actions logs.
            _logger.LogInformation("Player '{Name}' created with {Health} HP.", Name, Health);
        }

        /// <summary>
        /// Deals damage to the player.
        /// </summary>
        /// <param name="amount">Amount of damage to take.</param>
        public void TakeDamage(int amount)
        {
            // Log that damage was taken — again, visible in CI logs.
            _logger.LogInformation("Player '{Name}' takes {Amount} damage.", Name, amount);

            Health -= amount;
        }

        /// <summary>
        /// Heals the player.
        /// </summary>
        /// <param name="amount">Amount of health to restore.</param>
        public void Heal(int amount)
        {
            // Log that the player healed.
            _logger.LogInformation("Player '{Name}' heals for {Amount} HP.", Name, amount);

            Health += amount;
        }

        //Warning
        public void ShowWarning(int unusedParameter)
        {
            // This will trigger a warning for Roslynator. Until now, no warnings are being triggered.
            int x = 10; // Arbitrary code so Roslynator analyzes this method.
        }
        
    }
}
