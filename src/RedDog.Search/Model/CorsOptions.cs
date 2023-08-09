using System.Text.Json.Serialization;

namespace RedDog.Search.Model
{
    public class CorsOptions
    {
        public CorsOptions()
        {
            AllowedOrigins = new[] {"*"};
        }

        [JsonPropertyName("allowedOrigins")]
        public string[] AllowedOrigins
        {
            get;
            set;
        }

        [JsonPropertyName("maxAgeInSeconds")]
        public long MaxAgeInSeconds
        {
            get;
            set;
        }
    }
}