using System.Diagnostics;
using System.Management.Automation;
using PSMapper.Commands.Arp;
using PSMapper.Commands.TraceRt;
using PSMapper.Commands.Vpn;
using PSMapper.Commands.Vpn.GetVpnConnection;
using PSMapper.Poco.TraceRt;

namespace ConsoleTesting;

public class Class1
{
    public static async Task Main()
    {
        using PowerShell? pw = PowerShell.Create();

        // TraceRt traceRt = new TraceRt(pw);
        // TraceRtInfo traceRtInfo = await traceRt.ExecuteAsync("google.com");
        //
        // foreach (var traceRtInfoData in traceRtInfo.Data)
        // {
        //     Console.WriteLine($"{traceRtInfoData.FirstPacket} {traceRtInfoData.SecondPacket} {traceRtInfoData.ThirdPacket} {traceRtInfoData.Destination}");
        // }
        // DisconnectFromVpn disconnectFromVpn = new DisconnectFromVpn(pw);
        // await disconnectFromVpn.ExecuteAsync("BegetVPN");


        // ConnectToVpn connectToVpn = new ConnectToVpn();
        // await connectToVpn.ExecuteAsync("BegetVPN");

        Arp arp = new Arp(pw);
        var arpTable = await arp.ExecuteAsync();
        foreach (var arpEntry in arpTable.Rows)
        {
            Console.WriteLine($"{arpEntry.InternetAddress} {arpEntry.PhysicalAddress}");
        }
    }
}