using System.Management.Automation;
using PSMapper.Commands.PnpSignedDriver;

namespace ConsoleTesting;

public class Class1
{
    public static async Task Main()
    {
        using PowerShell? pw = PowerShell.Create();

        PnpSignedDriver pnpSignedDriver = new PnpSignedDriver(pw);
        var result = await pnpSignedDriver.ExecuteAsync();

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