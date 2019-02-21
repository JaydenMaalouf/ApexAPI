using System;
using System.Collections.Generic;
using System.Text;

namespace ApexLegendsAPI.Interfaces
{
    public interface IApexUser
    {
        string UserId { get; }
        string Name { get; }
        ApexPlatform Platform { get; }
        string AvatarURL { get; }
        ApexLegendTypes CurrentLegend { get; }
        int Level { get; }
        int Kills { get; }
    }
}
