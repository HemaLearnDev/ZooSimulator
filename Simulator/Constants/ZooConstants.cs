using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSimulator.Constants
{
    public static class ZooConstants
    {
        public const int InitialAnimalCount = 5;
        public const int MinHealthDecrease = 0;
        public const int MaxHealthDecrease = 20;
        public const int FeedMinRandomValue = 10;
        public const int FeedMaxRandomValue = 25;

        public const int SimulationDelayMilliseconds = 20000;

        public const double MonkeyDeathThreshold = 30.0;
        public const double GiraffeDeathThreshold = 50.0;
        public const double ElephantWalkThreshold = 70.0;
    }
}
