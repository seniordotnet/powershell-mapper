using PSMapper.Poco.Ping;

namespace PSMapper.Commands.IPsCommands;

public interface IPsCommandArg<T>
{
    /// <summary>
    /// Executes command
    /// </summary>
    /// <returns><see cref="T"/>return null if exception happened</returns>
    public Task<T?> ExecuteAsync(object arg);
}