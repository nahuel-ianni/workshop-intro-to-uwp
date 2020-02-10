# Code examples
A collection of projects used during the UWP course to showcase the topics covered.

## Navigation
An application to show the [navigation basics](https://docs.microsoft.com/en-us/windows/uwp/design/basics/navigation-basics) of UWP by navigating between views and sending parameters between pages.

## View designs
An application to show the difference between an [adaptive layout](https://docs.microsoft.com/en-us/windows/uwp/design/basics/xaml-basics-adaptive-layout) and [adaptive triggers](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.AdaptiveTrigger).

## Application theme
An application to show how to configure the light or dark [theme resources](https://docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/xaml-theme-resources) from both the [App.xaml](https://github.com/nahuel-ianni/workshop-intro-to-uwp/blob/master/src/03.%20Application%20theme/ApplicationTheme/App.xaml) or [App.xaml.cs](https://github.com/nahuel-ianni/workshop-intro-to-uwp/blob/master/src/03.%20Application%20theme/ApplicationTheme/App.xaml.cs) file, showing how the most popular UI controls adapt automatically to the selected theme.

## User interface controls
An application to show how the implementation and functionality of the [Hub](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.Hub), [Master-Detail](https://docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/master-details), [Navigation Pane](https://docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/navigationview) and [Pivot](https://docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/pivot) views work.

## Application input scope
An application to show how a text box [input scope](https://docs.microsoft.com/en-us/windows/uwp/design/input/use-input-scope-to-change-the-touch-keyboard) can be configured to change the layout of the OS virtual keyboard when shown on screen.

## Application lifecycle
An application to show how the [LocalSettings](https://docs.microsoft.com/en-us/windows/uwp/design/app-settings/store-and-retrieve-app-data) system can be used to create a seamless experience for the user by retaining all the relevant info/configurations between sessions.

## Speech recognition
An application to show how to integrate with [Cortana](https://support.microsoft.com/en-us/help/17214/cortana-what-is), allowing the user to launch the application or navigate to a specific window via [voice commands](https://docs.microsoft.com/en-us/windows/uwp/design/input/speech-recognition).

The accepted commands can be found on the [VoiceCommands.xml](https://github.com/nahuel-ianni/workshop-intro-to-uwp/blob/master/src/07.%20Speech%20recognition/SpeechRecognition/Assets/VCD/VoiceCommands.xml) file located under the `Assets > VCD` folder.

## Live tiles and notifications
Application that integrates with:
- The notification system, enabling communication back and forth with pop up messages via the [toast system](https://docs.microsoft.com/en-us/windows/uwp/design/shell/tiles-and-notifications/toast-ux-guidance)
- [Live tiles](https://docs.microsoft.com/en-us/windows/uwp/design/shell/tiles-and-notifications/creating-tiles), updating the tile information when pinned to the Start menu

## Background agent
An application with a light implementation of [background tasks](https://docs.microsoft.com/en-us/windows/uwp/launch-resume/support-your-app-with-background-tasks), showing how to create and register them when the application loads.

## Phone vibration
An application that allows the user to select how long their device* should vibrate for by implementing the [VibrationDevice](https://docs.microsoft.com/en-us/uwp/api/Windows.Phone.Devices.Notification.VibrationDevice) functionality.

**Needs a phone or a vibration enabled device to test and/or debug.*

## Web browser
An application integrating the [web view](https://docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/web-view) UI control, allowing the user to surf the web.

## Maps and location
An application integrating the [location services](https://docs.microsoft.com/en-us/windows/uwp/maps-and-location/get-location) and *Maps* app from Microsoft.

## Launchers
An application providing a way of [launching applications](https://docs.microsoft.com/en-us/uwp/api/Windows.System.Launcher) from within it's own environment; both third party or system apps.
