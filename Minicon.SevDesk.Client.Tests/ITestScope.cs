using Microsoft.Extensions.DependencyInjection;

namespace Minicon.SevDesk.Client.Tests;

public interface ITestScope : IDisposable
{
	IServiceScope ServiceScope { get; }
	IServiceCollection Services { get; }
}
