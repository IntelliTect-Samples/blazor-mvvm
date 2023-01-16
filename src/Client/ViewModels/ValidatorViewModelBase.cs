using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components.Forms;

namespace IntelliTect.Example.BlazorMvvm.Client.ViewModels
{
    public abstract partial class ValidatorViewModelBase : ObservableValidator, IViewModelBase, IDisposable
    {
        public virtual async Task OnInitializedAsync()
        {
            await Loaded().ConfigureAwait(true);
        }

        [ObservableProperty]
        private EditContext? _editContext;

        private bool EditContextHasValue => EditContext is { };

        private IDisposable? _validator;

        partial void OnEditContextChanged(EditContext? value)
        {
            if (value is not { } context) return;

            // Adds the ValidationContext to the EditContext so we don't have
            // to have an explicit DataAnnotationValidator in the View
            _validator = context.EnableDataAnnotationsValidation();

            context.OnFieldChanged += (_, args) => OnPropertyChanged(args.FieldIdentifier.FieldName);
            context.OnValidationRequested += (_, _) => ValidateAllProperties();
        }

        [RelayCommand]
        public virtual async Task Loaded()
        {
            await Task.CompletedTask.ConfigureAwait(false);
        }

        [RelayCommand(CanExecute = nameof(EditContextHasValue))]
        protected virtual void ClearForm()
        {
            ClearErrors();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && _validator is { } disposable)
            {
                disposable.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
