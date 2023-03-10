namespace PSMapper.Commands.IPsCommands;

public interface IPsCommandArgs<T>
{
    /// <summary>
    /// Executes command
    /// </summary>
    /// <returns><see cref="T"/></returns>
    public Task<T> ExecuteAsync(object[] args);
}