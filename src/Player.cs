namespace DemonSlayer
{
    /// <summary>
    /// Represents a player in the DemonSlayer game.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// The name of the player.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The health points of the player.
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        public Player(string name)
        {
            Name = name;
            Health = 100;
        }

        /// <summary>
        /// Deals damage to the player.
        /// </summary>
        /// <param name="amount">Amount of damage to take.</param>
        public void TakeDamage(int amount)
        {
            Health -= amount;
        }

        /// <summary>
        /// Heals the player.
        /// </summary>
        /// <param name="amount">Amount of health to restore.</param>
        public void Heal(int amount)
        {
            Health += amount;
        }
    }
}
