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
}