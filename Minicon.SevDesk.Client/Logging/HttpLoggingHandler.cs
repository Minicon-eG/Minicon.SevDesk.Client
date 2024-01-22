using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Minicon.SevDesk.Client.Logging;

public class LoggingHttpMessageHandler<T> : DelegatingHandler
{
	private readonly ILogger _logger;

	/// <summary>
	///     Initializes a new instance of the
	///     <see>
	///         <cref>LoggingHttpMessageHandler</cref>
	///     </see>
	///     class.
	/// </summary>
	/// <param name="logger"></param>
	public LoggingHttpMessageHandler(ILogger<T> logger)
	{
		_logger = logger;
	}

	public bool EnableContentLogging { get; set; }

	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
		CancellationToken cancellationToken)
	{
		var stopwatch = new Stopwatch();

		var requestId = Guid.NewGuid();

		await LogHttpRequest(requestId, request);

		stopwatch.Start();

		HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

		stopwatch.Stop();

		await LogHttpResponse(requestId, response, stopwatch.Elapsed);

		return response;
	}

	private async Task LogHttpRequest(Guid requestId, HttpRequestMessage request)
	{
		var message = new StringBuilder();

		message.AppendLine($"Sending HTTP request (Id: {requestId}) {request.Method} {request.RequestUri}");

		if (_logger.IsEnabled(LogLevel.Trace))
		{
			foreach (KeyValuePair<string, IEnumerable<string>> header in request.Headers)
			{
				foreach (string value in header.Value)
				{
					message.AppendLine($"{header.Key}: {value}");
				}
			}

			if (request.Content != null)
			{
				foreach (KeyValuePair<string, IEnumerable<string>> header in request.Content.Headers)
				{
					foreach (string value in header.Value)
					{
						message.AppendLine($"{header.Key}: {value}");
					}
				}

				if (EnableContentLogging)
				{
					string content = await request.Content.ReadAsStringAsync();

					message.AppendLine(content);
				}
			}
		}

		_logger.Log(
			LogLevel.Information,
			new EventId(100, "RequestStart"),
			message,
			null,
			(state, ex) => state.ToString()
		);
	}

	private async Task LogHttpResponse(Guid requestId, HttpResponseMessage response, TimeSpan duration)
	{
		var message = new StringBuilder();

		message.AppendLine(
			$"Received HTTP response (Id: {requestId}) after {duration.TotalMilliseconds}ms - {response.StatusCode} ({(int)response.StatusCode})");

		if (_logger.IsEnabled(LogLevel.Trace))
		{
			foreach (KeyValuePair<string, IEnumerable<string>> header in response.Headers)
			{
				foreach (string value in header.Value)
				{
					message.AppendLine($"{header.Key}: {value}");
				}
			}

			foreach (KeyValuePair<string, IEnumerable<string>> header in response.Content.Headers)
			{
				foreach (string value in header.Value)
				{
					message.AppendLine($"{header.Key}: {value}");
				}
			}

			if (EnableContentLogging)
			{
				string content = await response.Content.ReadAsStringAsync();

				message.AppendLine(content);
			}
		}

		_logger.Log(
			LogLevel.Information,
			new EventId(101, "RequestEnd"),
			message,
			null,
			(state, _) => state.ToString()
		);
	}
}
