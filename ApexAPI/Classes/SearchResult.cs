using Newtonsoft.Json;
using System.Collections.Generic;

namespace ApexLegendsAPI
{
    public class SearchResult
    {
        public SearchResult() {}

        [JsonProperty("results")]
        public List<ApexUser> Users { get; internal set; } = new List<ApexUser>();

        [JsonProperty]
        public int TotalResults { get; internal set; }
    }
}
