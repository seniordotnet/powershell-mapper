using System.Text.Json.Serialization;

namespace PSMapper.Poco.Ping;

public class PingInfo
{
    [JsonPropertyName("domain")] public string? Domain { get; set; }

    [JsonPropertyName("ipAddress")] public string? IpAddress { get; set; }

    [JsonPropertyName("data")] public List<PingInfoData> Data { get; set; } = new();

    [JsonPropertyName("sent")] public int Sent { get; set; }

    [JsonPropertyName("received")] public int Received { get; set; }

    [JsonPropertyName("lost")] public int Lost { get; set; }
    
    [JsonPropertyName("min")] public string? Min { get; set; }
    
    [JsonPropertyName("max")] public string? Maximum { get; set; }
    
    [JsonPropertyName("avg")] public string? Average { get; set; }

    public class PingInfoData
    {
        [JsonPropertyName("ttl")] public int Ttl { get; set; }

        [JsonPropertyName("time")] public int Time { get; set; }

        [JsonPropertyName("bufferSize")] public int BufferSize { get; set; }
    }
}