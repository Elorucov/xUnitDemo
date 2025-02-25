using DotnetUnitTestDemo;
using DotnetUnitTestDemo.Controllers;

namespace TestsProject;

public class WeatherForecastControllerTest {
    readonly WeatherForecastController controller;

    public WeatherForecastControllerTest() {
        controller = new WeatherForecastController();
    }

    [Fact]
    public void IsNotEmpty() {
        IEnumerable<WeatherForecast> result = controller.Get();

        bool isNotEmpty = result.Count() > 0;
        Assert.True(isNotEmpty, "forecasts list should not empty");
    }

    [Theory]
    [InlineData("Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching")]
    public void HasOnlySupportedSummaries(params string[] value) {
        IEnumerable<WeatherForecast> data = controller.Get();

        foreach (WeatherForecast forecast in data) {
            Assert.True(value.Contains(forecast.Summary), "forecast summary is invalid");
        }
    }
}