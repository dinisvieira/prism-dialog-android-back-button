using MauiPrismDialogBackAndroid.Views;

namespace MauiPrismDialogBackAndroid.ViewModels;

public class PageB1ViewModel : BindableBase
{
    private readonly INavigationService _navigationService;
    private readonly IDialogService _dialogService;

    public PageB1ViewModel(INavigationService navigationService, IDialogService dialogService)
    {
        _navigationService = navigationService;
        _dialogService = dialogService;
        ShowDialogCommand = new DelegateCommand(OnShowDialogCommandExecuted, ShowDialogCommandCanExecute);
    }

    public DelegateCommand ShowDialogCommand { get; set; }
    public bool ShowDialogCommandCanExecute() => true;
    private void OnShowDialogCommandExecuted()
    {
        _dialogService.ShowDialog(nameof(DialogView));
    }
}