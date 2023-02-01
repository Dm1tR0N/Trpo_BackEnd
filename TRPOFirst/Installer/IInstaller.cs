namespace TRPOFirst.Installer;

public interface IInstaller
{
    void InstallServeses(IServiceCollection serveces, IConfiguration configuration);
}