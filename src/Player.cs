using System;

namespace DemonSlayer
{
    public class Player
    {
        public int Health { get; private set; }
        public int Score { get; private set; }

        public Player(int startingHealth)
        {
            if (startingHealth <= 0)
                throw new ArgumentException("Starting health must be greater than zero");
            Health = startingHealth;
            Score = 0;
        }

        public void TakeDamage(int amount)
        {
            if (amount < 0) throw new ArgumentException("Damage cannot be negative");
            Health = Math.Max(0, Health - amount);
        }

        public void AddScore(int amount)
        {
            if (amount < 0) throw new ArgumentException("Score cannot be negative");
            Score += amount;
        }
    }
}
