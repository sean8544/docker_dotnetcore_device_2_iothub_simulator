# This is a dotnet core simulator app for docker or local enviromnent

## For docker environment

download code:

dotnet publish -c Release

docker build -t dotnet_core_device_to_iothub_simulator -f Dockerfile .  

docker run -it  --rm  dotnet_core_device_to_iothub_simulator  "HostName=seanyutestiothub.azure-devices.cn;DeviceId=test01;SharedAccessKey=zMPvohvJStheyx3mL96I5SRQKt9Nvv7SamAI/g2QBM0=" "5"
