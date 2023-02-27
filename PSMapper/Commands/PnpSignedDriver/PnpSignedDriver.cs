using System.Management.Automation;
using System.Windows.Input;
using PSMapper.Commands.IPsCommands;
using PSMapper.Poco.PnpSignedDriver;

namespace PSMapper.Commands.PnpSignedDriver;

public class PnpSignedDriver : PsCommand, IPsCommandEmpty<PnpSignedDriverInfo>
{
    /// <summary>
    /// Ctor. Accepts PowerShell instance to run the command.
    /// </summary>
    /// <param name="powerShell"></param>
    public PnpSignedDriver(PowerShell powerShell) : base(powerShell)
    {
    }


    /// <summary>
    /// Ctor. Creates PowerShell instance to run the command.
    /// </summary>
    public PnpSignedDriver()
    {
    }

    /// <inheritdoc/>
    public async Task<PnpSignedDriverInfo> ExecuteAsync()
    {
        var result = await PowerShell.AddScript("Get-WmiObject Win32_PnPSignedDriver").InvokeAsync();

        var pnpSignedDriverInfo = new PnpSignedDriverInfo
        {
            Data = result.AsParallel().Select(psObject =>
                new PnpSignedDriverInfo.PnpSignedDriverInfoData()
                {
                    Caption = psObject.Properties["Caption"].Value as string,
                    ClassGuid = Guid.TryParse(psObject.Properties["ClassGuid"].Value as string, out var classGuid)
                        ? classGuid
                        : null,
                    CompatId = psObject.Properties["CompatID"].Value as string,
                    CreationClassName = psObject.Properties["CreationClassName"].Value as string,
                    Description = psObject.Properties["Description"].Value as string,
                    DeviceClass = psObject.Properties["DeviceClass"].Value as string,
                    DeviceId = psObject.Properties["DeviceId"].Value as string,
                    DriverProviderName = psObject.Properties["DriverProviderName"].Value as string,
                    DriverVersion = psObject.Properties["DriverVersion"].Value as string,
                    FriendlyName = psObject.Properties["FriendlyName"].Value as string,
                    HardwareId = psObject.Properties["HardwareId"].Value as string,
                    InfName = psObject.Properties["InfName"].Value as string,
                    IsSigned =
                        bool.TryParse(psObject.Properties["IsSigned"].Value as string, out var isSigned) ? isSigned : null,
                    Manufacturer = psObject.Properties["Manufacturer"].Value as string,
                    Pdo = psObject.Properties["PDO"].Value as string,
                    Name = psObject.Properties["Name"].Value as string
                }).ToList()
        };

        return pnpSignedDriverInfo;
    }
}