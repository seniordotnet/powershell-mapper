using System.Management.Automation;
using PSMapper;
using PSMapper.Commands;
using PSMapper.Commands.GetVpnConnection;
using PSMapper.Poco.VpnConnection;

namespace ConsoleTesting;

public class Class1
{
    public static async Task Main()
    {
        using PowerShell? pw = PowerShell.Create();

        GetVpnConnection getVpnConnection = new GetVpnConnection(pw);

        VpnConnectionInfo a = await getVpnConnection.ExecuteAsync();

        foreach (var vpn in a.Data)
        {
            Console.WriteLine($"{vpn.Name}  {vpn.Guid}  {vpn.ServerAddress}");
        }
    }
}