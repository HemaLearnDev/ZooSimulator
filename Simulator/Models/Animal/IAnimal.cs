using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSimulator.Models.Animal
{
    public interface IAnimal
    {
        double Health { get; }
        bool IsDead { get; }
        void DisplayStatus();
        void DecreaseHealth(double percentage);
        void IncreaseHealth(double percentage);
    }
}
