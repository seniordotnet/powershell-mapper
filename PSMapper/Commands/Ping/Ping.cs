using System.Management.Automation;
using PSMapper.Commands.IPsCommands;
using PSMapper.Extensions;
using PSMapper.Poco.Ping;

namespace PSMapper.Commands.Ping;

public class Ping : PsCommand, IPsCommandArg<PingInfo>
{
    /// <summary>
    /// Ctor. Accepts <see cref="PowerShell"/> instance.
    /// </summary>
    /// <param name="powerShell"></param>
    public Ping(PowerShell powerShell) : base(powerShell)
    {
    }

    /// <summary>
    /// Default constructor for <see cref="Ping"/> command.
    /// </summary>
    public Ping()
    {
    }

    private const int InfoRow = 0;
    private const int StatisticRow = 5;
    private const int SentReceivedLostRow = 6;
    private const int GarbageRow = 7;
    private const int TimeRow = 8;

    /// <inheritdoc/>
    public async Task<PingInfo> ExecuteAsync(object domain)
    {
        var pingInfo = new PingInfo();

        PowerShell.AddCommand("ping").AddArgument((string) domain);
        
        var results = (await PowerShell.InvokeAsync()).Where(x => !string.IsNullOrWhiteSpace(((string)x.BaseObject))).ToArray();

        Parallel.For(0, results.Length, index =>
        {
            if (index == InfoRow)
            {
                var inforow = ((string)results[index].BaseObject).SplitRow();

                pingInfo.Domain = inforow[1];
                pingInfo.IpAddress = inforow[2];
            } 
            else if (index is > InfoRow and < StatisticRow)
            {
                var splittedRow = ((string)results[index].BaseObject).SplitRow();
                
                pingInfo.Data.Add(new PingInfo.PingInfoData()
                {
                    BufferSize = 32,
                    Time = int.TryParse(splittedRow[4].Split('=')[1].Replace("ms", ""), out var time) ? time : 0,
                    Ttl = int.TryParse(splittedRow[5].Split('=')[1], out var ttl) ? ttl : 0,
                });
            } 
            else if (index == SentReceivedLostRow)
            {
                var sentReceivedLostRow = ((string)results[index].BaseObject).SplitRow();
                pingInfo.Sent = int.TryParse(sentReceivedLostRow[3][..^1], out var sent) ? sent : 0;
                pingInfo.Received = int.TryParse(sentReceivedLostRow[6][..^1], out var received) ? received : 0;
                pingInfo.Lost = int.TryParse(sentReceivedLostRow[9], out var lost) ? lost : 0;
            }
            else if (index == TimeRow)
            {
                var timeRow = ((string)results[index].BaseObject).SplitRow();
                
                pingInfo.Min = timeRow[2];
                pingInfo.Maximum = timeRow[5];
                pingInfo.Average = timeRow[8];
            }
        });
        
        return pingInfo;
    }
}