using CommunityToolkit.Mvvm.Input;
using IntelliTect.Example.BlazorMvvm.Shared;

namespace IntelliTect.Example.BlazorMvvm.Client.ViewModels;

public partial class EditContactViewModel : ViewModelBase
{
    [ObservableProperty]
    private ContactInfo _contact = new();

    [RelayCommand]
    private void Save()
    {
        Contact.Validate();
        if (Contact.HasErrors)
            Console.WriteLine("After validating, errors found!");
        else
            Console.WriteLine("Sending contact to server!");
    }


    [RelayCommand]
    protected void ClearForm()
    {
        Contact = new ContactInfo();
    }
}