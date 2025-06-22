using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the TagRelation API endpoints
/// </summary>
public interface ITagRelationApi
{
	/// <summary>
	///     Retrieve tag relations
	/// </summary>
	/// <remarks>
	///     Retrieve all tag relations
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of GetTagRelationResponse</returns>
	[Get("/TagRelation")]
	Task<GetTagRelationResponse> GetTagRelationsAsync(CancellationToken cancellationToken = default);
}