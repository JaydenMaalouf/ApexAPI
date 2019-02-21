using System.Collections.Generic;

using Newtonsoft.Json;

namespace ApexLegendsAPI.Classes
{
    public class SearchResult
    {
        internal SearchResult() {}

        [JsonProperty("results")]
        public ICollection<ApexUser> Users { get; internal set; }

        [JsonProperty]
        public int TotalResults { get; internal set; }
    }
}
