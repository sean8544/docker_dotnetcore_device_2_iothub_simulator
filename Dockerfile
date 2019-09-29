FROM mcr.microsoft.com/dotnet/core/runtime:2.2

COPY app/bin/Release/netcoreapp2.2/publish/ app/

ENTRYPOINT ["dotnet", "app/device_to_iothub_demo.dll"]