using Microsoft.Extensions.DependencyInjection;

namespace Dna.AutoUpload
{
    /// <summary>
    /// Extension methods for the <see cref="FrameworkConstruction"/>
    /// </summary>
    public static class AutoUploadFrameworkConstructionExtensions
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public static FrameworkConstruction AddAutoUploader(this FrameworkConstruction construction)
        {
            // Add auto uploader as static instance
            construction.Services.AddSingleton<AutoUploader>();

            // Return framework for chaining
            return construction;
        }

        /// <summary>
        /// Configures and sets up the AutoUploader ready for use
        /// </summary>
        /// <param name="construction">The framework construction</param>
        /// <returns>Returns the framework construction for chaining</returns>
        public static FrameworkConstruction UseAutoUploader(this FrameworkConstruction construction)
        {
            // Get the auto uploader
            var autoUploader = Framework.Service<AutoUploader>();

            // Setup events
            autoUploader.SetupEvents();

            // Return framework for chaining
            return construction;
        }
    }
}
