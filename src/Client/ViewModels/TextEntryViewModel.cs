using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using IntelliTect.Example.BlazorMvvm.Shared;

namespace IntelliTect.Example.BlazorMvvm.Client.ViewModels;

public partial class TextEntryViewModel : RecipientViewModelBase<ConvertHexToAsciiMessage>
{
    [ObservableProperty]
    private string? _asciiText;

    public override void Receive(ConvertHexToAsciiMessage message)
    {
        var ascii = string.Empty;

        for (var i = 0; i < message.HexToConvert.Length; i += 2)
        {
            var hs = message.HexToConvert.Substring(i, 2);
            var decimalVal = Convert.ToUInt32(hs, 16);
            var character = Convert.ToChar(decimalVal);
            ascii += character;
        }

        AsciiText = ascii;
    }

    public override Task Loaded()
    {
        IsActive = true;
        return base.Loaded();
    }

    [RelayCommand]
    public virtual void SendToHexConverter()
    {
        Messenger.Send(new ConvertAsciiToHexMessage(AsciiText ?? string.Empty));
    }
}