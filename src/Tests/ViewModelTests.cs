using FluentAssertions;
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

    [Theory]
    [InlineData("736F6D6520746578742068657265", "some text here")]
    [InlineData("202020", "   ")]
    [InlineData("", "")]
    public void WhenReceiveConvertHexToAsciiMessage_ItConverts(string hex, string result)
    {
        // Arrange
        var mocker = new AutoMocker();
        var sut = mocker.CreateInstance<TextEntryViewModel>();

        // Act
        sut.Receive(new ConvertHexToAsciiMessage(hex));

        // Assert
        sut.AsciiText.Should().Be(result);
    }

    [Theory]
    [InlineData("some text here", "736F6D6520746578742068657265")]
    [InlineData("   ", "202020")]
    [InlineData("", "")]
    public void WhenReceiveConvertAsciiToHexMessage_ItConverts(string ascii, string result)
    {
        // Arrange
        var mocker = new AutoMocker();
        var sut = mocker.CreateInstance<HexEntryViewModel>();

        // Act
        sut.Receive(new ConvertAsciiToHexMessage(ascii));

        // Assert
        sut.HexText.Should().Be(result);
    }
}