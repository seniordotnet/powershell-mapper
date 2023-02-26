using System.Text.Json.Serialization;

namespace PSMapper.Poco.TraceRt;

public class TraceRtInfo
{
    [JsonPropertyName("domainName")] public string? DomainName { get; set; }

    [JsonPropertyName("ipAddress")] public string? IpAddress { get; set; }

    [JsonPropertyName("data")] public List<TraceRtInfoData> Data { get; set; } = new();

    public class TraceRtInfoData
    {
        [JsonPropertyName("firstPacket")] public int FirstPacket { get; set; }

        [JsonPropertyName("secondPacket")] public int SecondPacket { get; set; }

        [JsonPropertyName("thirdPacket")] public int ThirdPacket { get; set; }

        [JsonPropertyName("ipAddress")] public string? IpAddress { get; set; }
    }
}