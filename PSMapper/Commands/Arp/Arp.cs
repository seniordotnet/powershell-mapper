using System.Management.Automation;
using PSMapper.Commands.IPsCommands;
using PSMapper.Extensions;
using PSMapper.Poco.Arp;

namespace PSMapper.Commands.Arp;

public sealed class Arp : PsCommand, IPsCommandEmpty<ArpInfo>
{
    /// <summary>
    /// Ctor. Accept pw as parameter.
    /// </summary>
    /// <param name="powerShell"></param>
    public Arp(PowerShell powerShell) : base(powerShell)
    {
    }

    /// <summary>
    /// Ctor. Create new pw.
    /// </summary>
    public Arp()
    {
    }
    
    private const int InterfaceRowIndex = 0;
    private const int ColumnNamesRowIndex = 1;

    /// <inheritdoc />
    public async Task<ArpInfo> ExecuteAsync()
    {
        PowerShell
            .AddCommand("arp")
            .AddArgument("-a");

        var response = (await PowerShell.InvokeAsync())
            .Where(x => !string.IsNullOrWhiteSpace(x?.BaseObject as string)).ToArray();

        ArpInfo arpInfo = new();


        Parallel.For(0, response.Length, index =>
        {
            var item = response[index];
            var itemValue = (string) item.BaseObject;

            switch (index)
            {
                case InterfaceRowIndex:
                {
                    var interfaceInfo = itemValue.SplitRow();
                    arpInfo.Interface = interfaceInfo[1];
                    break;
                }
                case ColumnNamesRowIndex:
                {
                    break;
                }
                case > InterfaceRowIndex:
                {
                    var arpRow = itemValue.SplitRow();

                    arpInfo.Rows.Add(new ArpInfo.Data
                    {
                        InternetAddress = arpRow[0],
                        PhysicalAddress = arpRow[1],
                        Type = arpRow[2]
                    });

                    break;
                }
            }
        });

        return arpInfo;
    }
}