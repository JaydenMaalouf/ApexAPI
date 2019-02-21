using System;

using ApexLegendsAPI.Enums;

namespace ApexLegendsAPI.Interfaces
{
    public interface IApexUser
    {
        Guid UserId { get; }
        string Username { get; }
        ApexPlatformType Platform { get; }
        string AvatarURL { get; }
        ApexLegendType CurrentLegend { get; }
    }
}
