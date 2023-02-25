using System.Management.Automation;

namespace PSMapper.Commands;

public interface ICommand<T>
{
    /// <summary>
    /// Executes command
    /// </summary>
    /// <returns><see cref="T"/></returns>
    public Task<T> ExecuteAsync();
}