using System.Management.Automation;
using PSMapper.Commands.IPsCommands;

namespace PSMapper.Commands.Vpn;

public sealed class ConnectToVpn : PsCommand, IPsCommandArg<bool?>
{
    /// <summary>
    /// Ctor. Connect to a VPN
    /// </summary>
    /// <param name="powerShell"></param>
    public ConnectToVpn(PowerShell powerShell) : base(powerShell){}

    /// <summary>
    /// Ctor. Create a new PowerShell instance
    /// </summary>
    public ConnectToVpn()
    {
    }
    
    /// <summary>
    /// Connect to a VPN
    /// </summary>
    /// <param name="vpnName">Vpn name</param>
    /// <returns></returns>
    public async Task<bool?> ExecuteAsync(object vpnName)
    {
        await PowerShell
            .AddCommand("rasdial")
            .AddParameter((string)vpnName, null)
            .InvokeAsync();

        return true;
    }
}