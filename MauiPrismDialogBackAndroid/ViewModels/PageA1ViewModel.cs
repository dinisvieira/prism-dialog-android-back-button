using MauiPrismDialogBackAndroid.Views;

namespace MauiPrismDialogBackAndroid.ViewModels;

public class PageA1ViewModel : BindableBase
{
    private readonly INavigationService _navigationService;
    private readonly IDialogService _dialogService;

    public PageA1ViewModel(INavigationService navigationService, IDialogService dialogService)
    {
        _navigationService = navigationService;
        _dialogService = dialogService;
        ShowDialogCommand = new DelegateCommand(OnShowDialogCommandExecuted, ShowDialogCommandCanExecute);
        NavigatePageA2Command = new DelegateCommand(OnNavigatePageA2CommandExecuted, NavigatePageA2CommandCanExecute);
    }

    public DelegateCommand NavigatePageA2Command { get; set; }
    public bool NavigatePageA2CommandCanExecute() => true;
    private void OnNavigatePageA2CommandExecuted()
    {
        _navigationService.CreateBuilder().AddSegment(nameof(PageA2)).NavigateAsync();
    }

    public DelegateCommand ShowDialogCommand { get; set; }
    public bool ShowDialogCommandCanExecute() => true;
    private void OnShowDialogCommandExecuted()
    {
        _dialogService.ShowDialog(nameof(DialogView));
    }
}