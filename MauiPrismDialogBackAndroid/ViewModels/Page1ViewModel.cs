using MauiPrismDialogBackAndroid.Views;

namespace MauiPrismDialogBackAndroid.ViewModels;

public class Page1ViewModel : BindableBase
{
    private readonly INavigationService _navigationService;
    private readonly IDialogService _dialogService;

    public Page1ViewModel(INavigationService navigationService, IDialogService dialogService)
    {
        _navigationService = navigationService;
        _dialogService = dialogService;
        ShowDialogCommand = new DelegateCommand(OnShowDialogCommandExecuted, ShowDialogCommandCanExecute);
        NavigatePage2Command = new DelegateCommand(OnNavigatePage2CommandExecuted, NavigatePage2CommandCanExecute);
    }

    public DelegateCommand NavigatePage2Command { get; set; }
    public bool NavigatePage2CommandCanExecute() => true;
    private void OnNavigatePage2CommandExecuted()
    {
        _navigationService.CreateBuilder().AddSegment(nameof(Page2)).NavigateAsync();
    }

    public DelegateCommand ShowDialogCommand { get; set; }
    public bool ShowDialogCommandCanExecute() => true;
    private void OnShowDialogCommandExecuted()
    {
        _dialogService.ShowDialog(nameof(DialogView));
    }
}