using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Minicon.SevDesk.Client;

using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

public class JsonInspectingHandler : DelegatingHandler
{
	private readonly ILogger<JsonInspectingHandler> _logger;
	private readonly IOptionsMonitor<SevDeskOptions> _options;

	public JsonInspectingHandler(ILogger<JsonInspectingHandler> logger, IOptionsMonitor<SevDeskOptions> options)
	{
		_logger = logger;
		_options = options;
	}
	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		if (!_options.CurrentValue.InspectJson)
		{
			return await base.SendAsync(request, cancellationToken);
		}
		// Inspizieren der JSON-Anfrage
		if (request.Content is { Headers.ContentType.MediaType: "application/json" })
		{
			string requestBody = await request.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
			Console.WriteLine("Request JSON: " + requestBody);

			// Optional: JSON deserialisieren, inspizieren oder manipulieren
			try
			{
				var jsonDocument = JsonDocument.Parse(requestBody);
				// Beispiel: Ein bestimmtes Feld auslesen
				if (jsonDocument.RootElement.TryGetProperty("key", out JsonElement keyProperty))
				{
					_logger.LogInformation("Key: {Key}", keyProperty.GetString());
				}
			}
			catch (JsonException ex)
			{
				_logger.LogInformation("Invalid JSON: {Message}", ex.Message);
			}
		}

		// Anfrage weiterleiten
		HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

		// Inspizieren der JSON-Antwort
		if (response.Content != null && response.Content.Headers.ContentType?.MediaType == "application/json")
		{
			string responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
			_logger.LogInformation("Response JSON: {ResponseBody}", responseBody);
		}

		return response;
	}
}
