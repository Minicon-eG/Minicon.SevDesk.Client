using Microsoft.Extensions.Options;

namespace Minicon.SevDesk.Client;

internal class OptionsMonitor<T> : IOptionsMonitor<T> where T : class
{
    private readonly IOptions<T> _options;

    public OptionsMonitor(IOptions<T> options)
    {
        _options = options;
    }

    public T CurrentValue => _options.Value;

    public T Get(string name) => _options.Value;

    public IDisposable OnChange(Action<T, string> listener) => new NullDisposable();

    private class NullDisposable : IDisposable
    {
        public void Dispose() { }
    }
}