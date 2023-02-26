using System.Management.Automation;
using PSMapper.Commands.IPsCommands;
using PSMapper.Poco.Vpn.VpnConnection;

namespace PSMapper.Commands.Vpn.GetVpnConnection;

public sealed class GetVpnConnection : PsCommand, IPsCommandEmpty<VpnConnectionInfo>
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
        _powerShell.AddScript(
            "Set-ExecutionPolicy RemoteSigned; Import-Module VPNClient -Scope Global; Get-VpnConnection");

        PSDataCollection<PSObject>? results = await _powerShell.InvokeAsync();

        return new VpnConnectionInfo
        {
            Data = results.AsParallel().Select(x => new VpnConnectionInfo.VpnConnectionInfoData
            {
                ConnectionStatus = x.Properties["ConnectionStatus"].Value as string,
                DnsSuffix = x.Properties["DnsSuffix"].Value as string,
                Guid = Guid.TryParse(x.Properties["Guid"].Value as string, out Guid guid) ? guid : null,
                IdleDisconnectSeconds = (uint) x.Properties["IdleDisconnectSeconds"].Value,
                IsAutoTriggerEnabled = (bool) x.Properties["IsAutoTriggerEnabled"].Value,
                Name = x.Properties["Name"].Value as string,
                ProfileType = x.Properties["ProfileType"].Value as string,
                ProvisioningAuthority = x.Properties["ProvisioningAuthority"].Value as string,
                Proxy = x.Properties["Proxy"].Value as string,
                RememberCredential = (bool) x.Properties["RememberCredential"].Value,
                TunnelType = x.Properties["TunnelType"].Value as string,
                ServerAddress = x.Properties["ServerAddress"].Value as string
            }).ToList()
        };
    }
}