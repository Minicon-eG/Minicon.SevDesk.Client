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

    /// <summary>
    /// Download information for an export job
    /// </summary>
    public class DownloadInfo
    {
        /// <summary>
        /// The download URL for the exported file
        /// </summary>
        [JsonProperty("downloadUrl")]
        public string DownloadUrl { get; set; }

        /// <summary>
        /// The status of the export job
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// File size in bytes
        /// </summary>
        [JsonProperty("fileSize")]
        public long? FileSize { get; set; }

        /// <summary>
        /// File name of the export
        /// </summary>
        [JsonProperty("fileName")]
        public string FileName { get; set; }

        /// <summary>
        /// Expiration time of the download link
        /// </summary>
        [JsonProperty("expiresAt")]
        public string ExpiresAt { get; set; }
    }
}