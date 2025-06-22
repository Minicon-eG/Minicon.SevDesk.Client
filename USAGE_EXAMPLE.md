# SevDesk Client Factory Usage Example

## Using the Factory Pattern

The `ISevDeskClientFactory` allows you to create SevDesk API clients with custom configuration without dependency injection.

### Basic Usage

```csharp
using Microsoft.Extensions.Logging;
using Minicon.SevDesk.Client;

// Create a logger factory
var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
});

// Create the factory
var factory = new SevDeskClientFactory(loggerFactory, null);

// Configure options
var options = new SevDeskOptions
{
    ApiKey = "your-api-key",
    ApiUrl = "https://my.sevdesk.de/api/v1",
    InspectJson = false
};

// Create API clients
var contactApi = factory.CreateContactApi(options);
var voucherApi = factory.CreateVoucherApi(options);

// Use the APIs
var contacts = await contactApi.GetContactsAsync();
```

### Multiple Configurations

You can use the factory to create clients with different configurations:

```csharp
// Production configuration
var prodOptions = new SevDeskOptions
{
    ApiKey = "production-api-key",
    ApiUrl = "https://my.sevdesk.de/api/v1",
    InspectJson = false
};

// Development configuration with JSON inspection
var devOptions = new SevDeskOptions
{
    ApiKey = "development-api-key",
    ApiUrl = "https://my.sevdesk.de/api/v1",
    InspectJson = true
};

// Create clients for different environments
var prodContactApi = factory.CreateContactApi(prodOptions);
var devContactApi = factory.CreateContactApi(devOptions);
```

### Using with Dependency Injection

The factory is automatically registered when using the standard DI approach:

```csharp
services.AddSevdeskClient();

// Later in your service
public class MyService
{
    private readonly ISevDeskClientFactory _factory;
    
    public MyService(ISevDeskClientFactory factory)
    {
        _factory = factory;
    }
    
    public async Task DoWork()
    {
        var options = new SevDeskOptions { /* ... */ };
        var api = _factory.CreateVoucherApi(options);
        // Use the API...
    }
}
```