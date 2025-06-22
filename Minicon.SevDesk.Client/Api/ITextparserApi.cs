using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the Textparser API endpoints
/// </summary>
public interface ITextparserApi
{
	/// <summary>
	///     Retrieve Placeholders
	/// </summary>
	/// <remarks>
	///     Retrieve all Placeholders
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="objectName">Model name</param>
	/// <param name="subObjectName">Sub model name, required if you have "Email" at objectName (optional)</param>
	/// <returns>Task of GetPlaceholderResponse</returns>
	[Get("/Textparser/fetchDictionaryEntriesByType")]
	Task<GetPlaceholderResponse> GetPlaceholderAsync(
		[AliasAs("objectName")] string objectName,
		[AliasAs("subObjectName")] string? subObjectName = null,
		CancellationToken cancellationToken = default);
}