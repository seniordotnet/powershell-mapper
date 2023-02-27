using System.Management.Automation;
using System.Net.NetworkInformation;
using PSMapper.Commands.PnpSignedDriver;
using Ping = PSMapper.Commands.Ping.Ping;

namespace ConsoleTesting;

public class Class1
{
    public static async Task Main()
    {
        using PowerShell? pw = PowerShell.Create();

        var ping = new Ping(pw);
        var result = await ping.ExecuteAsync("google.com");

        Console.WriteLine($"{result.Domain}  {result.IpAddress}");
        
        foreach(var r in result.Data)
        {
            Console.WriteLine($"{r.Time} {r.Ttl}");
        }

        Console.WriteLine($"{result.Lost} {result.Received} {result.Sent}");
        
        // PnpSignedDriver pnpSignedDriver = new PnpSignedDriver(pw);
        // var result = await pnpSignedDriver.ExecuteAsync();

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

        // Arp arp = new Arp(pw);
        // var arpTable = await arp.ExecuteAsync();
        // foreach (var arpEntry in arpTable.Rows)
        // {
        //     Console.WriteLine($"{arpEntry.InternetAddress} {arpEntry.PhysicalAddress}");
        // }
    }
}