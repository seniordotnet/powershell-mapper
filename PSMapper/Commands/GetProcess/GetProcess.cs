using System.Diagnostics;
using System.Management.Automation;
using PSMapper.Commands.IPsCommands;
using PSMapper.Poco.GetProcess;

namespace PSMapper.Commands.GetProcess;

public sealed class GetProcess : PsCommand, IPsCommandEmpty<GetProcessInfo>
{
    /// <summary>
     /// Ctor. Accept pw as parameter.
     /// </summary>
     /// <param name="powerShell"></param>
     public GetProcess(PowerShell powerShell) : base(powerShell)
     {
     }

     /// <summary>
     /// Ctor. Create new pw.
     /// </summary>
     public GetProcess()
     {
     }

     public async Task<GetProcessInfo> ExecuteAsync()
     {
         PowerShell.AddCommand("Get-Process");

         var result = await PowerShell.InvokeAsync();

         return new GetProcessInfo
         {
             ProccessInfoDatas = result.AsParallel().Select(x => (Process)x.BaseObject).ToList()
         };
     }
}