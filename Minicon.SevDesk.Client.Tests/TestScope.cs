using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Minicon.SevDesk.Client.Extensions.DependencyInjection;

namespace Minicon.SevDesk.Client.Tests;

public sealed class TestScope : ITestScope
{
	public IServiceScope ServiceScope { get; }

	public TestScope()
	{
		var services = new ServiceCollection();
		IConfigurationRoot configuration = new ConfigurationBuilder()
			.AddJsonFile("appsettings.json")
			.AddUserSecrets<AssemblyMarker>()
			.Build();
		ServiceScope = CreateScope(services, configuration);
	}

	public IServiceCollection Services { get; } = new ServiceCollection();

	private static IServiceScope CreateScope(IServiceCollection services, IConfiguration config)
	{
		services.AddSevdeskClient();
		services.Configure<SevDeskOptions>(
				config.GetSection(SevDeskOptions.SectionName)
			)
			.AddOptions<SevDeskOptions>();

		services.AddLogging(e => e.AddConsole());
		return services.BuildServiceProvider().CreateScope();
	}

	public void Dispose()
	{
		ServiceScope.Dispose();
	}
}
