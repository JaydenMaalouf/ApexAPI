using System;

namespace ApexLegendsAPI.Interfaces
{
    public interface IApexUser
    {
        Guid UserId { get; }
        string Name { get; }
        ApexPlatform Platform { get; }
        string AvatarURL { get; }
        ApexLegendTypes CurrentLegend { get; }
    }
}
