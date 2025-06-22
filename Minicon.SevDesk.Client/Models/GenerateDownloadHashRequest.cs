using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models
{
    /// <summary>
    /// Request model for generating a download hash for progress tracking
    /// </summary>
    public class GenerateDownloadHashRequest
    {
        /// <summary>
        /// Type of export operation
        /// </summary>
        [JsonProperty("exportType")]
        public string ExportType { get; set; }

        /// <summary>
        /// Additional parameters for the export
        /// </summary>
        [JsonProperty("exportParams")]
        public object ExportParams { get; set; }
    }
}