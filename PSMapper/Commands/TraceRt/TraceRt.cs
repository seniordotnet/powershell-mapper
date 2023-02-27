using System.Management.Automation;
using PSMapper.Commands.IPsCommands;
using PSMapper.Extensions;
using PSMapper.Poco.TraceRt;

namespace PSMapper.Commands.TraceRt;

public class TraceRt : PsCommand, IPsCommandArg<TraceRtInfo?>
{
    /// <summary>
    /// Ctor. Accept powerShell instance
    /// </summary>
    /// <param name="powerShell"></param>
    public TraceRt(PowerShell powerShell) : base(powerShell)
    {
    }

    /// <summary>
    /// Ctor. Create new powerShell instance
    /// </summary>
    public TraceRt()
    {
    }
    
    private const int InfoRow = 0;
    private const int GarbageRow = 1;

    /// <summary>
    /// TraceRt command to specified domain. 30 hops
    /// </summary>
    /// <param name="domainName">domainName</param>
    /// <returns></returns>
    public async Task<TraceRtInfo?> ExecuteAsync(object domainName)
    {
        var result = (await PowerShell
            .AddCommand("tracert")
            .AddParameter((string) domainName, null)
            .InvokeAsync()).Where(x => !string.IsNullOrEmpty(x.BaseObject as string)).ToArray();

        var traceRtInfo = new TraceRtInfo();

        Parallel.For(0, result.Length, index =>
        {
            if (index == InfoRow)
            {
                var splittedRow = ((string) result[index].BaseObject).SplitRow();
                traceRtInfo.DomainName = splittedRow[3];
                traceRtInfo.IpAddress = splittedRow[4];
            }
            else if (index == GarbageRow)
            {
                
            }
            else if (index < result.Length - 1) // last row is garbage
            {
                var splittedRow = ((string) result[index].BaseObject).SplitRow();

                traceRtInfo.Data.Add(new TraceRtInfo.TraceRtInfoData()
                {
                    FirstPacket = int.Parse(splittedRow[1]),
                    SecondPacket = int.Parse(splittedRow[3]),
                    ThirdPacket = int.Parse(splittedRow[5]),
                    Destination = splittedRow[7]
                });
            }
        });

        return traceRtInfo;
    }
}