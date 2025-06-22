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

    /// <summary>
    /// Hash information for progress tracking
    /// </summary>
    public class HashInfo
    {
        /// <summary>
        /// The generated hash for tracking the operation
        /// </summary>
        [JsonProperty("hash")]
        public string Hash { get; set; }

        /// <summary>
        /// Timestamp when the hash was generated
        /// </summary>
        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Expiration time of the hash
        /// </summary>
        [JsonProperty("expiresAt")]
        public string ExpiresAt { get; set; }
    }
}