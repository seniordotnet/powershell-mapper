using System.Management;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Microsoft.Management.Infrastructure;
using PSMapper.Poco.VpnConnection;

namespace PSMapper.Commands.GetVpnConnection;

public class GetVpnConnection : ICommand<VpnConnectionInfo>
{
    private readonly PowerShell _powerShell;

    /// <summary>
    /// Ctor. Accept pw as parameter.
    /// </summary>
    /// <param name="powerShell"></param>
    public GetVpnConnection(PowerShell powerShell)
    {
        _powerShell = powerShell;
    }

    /// <summary>
    /// Ctor. Create new pw.
    /// </summary>
    public GetVpnConnection()
    {
        _powerShell = PowerShell.Create();
    }

    public async Task<VpnConnectionInfo> ExecuteAsync()
    {
        VpnConnectionInfo vpnConnectionInfo = new();
        
        _powerShell.AddScript("Set-ExecutionPolicy RemoteSigned; Import-Module VPNClient -Scope Global; Get-VpnConnection");
        
        var results = _powerShell.Invoke();

        foreach (var result in results)
        {
            vpnConnectionInfo.Data.Add(new VpnConnectionInfo.VpnConnectionInfoData()
            {
                ConnectionStatus = result.Properties["ConnectionStatus"].Value as string,
                DnsSuffix = result.Properties["DnsSuffix"].Value as string,
                Guid = Guid.TryParse(result.Properties["Guid"].Value as string, out var guid) ? guid : null ,
                IdleDisconnectSeconds = (uint) result.Properties["IdleDisconnectSeconds"].Value,
                IsAutoTriggerEnabled = (bool) result.Properties["IsAutoTriggerEnabled"].Value,
                Name = result.Properties["Name"].Value as string,
                ProfileType = result.Properties["ProfileType"].Value as string,
                ProvisioningAuthority = result.Properties["ProvisioningAuthority"].Value as string,
                Proxy = result.Properties["Proxy"].Value as string,
                RememberCredential = (bool) result.Properties["RememberCredential"].Value,
                TunnelType = result.Properties["TunnelType"].Value as string,
                ServerAddress = result.Properties["ServerAddress"].Value as string
            });
        }
        
        return vpnConnectionInfo;
    }
}