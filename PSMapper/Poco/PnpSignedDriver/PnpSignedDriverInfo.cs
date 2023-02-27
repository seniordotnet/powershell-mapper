using System.Text.Json.Serialization;

namespace PSMapper.Poco.PnpSignedDriver;

public class PnpSignedDriverInfo
{
    public List<PnpSignedDriverInfoData> Data { get; set; } = new();

    public class PnpSignedDriverInfoData
    {
        [JsonPropertyName("runspaceId")] public Guid? RunspaceId { get; set; }

        [JsonPropertyName("caption")] public string? Caption { get; set; }

        [JsonPropertyName("classGuid")] public Guid? ClassGuid { get; set; }

        [JsonPropertyName("compatId")] public string? CompatId { get; set; }

        [JsonPropertyName("creationClassName")]
        public string? CreationClassName { get; set; }

        [JsonPropertyName("description")] public string? Description { get; set; }

        [JsonPropertyName("deviceClass")] public string? DeviceClass { get; set; }

        [JsonPropertyName("deviceId")] public string? DeviceId { get; set; }

        [JsonPropertyName("driverProviderName")]
        public string? DriverProviderName { get; set; }

        [JsonPropertyName("driverVersion")] public string? DriverVersion { get; set; }

        [JsonPropertyName("friendlyName")] public string? FriendlyName { get; set; }

        [JsonPropertyName("hardwareId")] public string? HardwareId { get; set; }

        [JsonPropertyName("infName")] public string? InfName { get; set; }

        [JsonPropertyName("isSigned")] public bool? IsSigned { get; set; }

        [JsonPropertyName("manufacturer")] public string? Manufacturer { get; set; }

        [JsonPropertyName("pdo")] public string? Pdo { get; set; }

        [JsonPropertyName("name")] public string? Name { get; set; }
    }
}