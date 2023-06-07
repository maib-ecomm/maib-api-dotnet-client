@echo off

set /p version=Type version of .nupkg file:

dotnet nuget push .\bin\Release\MerchantHub.Connector.Proxy.Api.%version%.nupkg --source https://git.maib.local/api/v4/projects/185/packages/nuget/index.json

pause
