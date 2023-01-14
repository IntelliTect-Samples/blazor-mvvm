using System.ComponentModel;

namespace IntelliTect.Example.BlazorMvvm.Client.ViewModels;

public interface IViewModelBase : INotifyPropertyChanged
{
    Task OnInitializedAsync();
    Task Loaded();
}