using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models
{
    /// <summary>
    /// Response model for download hash generation
    /// </summary>
    public class GenerateDownloadHashResponse
    {
        /// <summary>
        /// Hash information for tracking the export progress
        /// </summary>
        [JsonProperty("objects")]
        public HashInfo Objects { get; set; }
    }
}