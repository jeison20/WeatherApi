namespace Weather.Domain.Dtos
{
    public class WeatherDataDto
    {
        public Data? Data { get; set; }
        public Location? Location { get; set; }
    }

 
    public class Data
    {
        public string? Time { get; set; }
        public WeatherDto? Values { get; set; }
    }

    public class Location
    {
        public double? Lat { get; set; }
        public double? Lon { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
    }
}
