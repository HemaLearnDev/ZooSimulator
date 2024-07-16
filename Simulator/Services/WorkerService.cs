using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace ZooSimulator.Services
{
    public class WorkerService : BackgroundService
    {
        private readonly IZooService _zooService;

        public WorkerService(IZooService zooService)
        {
            _zooService = zooService;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Simulation started. Press 'f' to feed the animals or 'q' to quit.");
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Run(() => _zooService.RunZoo());
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }
    }
}
