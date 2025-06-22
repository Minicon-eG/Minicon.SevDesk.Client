using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the DocServer API endpoints
/// </summary>
public interface IDocServerApi
{
	/// <summary>
	///     Retrieve letterpapers
	/// </summary>
	/// <remarks>
	///     Retrieve all letterpapers with Thumb
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of GetLetterpapersWithThumbResponse</returns>
	[Get("/DocServer/getLetterpapersWithThumb")]
	Task<GetLetterpapersWithThumbResponse> GetLetterpapersWithThumbAsync(CancellationToken cancellationToken = default);

	/// <summary>
	///     Retrieve templates
	/// </summary>
	/// <remarks>
	///     Retrieve all templates
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="type">Type of the templates you want to get. (optional)</param>
	/// <returns>Task of GetTemplatesResponse</returns>
	[Get("/DocServer/getTemplatesWithThumb")]
	Task<GetTemplatesResponse> GetTemplatesAsync(
		[AliasAs("type")] string? type = null,
		CancellationToken cancellationToken = default);
}