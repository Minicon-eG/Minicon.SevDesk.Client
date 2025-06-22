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
}