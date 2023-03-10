using System.Management.Automation;

namespace PSMapper.Commands.IPsCommands;

public abstract class PsCommand
{
    protected PowerShell PowerShell { get; }
    
    protected PsCommand(PowerShell powerShell)
    {
        PowerShell = powerShell;
    }
    
    protected PsCommand()
    {
        PowerShell = PowerShell.Create();
    }
}