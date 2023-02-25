using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace PSMapper.Poco.GetProcess;

public class GetProcessInfo
{
    [JsonPropertyName("npm")]
    public int Npm { get; set; }
    
    [JsonPropertyName("pm")]
    public double Pm { get; set; }
    
    [JsonPropertyName("ws")]
    public double Ws { get; set; }
    
    [JsonPropertyName("cpu")]
    public double Cpu { get; set; }
    
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("su")]
    public int Si { get; set; }
    
    [JsonPropertyName("processName")]
    public string ProcessName { get; set; }
}