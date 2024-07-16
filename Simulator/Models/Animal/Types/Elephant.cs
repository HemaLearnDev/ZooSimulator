using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooSimulator.Constants;

namespace ZooSimulator.Models.Animal.Types
{
    public class Elephant : Animal
    {
        private bool cannotWalk = false;

        public override void DisplayStatus()
        {
            Console.WriteLine($"{GetType().Name} - Health: {Health:F2}% {(IsDead ? "(Dead)" : cannotWalk ? "(Cannot Walk)" : "")}");
        }

        public override void DecreaseHealth(double percentage)
        {
            base.DecreaseHealth(percentage);
            if (Health < ZooConstants.ElephantWalkThreshold && cannotWalk)
            {
                IsDead = true;
            }
            else
            {
                cannotWalk = false;
            }
            if (Health < ZooConstants.ElephantWalkThreshold)
            {
                cannotWalk = true;

            }
        }
        public override void IncreaseHealth(double percentage)
        {
            base.IncreaseHealth(percentage);
            if (Health >= ZooConstants.ElephantWalkThreshold) cannotWalk = false;
        }
    }
}
