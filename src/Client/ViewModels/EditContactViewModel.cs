using CommunityToolkit.Mvvm.Input;
using IntelliTect.Example.BlazorMvvm.Shared;
using Microsoft.AspNetCore.Components.Forms;

namespace IntelliTect.Example.BlazorMvvm.Client.ViewModels;

public partial class EditContactViewModel : ValidatorViewModelBase
{
    [ObservableProperty]
    private ContactInfo _contact = new();

    public override async Task Loaded()
    {
        EditContext = new EditContext(Contact);
        await base.Loaded();
    }

    [RelayCommand(CanExecute = nameof(HasNoErrors))]
    private void Save()
    {
        if (EditContext is { } && EditContext.Validate())
        {
            Console.WriteLine("Sending contact to server!");
        }
        else
        {
            Console.WriteLine("After validating, errors found!");
        }
    }

    private bool HasNoErrors => !HasErrors;

    protected override void ClearForm()
    {
        Contact = new();
        EditContext = new EditContext(this);
        base.ClearForm();
    }
}