using Newtonsoft.Json;

namespace WeatherApi.Config
{
    public class Error
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public string? Path { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
