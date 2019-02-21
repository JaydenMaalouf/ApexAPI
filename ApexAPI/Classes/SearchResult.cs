using Newtonsoft.Json;
using System.Collections.Generic;

namespace ApexLegendsAPI
{
    public class SearchResult
    {
        public SearchResult() {}

        [JsonProperty("results")]
        public ICollection<ApexUser> Users { get; internal set; }

        [JsonProperty]
        public int TotalResults { get; internal set; }
    }
}
