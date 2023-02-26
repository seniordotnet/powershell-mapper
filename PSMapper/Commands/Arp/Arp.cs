using System.Management.Automation;
using PSMapper.Extensions;
using PSMapper.Poco.Arp;

namespace PSMapper.Commands;

public sealed class Arp : ICommand<ArpInfo>
{
    private readonly PowerShell _powerShell;
    
    private const int InterfaceRowIndex = 0;
    private const int ColumnNamesRowIndex = 1;

    /// <summary>
    /// Ctor. Accept pw as parameter.
    /// </summary>
    /// <param name="powerShell"></param>
    public Arp(PowerShell powerShell)
    {
        _powerShell = powerShell;
    }

    /// <summary>
    /// Ctor. Create new pw.
    /// </summary>
    public Arp()
    {
        _powerShell = PowerShell.Create();
    }

    /// <inheritdoc />
    public async Task<ArpInfo> ExecuteAsync()
    {
        _powerShell.AddCommand("arp");
        _powerShell.AddArgument("-a");

        PSObject[] response = (await _powerShell.InvokeAsync()).Where(x => !string.IsNullOrWhiteSpace(x?.BaseObject as string)).ToArray();

        ArpInfo arpInfo = new();

                
        for (int index = 0; index < response.Length; index++)
        {
            PSObject? item = response[index];
            string itemValue = (string)item.BaseObject;
                    
            switch (index)
            {
                case InterfaceRowIndex:
                {
                    string[] interfaceInfo = itemValue.SplitRow();
                    arpInfo.Interface = interfaceInfo[1];
                    break;
                }
                case ColumnNamesRowIndex:
                {
                    break;
                }
                case > InterfaceRowIndex:
                {
                    string[] arpRow = itemValue.SplitRow();
                            
                    arpInfo.Rows.Add(new ArpInfo.Data()
                    {
                        InternetAddress = arpRow[0],
                        PhysicalAddress = arpRow[1],
                        Type = arpRow[2]
                    });
                            
                    break;
                }
            }
        }

        return arpInfo;
    }
}