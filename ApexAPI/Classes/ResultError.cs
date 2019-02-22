using Newtonsoft.Json;

namespace ApexLegendsAPI.Classes
{
    public class ResultError
    {
        internal ResultError() { }

        [JsonProperty("error")]
        public string ErrorMessage { get; internal set; }
        public bool IsError => !string.IsNullOrWhiteSpace(ErrorMessage);
    }
}
