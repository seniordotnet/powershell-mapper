using System.Text.Json.Serialization;

namespace PowershellMapper.Poco.Arp;

public class ArpInfo
{
    [JsonPropertyName("interface")]
    public string? Interface { get; set; }

    public List<Data> Rows { get; set; } = new();

    public class Data
    {
        [JsonPropertyName("internetAddress")]
        public string? InternetAddress { get; set; }
    
        [JsonPropertyName("physicalAddress")]
        public string? PhysicalAddress { get; set; }
    
        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}