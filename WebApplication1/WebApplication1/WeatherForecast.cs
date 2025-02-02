namespace WebApplication1
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public string TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
