using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models
{
    /// <summary>
    /// Response model for DATEV export job creation
    /// </summary>
    public class CreateDatevExportJobResponse
    {
        /// <summary>
        /// The ID of the created export job
        /// </summary>
        [JsonProperty("objects")]
        public ExportJobInfo Objects { get; set; }
    }

    /// <summary>
    /// Information about the created export job
    /// </summary>
    public class ExportJobInfo
    {
        /// <summary>
        /// The unique identifier of the export job
        /// </summary>
        [JsonProperty("jobId")]
        public string JobId { get; set; }

        /// <summary>
        /// The status of the export job
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Timestamp when the job was created
        /// </summary>
        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }
    }
}