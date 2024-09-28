using MauiPrismDialogBackAndroid.ViewModels;
using MauiPrismDialogBackAndroid.Views;
using Microsoft.Extensions.Logging;
using Prism.Navigation.Builder;

namespace MauiPrismDialogBackAndroid
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UsePrism(prism =>
                    prism.RegisterTypes(containerRegistry =>
                        {
                            containerRegistry.RegisterForNavigation<PageA1, PageA1ViewModel>();
                            containerRegistry.RegisterForNavigation<PageA2, PageA2ViewModel>();
                            containerRegistry.RegisterForNavigation<PageB1, PageB1ViewModel>();
                            containerRegistry.RegisterDialog<DialogView, DialogViewModel>();
                        })
                        .AddGlobalNavigationObserver(context => context.Subscribe(x =>
                        {
                            if (x.Type == NavigationRequestType.Navigate)
                                Console.WriteLine($"Navigation: {x.Uri}");
                            else
                                Console.WriteLine($"Navigation: {x.Type}");

                            var status = x.Cancelled ? "Cancelled" : x.Result.Success ? "Success" : "Failed";
                            Console.WriteLine($"Result: {status}");

                            if (status == "Failed" && !string.IsNullOrEmpty(x.Result?.Exception?.Message))
                                Console.Error.WriteLine(x.Result.Exception.Message);
                        }))
                        .CreateWindow(nav => nav.CreateBuilder()
                            .AddTabbedSegment(page =>
                                page.CreateTab(t =>
                                        t.AddNavigationPage()
                                            .AddSegment("PageA1")
                                            .AddSegment("PageA2"))
                                    .CreateTab(t =>
                                        t.AddNavigationPage()
                                            .AddSegment("PageB1")))
                            .NavigateAsync()))
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
