using System.Threading;
using System.Threading.Tasks;
using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api
{
    /// <summary>
    /// API for tracking progress of long-running operations
    /// </summary>
    public interface IProgressApi
    {
        /// <summary>
        /// Generates a download hash for tracking export progress
        /// </summary>
        /// <param name="request">Request containing export parameters</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Download hash response</returns>
        [Post("/Progress/generateDownloadHash")]
        Task<GenerateDownloadHashResponse> GenerateDownloadHashAsync(
            [Body] GenerateDownloadHashRequest request,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the progress of a long-running operation
        /// </summary>
        /// <param name="hash">The hash identifier for the operation</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Progress information</returns>
        [Get("/Progress/getProgress")]
        Task<GetProgressResponse> GetProgressAsync(
            [Query] string hash,
            CancellationToken cancellationToken = default);
    }
}