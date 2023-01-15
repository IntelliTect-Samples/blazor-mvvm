using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace IntelliTect.Example.BlazorMvvm.Client.ViewModels;

public abstract partial class RecipientViewModelBase<TMessage> : ObservableRecipient, IViewModelBase, IRecipient<TMessage> 
    where TMessage : class
{
    public virtual async Task OnInitializedAsync()
    {
        await Loaded().ConfigureAwait(true);
    }

    protected virtual void NotifyStateChanged() => OnPropertyChanged((string?)null);

    [RelayCommand]
    public virtual async Task Loaded()
    {
        await Task.CompletedTask.ConfigureAwait(false);
    }

    public abstract void Receive(TMessage message);
}