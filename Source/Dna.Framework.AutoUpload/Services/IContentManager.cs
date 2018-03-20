using System;
using System.Collections.Generic;

namespace Dna.AutoUpload
{
    /// <summary>
    /// <para>
    ///     A manager that handles retrieving and manipulating/managing content on a device
    /// </para>
    /// <param>
    ///     IMPORTANT: The implementation of this interface must be added to the 
    ///     services as a Singleton or Constant as in start-up 
    ///     <see cref="AutoUploadFrameworkConstructionExtensions.UseAutoUploader(FrameworkConstruction)"/>
    ///     the <see cref="AutoUploader"/> hooks into the <see cref="ContentArrived"/> event once
    /// </param>
    /// </summary>
    public interface IContentManager
    {
        /// <summary>
        /// Should be called in order to inform the auto uploader there is new content
        /// </summary>
        event Action<List<ContentItem>> ContentArrived;
    }
}
