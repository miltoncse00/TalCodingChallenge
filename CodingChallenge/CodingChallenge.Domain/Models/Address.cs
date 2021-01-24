using System.Text.Json.Serialization;

namespace CodingChallenge.Domain
{
    public class Address
    {
        [JsonPropertyName("ip")]
        public string IP { get; set; }
        
        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        [JsonPropertyName("country_name")]
        public string CountryName { get; set; }

        [JsonPropertyName("region_code")]
        public string RegionCode { get; set; }

        [JsonPropertyName("region_name")]
        public string RegionName { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("zip")]
        public string zip { get; set; }
    }
}
