using Microsoft.VisualBasic;
using System;

namespace ZooSimulator.Models.Animal
{
    public class Animal : IAnimal
    {
        public double Health { get; protected set; } = 100.0;
        public bool IsDead { get; protected set; } = false;

        public virtual void DisplayStatus()
        {
            Console.WriteLine($"{GetType().Name} - Health: {Health:F2}% {(IsDead ? "(Dead)" : "")}");
        }

        public virtual void DecreaseHealth(double percentage)
        {
            Health -= Health * (percentage / 100.0);
        }

        public virtual void IncreaseHealth(double percentage)
        {
            Health += Health * (percentage / 100.0);
            if (Health > 100) Health = 100;
        }
    }
}
