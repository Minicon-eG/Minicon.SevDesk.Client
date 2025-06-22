using System;
using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models
{
    /// <summary>
    /// Request model for creating a DATEV XML export job
    /// </summary>
    public class CreateDatevXmlExportRequest
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
        /// Include unpaid invoices in the export
        /// </summary>
        [JsonProperty("withUnpaidInvoices")]
        public bool? WithUnpaidInvoices { get; set; }

        /// <summary>
        /// Include enshrined invoices in the export
        /// </summary>
        [JsonProperty("withEnshrinedInvoices")]
        public bool? WithEnshrinedInvoices { get; set; }
    }
}