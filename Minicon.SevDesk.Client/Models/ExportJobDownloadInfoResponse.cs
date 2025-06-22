using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models
{
    /// <summary>
    /// Response model for export job download information
    /// </summary>
    public class ExportJobDownloadInfoResponse
    {
        /// <summary>
        /// Download information for the export job
        /// </summary>
        [JsonProperty("objects")]
        public DownloadInfo Objects { get; set; }
    }
}