using System.Diagnostics;
using System.Management.Automation;
using PSMapper.Commands.Arp;
using PSMapper.Commands.Vpn;
using PSMapper.Commands.Vpn.GetVpnConnection;

namespace ConsoleTesting;

public class Class1
{
    public static async Task Main()
    {
        using PowerShell? pw = PowerShell.Create();

        DisconnectFromVpn disconnectFromVpn = new DisconnectFromVpn(pw);
        await disconnectFromVpn.ExecuteAsync("BegetVPN");


        // ConnectToVpn connectToVpn = new ConnectToVpn();
        // await connectToVpn.ExecuteAsync("BegetVPN");

        // Arp arp = new Arp(pw);
        // Stopwatch sw = new Stopwatch();
        // sw.Start();
        // var arpTable = await arp.ExecuteAsync();
        // Console.WriteLine($"Elapsed: {sw.ElapsedMilliseconds}ms");
        // foreach (var arpEntry in arpTable.Rows)
        // {
        //     Console.WriteLine($"{arpEntry.InternetAddress} {arpEntry.PhysicalAddress}");
        // }
    }
}