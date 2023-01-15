using IntelliTect.Example.BlazorMvvm.Client.ViewModels;
using IntelliTect.Example.BlazorMvvm.Shared;
using Moq;
using Moq.Contrib.HttpClient;

namespace IntelliTect.Example.BlazorMvvm.Tests;

public class ViewModelTests
{
    [Fact]
    public async Task WhenFetchDataLoaded_ItMakesApiCallForData()
    {
        // Arrange
        var mocker = new AutoMocker();
        var mock = mocker.GetMock<HttpMessageHandler>();
        var client = mock.CreateClient();
        client.BaseAddress = new Uri("http://example.com");
        mocker.Use(client);
        mock.SetupAnyRequest().ReturnsJsonResponse(Array.Empty<WeatherForecast>());

        // Act
        var sut = mocker.CreateInstance<FetchDataViewModel>();
        await sut.LoadedCommand.ExecuteAsync(null);

        // Assert
        mock.VerifyAnyRequest(Times.Once());

    }
}