using System.IO;
using MediaBrowser.Controller.Entities.TV;
using MediaBrowser.Model.IO;
using MediaBrowser.XbmcMetadata.Parsers;

namespace MediaBrowser.XbmcMetadata.Providers
{
    /// <summary>
    /// Nfo provider for seasons.
    /// </summary>
    public class SeasonNfoProvider : BaseNfoProvider<Season>
    {
        private readonly ILogger<SeasonNfoProvider> _logger;
        private readonly IConfigurationManager _config;
        private readonly IProviderManager _providerManager;
        private readonly IUserManager _userManager;
        private readonly IUserDataManager _userDataManager;
        private readonly IDirectoryService _directoryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SeasonNfoProvider"/> class.
        /// </summary>
        /// <param name="logger">Instance of the <see cref="ILogger{SeasonNfoProvider}"/> interface.</param>
        /// <param name="fileSystem">Instance of the <see cref="IFileSystem"/> interface.</param>
        /// <param name="config">Instance of the <see cref="IConfigurationManager"/> interface.</param>
        /// <param name="providerManager">Instance of the <see cref="IProviderManager"/> interface.</param>
        /// <param name="userManager">Instance of the <see cref="IUserManager"/> interface.</param>
        /// <param name="userDataManager">Instance of the <see cref="IUserDataManager"/> interface.</param>
        /// <param name="directoryService">Instance of the <see cref="IDirectoryService"/> interface.</param>
        public SeasonNfoProvider(
            ILogger<SeasonNfoProvider> logger,
            IFileSystem fileSystem,
            IConfigurationManager config,
            IProviderManager providerManager,
            IUserManager userManager,
            IUserDataManager userDataManager,
            IDirectoryService directoryService)
            : base(fileSystem)
        {
            _logger = logger;
            _config = config;
            _providerManager = providerManager;
            _userManager = userManager;
            _userDataManager = userDataManager;
            _directoryService = directoryService;
        }

        /// <inheritdoc />
        protected override void Fetch(MetadataResult<Season> result, string path, CancellationToken cancellationToken)
        {
            new SeasonNfoParser(_logger, _config, _providerManager, _userManager, _userDataManager, _directoryService).Fetch(result, path, cancellationToken);
        }

        /// <inheritdoc />
        protected override FileSystemMetadata? GetXmlFile(ItemInfo info, IDirectoryService directoryService)
            => directoryService.GetFile(Path.Combine(info.Path, "season.nfo"));
    }
}
