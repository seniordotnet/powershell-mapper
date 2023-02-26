using System.Management.Automation;

namespace PSMapper.Commands.Vpn;

public sealed class ConnectToVpn : IPsCommand, IPsCommandArg<bool>
{
    private readonly PowerShell _powerShell;
    
    /// <summary>
    /// Ctor. Connect to a VPN
    /// </summary>
    /// <param name="powerShell"></param>
    public ConnectToVpn(PowerShell powerShell)
    {
        _powerShell = powerShell;
    }
    
    /// <summary>
    /// Ctor. Create a new PowerShell instance
    /// </summary>
    public ConnectToVpn()
    {
        _powerShell = PowerShell.Create();
    }
    
    /// <summary>
    /// Connect to a VPN
    /// </summary>
    /// <param name="vpnName">Vpn name</param>
    /// <returns></returns>
    public async Task<bool> ExecuteAsync(object vpnName)
    {
        _powerShell
            .AddCommand("rasdial")
            .AddParameter((string)vpnName, null);

        await _powerShell.InvokeAsync();
        
        return true;
    }
}