namespace MauiPrismDialogBackAndroid.ViewModels;

public class DialogViewModel : BindableBase, IDialogAware
{
    public DialogViewModel(INavigationService navigationService)
    {
    }

    public DialogCloseListener RequestClose { get; }

    public bool CanCloseDialog()
    {
        return true;
    }

    public void OnDialogClosed()
    {
    }

    public void OnDialogOpened(IDialogParameters parameters)
    {
    }
}