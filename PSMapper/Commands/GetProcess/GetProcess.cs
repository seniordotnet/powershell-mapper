using System.Diagnostics;
using System.Management.Automation;
using PSMapper.Poco.GetProcess;

namespace PSMapper.Commands.GetProcess;

public class GetProcess : ICommand<GetProcessInfo>
{
     private readonly PowerShell _powerShell;
     
     /// <summary>
     /// Ctor. Accept pw as parameter.
     /// </summary>
     /// <param name="powerShell"></param>
     public GetProcess(PowerShell powerShell)
     {
         _powerShell = powerShell;
     }

     /// <summary>
     /// Ctor. Create new pw.
     /// </summary>
     public GetProcess()
     {
         _powerShell = PowerShell.Create();
     }

     public async Task<GetProcessInfo> ExecuteAsync()
     {
         _powerShell.AddCommand("Get-Process");

         var result = await _powerShell.InvokeAsync();

         return new GetProcessInfo
         {
             ProccessInfoDatas = result.AsParallel().Select(x => (Process)x.BaseObject).ToList()
         };
     }
}