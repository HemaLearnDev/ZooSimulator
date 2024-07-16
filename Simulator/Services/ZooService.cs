using ZooSimulator.Constants;
using ZooSimulator.Models.Animal;
using ZooSimulator.Models.Animal.Types;

namespace ZooSimulator.Services
{
    public class ZooService : IZooService
    {
        private List<IAnimal> _zoo;
        private Random random;
        private int _passedHours=0;

        public ZooService()
        {
            _zoo = InitializeAnimals();
            random = new Random();

        }
        private List<IAnimal> InitializeAnimals()
        {
            var animals = new List<IAnimal>();

            for (int i = 0; i < ZooConstants.InitialAnimalCount; i++)
            {
                animals.Add(new Monkey());
                animals.Add(new Giraffe());
                animals.Add(new Elephant());
            }

            return animals;
        }

        public void RunZoo()
        {
            DisplayZooStatus();
            Task.Run(async () => await SimulateTimeAsync());
            while (_zoo.Any(animal => !animal.IsDead))
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Q)
                {
                    Console.WriteLine("Quitting the zoo simulation.");
                    Environment.Exit(0);
                    break;
                }
                else if (key == ConsoleKey.F)
                {
                    FeedAnimals();
                    Console.WriteLine("Animals have been fed.");
                    DisplayZooStatus();
                }
            }
            if (_zoo.All(animal => animal.IsDead))
            {
                Console.WriteLine("Simulation eneded");
                Environment.Exit(0);
            }

        }
        private async Task SimulateTimeAsync()
        {
            while (_zoo.Any(animal => !animal.IsDead))
            {
                await Task.Delay(ZooConstants.SimulationDelayMilliseconds);
                SimulateHour();
                Console.WriteLine($"{++_passedHours} hour has passed.");
                DisplayZooStatus();
            }
            if (_zoo.All(animal => animal.IsDead))
            {
                Console.WriteLine("All animals are dead. The zoo is closed.");
            }

        }


        private void SimulateHour()
        {
            foreach (var animal in _zoo)
            {
                if (!animal.IsDead)
                {
                    double healthDecrease = random.NextDouble() * ZooConstants.MaxHealthDecrease;
                    animal.DecreaseHealth(healthDecrease);
                }
            }
        }

        private void FeedAnimals()
        {
            double monkeyIncrease = random.Next(ZooConstants.FeedMinRandomValue, ZooConstants.FeedMaxRandomValue + 1);
            double giraffeIncrease = random.Next(ZooConstants.FeedMinRandomValue, ZooConstants.FeedMaxRandomValue + 1);
            double elephantIncrease = random.Next(ZooConstants.FeedMinRandomValue, ZooConstants.FeedMaxRandomValue + 1);

            foreach (var animal in _zoo)
            {
                if (!animal.IsDead)
                {
                    switch (animal)
                    {
                        case Monkey _:
                            animal.IncreaseHealth(monkeyIncrease);
                            break;
                        case Giraffe _:
                            animal.IncreaseHealth(giraffeIncrease);
                            break;
                        case Elephant _:
                            animal.IncreaseHealth(elephantIncrease);
                            break;
                    }
                }
            }
        }

        private void DisplayZooStatus()
        {
            Console.WriteLine($"Zoo Status at {DateTime.Now}");
            foreach (var animal in _zoo)
            {
                animal.DisplayStatus();
            }
            Console.WriteLine();
        }
    }

}
