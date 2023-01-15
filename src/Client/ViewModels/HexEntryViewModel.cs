using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using IntelliTect.Example.BlazorMvvm.Shared;

namespace IntelliTect.Example.BlazorMvvm.Client.ViewModels;

public partial class HexEntryViewModel : RecipientViewModelBase<ConvertAsciiToHexMessage>
{
    [ObservableProperty]
    private string? _hexText;

    public override void Receive(ConvertAsciiToHexMessage message)
    {
        var charArray = message.AsciiToConvert.ToCharArray();
        var hexOutput = string.Empty;
        foreach (var @char in charArray)
        {
            hexOutput += $"{Convert.ToInt32(@char):X}";
        }

        HexText = hexOutput;
    }

    public override Task Loaded()
    {
        IsActive = true;
        return base.Loaded();
    }

    [RelayCommand]
    public virtual void SendToAsciiConverter()
    {
        Messenger.Send(new ConvertHexToAsciiMessage(HexText ?? string.Empty));
    }
}