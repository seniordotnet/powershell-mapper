# Powershell-mapper
Object mapper for most popular commands executing results

## Installation
### .NET Cli
dotnet add package PSMapper
### Package Manager Console
NuGet\Install-Package PSMapper
## Usage
### Example

#### To get tracert mapped result
```csharp
TraceRt traceRt = new TraceRt(pw);
TraceRtInfo traceRtInfo = await traceRt.ExecuteAsync("google.com");

foreach (var traceRtInfoData in traceRtInfo.Data)
{
    Console.WriteLine($"{traceRtInfoData.FirstPacket} {traceRtInfoData.SecondPacket} {traceRtInfoData.ThirdPacket} {traceRtInfoData.Destination}");
}
```

### To get arp -a mapped result
```csharp
Arp arp = new Arp(pw);
var arpTable = await arp.ExecuteAsync();
foreach (var arpEntry in arpTable.Rows)
{
    Console.WriteLine($"{arpEntry.InternetAddress} {arpEntry.PhysicalAddress}");
}
```
