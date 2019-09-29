# OverView
## This is a dotnet core simulator app for docker or local enviromnent
## Pass device connection string and send interval to the simulator then it will send random temperature and humidity to azure iothub

## Precondition:
* dotnet core 2.2.100 ( windows x64 download:https://download.visualstudio.microsoft.com/download/pr/7ae62589-2bc1-412d-a653-5336cff54194/b573c4b135280fb369e671a8f477163a/dotnet-sdk-2.2.100-win-x64.exe)
* docker ce ( windows 10 x64 download: https://hub.docker.com/editions/community/docker-ce-desktop-windows)

## For docker environment

1. download code and exploded, for example  D:\

2. cd D:\docker_dotnetcore_device_2_iothub_simulator-master\app

3. run commond: dotnet publish -c Release

4. cd D:\docker_dotnetcore_device_2_iothub_simulator-master\

5. run commond: docker build -t dotnet_core_device_to_iothub_simulator -f Dockerfile .  

6. run comond:  docker run -it  --rm  dotnet_core_device_to_iothub_simulator  "{your device connection string to iothub}" "{num of send interval,for example 2 }"

7. if simulator run successfully, you will see on your screen:

> This is a .net core device simulator in docker or vs/vscode.  
> The app need 2 parameters:  
> the first one is Iot device connection string, you can hard code set s_connectionString= you device connection string,  
> the second one is transmission interval(default is 1s) . Ctrl-C to exit.  
> Args_Param0:{xxx.xxx.xxx}  
> Args_Param1:5  
> 09/29/2019 09:58:41 > Sending message: {"temperature":"22.71","humidity":"73.87"}  
> 09/29/2019 09:58:46 > Sending message: {"temperature":"22.40","humidity":"63.79"}  

## For local(dotnet/vs/vscode) environment
1. download code and exploded, for example  D:\

2. cd D:\docker_dotnetcore_device_2_iothub_simulator-master\app

3. Modify Program.cs, set s_connectionString = "{your device connection string}",endInterval = {num of send interval,for example 2};

4. Save Program.cs

5. run commond: dotnet run

6. you can also run the solution in vs or vscode

 