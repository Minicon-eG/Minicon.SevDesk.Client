using System.Threading;
using System.Threading.Tasks;
using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api
{
    /// <summary>
    /// API for managing export jobs and retrieving download information
    /// </summary>
    public interface IExportJobApi
    {
        /// <summary>
        /// Retrieves download information for an export job
        /// </summary>
        /// <param name="exportJobId">The ID of the export job</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Export job download information</returns>
        [Get("/ExportJob/jobDownloadInfo")]
        Task<ExportJobDownloadInfoResponse> GetJobDownloadInfoAsync(
            [Query] string exportJobId,
            CancellationToken cancellationToken = default);
    }
}