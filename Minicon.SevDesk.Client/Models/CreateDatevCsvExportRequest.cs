using System;
using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models
{
    /// <summary>
    /// Request model for creating a DATEV CSV export job
    /// </summary>
    public class CreateDatevCsvExportRequest
    {
        /// <summary>
        /// Start date for the export period
        /// </summary>
        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date for the export period
        /// </summary>
        [JsonProperty("endDate")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Define what to include in the DATEV export. This parameter takes a string of 5 letters.
        /// Each stands for a model that should be included. Possible letters are:
        /// 'E' (Earnings), 'X' (Expenditure), 'T' (Transactions), 'C' (Cashregister), 'D' (Assets).
        /// Example combinations: 'EXTCD', 'EXTD'
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// Include unpaid documents in the export
        /// </summary>
        [JsonProperty("withUnpaidDocuments")]
        public bool? WithUnpaidDocuments { get; set; }

        /// <summary>
        /// Include enshrined documents in the export
        /// </summary>
        [JsonProperty("withEnshrinedDocuments")]
        public bool? WithEnshrinedDocuments { get; set; }

        /// <summary>
        /// Enshrine all models which were included in the export
        /// </summary>
        [JsonProperty("enshrine")]
        public bool? Enshrine { get; set; }
    }
}