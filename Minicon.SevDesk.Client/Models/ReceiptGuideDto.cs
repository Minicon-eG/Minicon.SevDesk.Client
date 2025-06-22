using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models;

public class ReceiptGuideDto
{
    [JsonProperty("accountNumber")]
    public int AccountNumber { get; set; }

    [JsonProperty("accountName")]
    public string AccountName { get; set; }

    [JsonProperty("taxRule")]
    public string TaxRule { get; set; }

    [JsonProperty("taxCategory")]
    public string TaxCategory { get; set; }

    [JsonProperty("defaultTaxRate")]
    public decimal? DefaultTaxRate { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("isRevenue")]
    public bool IsRevenue { get; set; }

    [JsonProperty("isExpense")]
    public bool IsExpense { get; set; }

    [JsonProperty("isAsset")]
    public bool IsAsset { get; set; }

    [JsonProperty("isLiability")]
    public bool IsLiability { get; set; }
}