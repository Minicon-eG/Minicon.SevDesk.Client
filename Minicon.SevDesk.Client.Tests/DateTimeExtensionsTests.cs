using FluentAssertions;
using Minicon.SevDesk.Client.Extensions;

namespace Minicon.SevDesk.Client.Tests;

public class DateTimeExtensionsTests
{
	[Fact]
	public void ToSevDeskInt_GivenNull_ShouldReturnNull()
	{
		// Arrange 
		DateTime? dateTime = null;

		// Act
		int? result = dateTime.ToSevDeskInt();

		// Assert
		result.Should().BeNull();
	}

	[Fact]
	public void ToSevDeskInt_GivenDateTime_ShouldReturnFormattedInt()
	{
		// Arrange 
		DateTime? dateTime = new DateTime(2022, 03, 15);

		// Act
		int? result = dateTime.ToSevDeskInt();

		// Assert
		result.Should().Be(20220315);
	}
}
