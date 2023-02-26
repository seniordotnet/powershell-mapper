﻿namespace PSMapper.Commands.IPsCommands;

public interface IPsCommandArg<T>
{
    /// <summary>
    /// Executes command
    /// </summary>
    /// <returns><see cref="T"/></returns>
    public Task<T> ExecuteAsync(object arg);
}