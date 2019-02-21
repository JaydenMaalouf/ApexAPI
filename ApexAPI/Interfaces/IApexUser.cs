using System;

using ApexLegendsAPI.Enums;

namespace ApexLegendsAPI.Interfaces
{
    public interface IApexUser
    {
        Guid UserId { get; }
        string Username { get; }
        ApexPlatformTypes Platform { get; }
        string AvatarURL { get; }
        ApexLegendTypes CurrentLegend { get; }
    }
}
