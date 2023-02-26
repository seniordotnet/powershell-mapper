using System.Text.Json.Serialization;

namespace PSMapper.Poco.Vpn.VpnConnection;

public class VpnConnectionInfo
{
    public List<VpnConnectionInfoData> Data { get; set; } = new();
    
    public class VpnConnectionInfoData
    {
        [JsonPropertyName("connectionStatus")]
        public string? ConnectionStatus { get; set; }
    
        [JsonPropertyName("dnsSuffix")]
        public string? DnsSuffix { get; set; }
    
        [JsonPropertyName("guid")]
        public Guid? Guid { get; set; }
    
        [JsonPropertyName("idleDisconnectSeconds")]
        public uint IdleDisconnectSeconds { get; set; }
    
        [JsonPropertyName("isAutoTriggerEnabled")]
        public bool IsAutoTriggerEnabled { get; set; }
    
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    
        [JsonPropertyName("profileType")]
        public string? ProfileType { get; set; }
    
        [JsonPropertyName("provisioningAuthority")]
        public string? ProvisioningAuthority { get; set; }
    
        [JsonPropertyName("proxy")]
        public string? Proxy { get; set; }
    
        [JsonPropertyName("rememberCredential")]
        public bool RememberCredential { get; set; }
        
        [JsonPropertyName("tunnelType")]
        public string? TunnelType { get; set; }
        
        [JsonPropertyName("serverAddress")]
        public string? ServerAddress { get; set; }
    }
}