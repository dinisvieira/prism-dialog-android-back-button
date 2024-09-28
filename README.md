# Android Hardware Back Button when using Prism DialogService
Android Hardware Back Button when using Prism DialogService closes the App if the Page underneath is the RootPage of a NavigationPage (on a TabbedPage)

The app contains two Tabs for the TabbedPage.
- The first tab automatically navigates to a second page, opening the Dialog from this page and closing it with the android back button works fine.
- The second tab stays on the root page, opening the Dialog on this one and closing it with the android back button closes the popup and also the App itself.
