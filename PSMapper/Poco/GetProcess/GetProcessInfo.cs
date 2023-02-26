using System.Diagnostics;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace PSMapper.Poco.GetProcess;

public class GetProcessInfo
{
    public List<Process>? ProccessInfoDatas { get; set; }
}