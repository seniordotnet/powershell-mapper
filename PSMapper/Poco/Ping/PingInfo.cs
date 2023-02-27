using System.Text.Json.Serialization;

namespace PSMapper.Poco.Ping;

public class PingInfo
{
    [JsonPropertyName("domain")]
    public string? Domain { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IpAddress { get; set; }

    public class PingInfoData
    {
        [JsonPropertyName("ttl")]
        public int Ttl { get; set; }
        
        [JsonPropertyName("time")]
        public int Time { get; set; }
        
        [JsonPropertyName("bufferSize")]
        public int BufferSize { get; set; }
    }
}