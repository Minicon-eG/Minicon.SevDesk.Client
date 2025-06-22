using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models
{
    /// <summary>
    /// Response model for progress tracking
    /// </summary>
    public class GetProgressResponse
    {
        /// <summary>
        /// Progress information for the operation
        /// </summary>
        [JsonProperty("objects")]
        public ProgressInfo Objects { get; set; }
    }

    /// <summary>
    /// Progress information for long-running operations
    /// </summary>
    public class ProgressInfo
    {
        /// <summary>
        /// Current progress percentage (0-100)
        /// </summary>
        [JsonProperty("progress")]
        public int Progress { get; set; }

        /// <summary>
        /// Current status of the operation
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Detailed message about the current state
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Whether the operation is complete
        /// </summary>
        [JsonProperty("isComplete")]
        public bool IsComplete { get; set; }

        /// <summary>
        /// Error message if the operation failed
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; }

        /// <summary>
        /// Result data if the operation is complete
        /// </summary>
        [JsonProperty("result")]
        public object Result { get; set; }
    }
}