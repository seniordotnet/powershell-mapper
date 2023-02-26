using System.Diagnostics;
using System.Management.Automation;
using PSMapper.Commands.Arp;

namespace ConsoleTesting;

public class Class1
{
    public static async Task Main()
    {
        using PowerShell? pw = PowerShell.Create();

        Arp arp = new Arp(pw);
        Stopwatch sw = new Stopwatch();
        sw.Start();
        var arpTable = await arp.ExecuteAsync();
        Console.WriteLine($"Elapsed: {sw.ElapsedMilliseconds}ms");
        foreach (var arpEntry in arpTable.Rows)
        {
            Console.WriteLine($"{arpEntry.InternetAddress} {arpEntry.PhysicalAddress}");
        }
    }
}