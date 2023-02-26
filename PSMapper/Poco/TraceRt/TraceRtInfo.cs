using System.Text.Json.Serialization;

namespace PSMapper.Poco.TraceRt;

public class TraceRtInfo
{
    /// <summary>
    /// Domain name
    /// </summary>
    [JsonPropertyName("domainName")]
    public string? DomainName { get; set; }

    /// <summary>
    /// Ip address
    /// </summary>
    [JsonPropertyName("ipAddress")]
    public string? IpAddress { get; set; }

    /// <summary>
    /// Data
    /// </summary>
    [JsonPropertyName("data")]
    public List<TraceRtInfoData> Data { get; set; } = new();

    public class TraceRtInfoData
    {
        /// <summary>
        /// First packet time in ms
        /// </summary>
        [JsonPropertyName("firstPacket")]
        public int FirstPacket { get; set; }

        /// <summary>
        /// Second packet time in ms
        /// </summary>

        [JsonPropertyName("secondPacket")]
        public int SecondPacket { get; set; }

        /// <summary>
        /// Third packet time in ms
        /// </summary>

        [JsonPropertyName("thirdPacket")]
        public int ThirdPacket { get; set; }

        /// <summary>
        /// Destination
        /// </summary>
        [JsonPropertyName("ipAddress")]
        public string? Destination { get; set; }
    }
}