using NzbDrone.Common.Disk;
using NzbDrone.Core.Configuration;
using NzbDrone.Core.Configuration.Events;
using NzbDrone.Core.Download;
using NzbDrone.Core.ThingiProvider.Events;

namespace NzbDrone.Core.HealthCheck.Checks
{
    [CheckOn(typeof(ProviderUpdatedEvent<IDownloadClient>))]
    [CheckOn(typeof(ProviderDeletedEvent<IDownloadClient>))]
    [CheckOn(typeof(ConfigSavedEvent))]
    public class ImportMechanismCheck : HealthCheckBase
    {
        private readonly IConfigService _configService;

        public ImportMechanismCheck(IConfigService configService)
        {
            _configService = configService;
        }

        public override HealthCheck Check()
        {
            var droneFactoryFolder = new OsPath(_configService.DownloadedAlbumsFolder);
            if (!_configService.EnableCompletedDownloadHandling && droneFactoryFolder.IsEmpty)
            {
                return new HealthCheck(GetType(), HealthCheckResult.Warning, "Enable Completed Download Handling or configure Drone Factory");
            }

            return new HealthCheck(GetType());
        }
    }

    public class ImportMechanismCheckStatus
    {
        public IDownloadClient DownloadClient { get; set; }
        public DownloadClientInfo Status { get; set; }
    }
}
