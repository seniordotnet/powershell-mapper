namespace PSMapper.Commands;

public interface IPsCommandEmpty<T>
{
    /// <summary>
    /// Executes command
    /// </summary>
    /// <returns><see cref="T"/></returns>
    public Task<T> ExecuteAsync();
}