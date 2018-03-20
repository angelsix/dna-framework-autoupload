using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dna.AutoUpload
{
    /// <summary>
    /// Keeps a media provider and a target content store in sync
    /// </summary>
    public class AutoUploader : SingleTaskWorker
    {
        #region Protected Members

        /// <summary>
        /// A keyed list of content items that exist on the device
        /// </summary>
        protected ConcurrentDictionary<string, ContentItem> mContentItemsToUpload = new ConcurrentDictionary<string, ContentItem>();

        /// <summary>
        /// A keyed list of content items that have already been successfully uploaded
        /// </summary>
        protected ConcurrentDictionary<string, ContentItem> mContentItemsAlreadyUploaded = new ConcurrentDictionary<string, ContentItem>();

        #endregion

        #region Public Properties

        /// <summary>
        /// The name that identifies this worker (used in unhandled exception logs to report source of an issue)
        /// </summary>
        public override string WorkerName => nameof(AutoUploader);

        #endregion

        #region Public Events

        #endregion

        #region Worker Task

        /// <summary>
        /// The task to run when Auto Uploader is started
        /// </summary>
        /// <param name="cancellationToken">The cancellation token for if we should stop</param>
        /// <returns></returns>
        protected override async Task WorkerTaskAsync(CancellationToken cancellationToken)
        {
            // Loop until we should stop
            while (!cancellationToken.IsCancellationRequested)
            {
                // 
                // Log it
                Framework.Logger.LogTraceSource("I'm still alive...");

                // Wait a second (or throw TaskCancelledException)
                await Task.Delay(1000, cancellationToken);
            }

            Framework.Logger.LogTraceSource("Auto upload task finished...");
        }

        #endregion

        #region Event Methods

        /// <summary>
        /// Should be called in order to inform the auto uploader there is new content
        /// </summary>
        /// <remarks>
        /// In <see cref="AutoUploadFrameworkConstructionExtensions.UseAutoUploader(FrameworkConstruction)"/>
        /// we fire the call to <see cref="SetupEvents"/>. In there we hook up to the 
        /// <see cref="IContentManager.ContentArrived"/> event and fire this event from that so this
        /// event is primarily used to fire a notification about content arriving when the built-in 
        /// content managers events would not suffice
        /// </remarks>
        public void OnContentArrived(List<ContentItem> content)
        {
            // Loop each item...
            content.ForEach(item =>
            {
                // Add it to the list if it is not already in there
                //
                // NOTE: Concurrent list so it is thread-safe by default
                //       No need to lock the list 
                //
                mContentItemsToUpload.GetOrAdd(item.Id, item);
            });
        }

        #endregion

        #region Event Setup

        /// <summary>
        /// Hooks into the <see cref="IContentManager"/> events
        /// so that this uploader can respond to them
        /// </summary>
        public void SetupEvents()
        {
            // Get the content manager
            var contentManager = Framework.Service<IContentManager>();

            // Hook into the content manager events
            contentManager.ContentArrived += (content) => OnContentArrived(content);
        }

        #endregion
    }
}