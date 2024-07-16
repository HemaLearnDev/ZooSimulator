using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooSimulator.Constants;

namespace ZooSimulator.Models.Animal.Types
{
    public class Giraffe : Animal
    {
        public override void DecreaseHealth(double percentage)
        {
            base.DecreaseHealth(percentage);
            if (Health < ZooConstants.GiraffeDeathThreshold)
            {
                IsDead = true;
            }
        }
    }
}
