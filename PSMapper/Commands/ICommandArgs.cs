namespace PSMapper.Commands;

public interface ICommandArgs<T>
{
    /// <summary>
    /// Executes command
    /// </summary>
    /// <returns><see cref="T"/></returns>
    public Task<T> ExecuteAsync(object[] args);
}