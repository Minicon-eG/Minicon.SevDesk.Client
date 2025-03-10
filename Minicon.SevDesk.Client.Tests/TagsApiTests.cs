using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Minicon.SevDesk.Client.Api;
using Minicon.SevDesk.Client.Extensions;
using Minicon.SevDesk.Client.Models;

namespace Minicon.SevDesk.Client.Tests;

public class TagsApiTests
{
	[Fact]
	public async Task CreateAndDeleteTags_Works()
	{
		using var scope = new TestScope<GetTagResponse>();
		ITagApi sut = scope.ServiceScope.ServiceProvider.GetRequiredService<ITagApi>();
		IVoucherApi voucher = scope.ServiceScope.ServiceProvider.GetRequiredService<IVoucherApi>();
		string guid = Guid.NewGuid().ToString();

		var testVoucher = (await voucher.GetVouchersAsync(limit: 1)).Objects.Single();
		//await sut.CreateTagAsync(
		//	guid.ToFactoryCreateBody()
		//
		//
		/*
		tag.ToTagFactoryCreateObject(
			voucher.Id,
			ObjectNameEnum.Voucher
		)
		*/
		await scope.TestAsync(
			async () =>
			{
				ModelTagCreateResponseTag createdTag = await sut.CreateTagAsync(guid.ToFactoryCreateBody(testVoucher.Id, ObjectNameEnum.Voucher));
				GetTagResponse tags = await sut.GetTagsAsync(name: guid);
				_ = await sut.DeleteTagAsync(tags.Objects.Single().Id);
				return tags;
			},
			async result =>
			{
				GetTagResponse checkTags = await sut.GetTagsAsync(name: guid);

				result.Objects.Count.Should().Be(checkTags.Objects.Count + 1);
			}
		);
	}

	[Fact]
	public async Task TagFactoryAssignTestTag_Works()
	{
		var scope = new TestScope<GetTagResponse>();
		ITagApi sut = scope.ServiceScope.ServiceProvider.GetRequiredService<ITagApi>();
		IVoucherApi voucherApi = scope.ServiceScope.ServiceProvider.GetRequiredService<IVoucherApi>();
		GetVoucherResponse voucher = await voucherApi.GetVouchersAsync(limit: 1);
		string valueOfTag = "FirstVoucher";

		GetTagResponse tags = await sut.GetTagsAsync(name: valueOfTag);
		if (tags.Objects.Count == 0)
		{
			await sut.CreateTagByFactoryAsync(
				valueOfTag.ToTagFactoryCreateObject(
					voucher.Objects.Single().Id,
					ObjectNameEnum.Voucher
				)
			);
		}

		GetTagResponse checkTags = await sut.GetTagsAsync(name: valueOfTag);
		GetTagRelationResponse result = await sut.GetTagRelationsAsync(limit: 10000, countAll: true);
		result.Objects.Count(e => e.Tag.Id == tags.Objects.Single().Id).Should().Be(1);
		checkTags.Objects.Single().Name.Should().Be(valueOfTag);
	}
}
