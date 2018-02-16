
namespace Lands.Models
{
    //El usin hay que aplicarlo para poder que se active el [JsonProperty(PropertyName = "")]
    using Newtonsoft.Json;
    class Currency
    {
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }

    }
}
