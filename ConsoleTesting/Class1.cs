using System.Management.Automation;
using PowershellMapper;
using PowershellMapper.Commands;

namespace ConsoleTesting;

public class Class1
{
    public static async Task Main()
    {
        using var pw = PowerShell.Create();

        Arp arp = new Arp(pw);
        var response = await arp.ExecuteAsync();

        Console.WriteLine(response.Interface);
        
        foreach (var arpInfo in response.Rows)
        {
            Console.WriteLine($"{arpInfo.InternetAddress} {arpInfo.PhysicalAddress} {arpInfo.Type}");
        }
    }
}