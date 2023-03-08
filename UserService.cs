using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Userupdateservice
{
    public class UserService : BackgroundService
    {
        private readonly ILogger<UserService> logger;
        private readonly INTService INTService;
        public UserService(ILogger<UserService> _logger, INTService iNTService)
        {
            this.logger = _logger;
            INTService = iNTService;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
           
            while(!stoppingToken.IsCancellationRequested)
            {
                logger.LogInformation("Execution started");
                try
                {
                    string resp = INTService.updateuser();
                    logger.LogInformation(resp+" records updated");
                    // write logic
                }
                catch(Exception ex)
                {
                    logger.LogError(ex, ex.Message);
                }
                await Task.Delay(1000 * 15, stoppingToken);
            }
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Service started");
            return base.StartAsync(cancellationToken);
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Service stopped");
            return base.StopAsync(cancellationToken);
        }
    }
}
