using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface ITagApi
{
	/// <summary>
	///     Create a new tag
	/// </summary>
	/// <remarks>
	///     Create a new tag
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body"> (optional)</param>
	/// <returns>Task of InlineResponse20030</returns>
	[Post("/Tag")]
	Task<ModelTagCreateResponseTag> CreateTagAsync(FactoryCreateBody body);

	/// <summary>
	///     Deletes a tag
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="tagId">Id of tag to delete</param>
	/// <returns>Task of InlineResponse2003</returns>
	[Delete("/Tag/{tagId}")]
	Task<DeleteResponse> DeleteTagAsync(int? tagId);

	/// <summary>
	///     Find tag by ID
	/// </summary>
	/// <remarks>
	///     Returns a single tag
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="tagId">ID of tag to return</param>
	/// <returns>Task of InlineResponse20019</returns>
	[Get("/Tag/{tagId}")]
	Task<GetTagResponse> GetTagByIdAsync(int? tagId);

	/// <summary>
	///     Retrieve tag relations
	/// </summary>
	/// <remarks>
	///     Retrieve all tag relations
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of InlineResponse20030</returns>
	[Get("/TagRelation")]
	Task<GetTagRelationResponse> GetTagRelationsAsync(
		string? name = null,
		int limit = 10000,
		int offset = 0,
		bool countAll = true
	);

	/// <summary>
	///     Retrieve tags
	/// </summary>
	/// <remarks>
	///     Retrieve all tags
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="id">ID of the Tag (optional)</param>
	/// <param name="name">Name of the Tag (optional)</param>
	/// <param name="limit"></param>
	/// <param name="offset"></param>
	/// <param name="countAll"></param>
	/// <returns>Task of InlineResponse20019</returns>
	[Get("/Tag")]
	Task<GetTagResponse> GetTagsAsync(
		int? id = null,
		string? name = null,
		int limit = 10000,
		int offset = 0,
		bool countAll = true
	);

	/// <summary>
	///     Update tag
	/// </summary>
	/// <remarks>
	///     Update an existing tag
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="tagId">ID of tag you want to update</param>
	/// <param name="body"> (optional)</param>
	/// <returns>Task of InlineResponse20019</returns>
	[Put("/Tag/{tagId}")]
	Task<GetTagResponse> UpdateTagAsync(int tagId, TagTagIdBody body);

	/// <summary>
	///     Update tag
	/// </summary>
	/// <remarks>
	///     Update an existing tag
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body"> (optional)</param>
	/// <returns>Task of InlineResponse20019</returns>
	[Post("/Tag/Factory/create")]
	Task CreateTagByFactoryAsync(TagFactoryCreateObject body);
}
