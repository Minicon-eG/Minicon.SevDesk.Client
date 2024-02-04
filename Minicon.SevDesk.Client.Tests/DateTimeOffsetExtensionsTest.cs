using FluentAssertions;
using Minicon.SevDesk.Client.Extensions;

namespace Minicon.SevDesk.Client.Tests;

public class DateTimeOffsetExtensionsTest
{
	[Fact]
	public void ToSevDeskInt_NullOffset_ReturnsNull()
	{
		// Arrange
		DateTimeOffset? offset = null;

		// Act
		string? result = offset.ToSevDeskDate();

		// Assert
		result.Should().BeNull();
	}

	[Fact]
	public void ToSevDeskInt_ValidOffset_ReturnsCorrectInt()
	{
		// Arrange
		DateTimeOffset? offset = new DateTimeOffset(2023, 03, 02, 0, 0, 0, TimeSpan.Zero);

		// Act
		string? result = offset.ToSevDeskDate();

		// Assert
		result.Should().Be("02.03.2023");
	}
}
