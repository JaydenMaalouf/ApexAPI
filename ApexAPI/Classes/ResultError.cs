using Newtonsoft.Json;

namespace ApexLegendsAPI.Classes
{
    public class ResultError
    {
        internal ResultError() { }

        [JsonProperty("error")]
        public string ErrorCode { get; internal set; }
        public bool IsError => !string.IsNullOrWhiteSpace(ErrorCode);
    }
}
