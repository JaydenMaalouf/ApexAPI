[![NuGet](https://img.shields.io/badge/nuget-1.0.0-brightgreen.svg)](https://www.nuget.org/packages/ApexAPI/)
[![Discord](https://discordapp.com/api/guilds/548060839450640385/widget.png)](https://discord.gg/venV8Sz)

# ApexAPI - C# Apex Legends API
An unofficial .NET API Wrapper for the Apex Tab API (http://apextab.com)
Documentation is found below!

## Installation
Our stable build is available from NuGet through the ApexAPI metapackage:
- [ApexAPI](https://www.nuget.org/packages/ApexAPI/)

## Getting Started
Once you have added the NuGet Package to your Project, you will need to add the `using ApexLegendsAPI;` to your class header.
Then simply instance the ApexAPI class with your API key, like so:
```csharp
var API = new ApexAPI();
```
Now you can easily make calls to the API.

## GetUserAsync()
If you already know a user's Guid or Username, you can use the `GetUserAsync()` method to return an `ApexUser` object.
- Username:
```csharp
var user = API.GetUserAsync("username");
```
- Guid:
```csharp
var user = API.GetUserAsync(Guid);
```

**Don't forget:** By default the API Wrapper will use `PC` as the desired User platform. 
You can easily bypass this by specifying a `ApexPlatformType` with the `GetUserAsync()` function.
```csharp
var user = API.GetUserAsync(Guid, ApexPlatformType.XBL);
```

## GetUsersAsync()
Same as `GetUserAsync()` but allows to search by generic terms.
- This will return any users who's username starts with `user`:
```csharp
var user = API.GetUsersAsync("user");
```
  
## GetStatsAsync()
If you're wanting to get a user's stats, you can simply use `.GetStatsAsync();` and it will return the requested stats.
```csharp
var user = API.GetUserAsync("username");
var stats = await user.GetStatsAsync();
```

**NOTE: THE API WILL ONLY RETURN VALID DATA FOR THE CURRENT ACTIVE LEGEND FOR THE USER**

Thanks for using my wrapper <3 By Kanga#8041