using Windows.ApplicationModel.Background;
using Windows.Storage;

namespace BackgroundTasks
{
    public sealed class SimpleBackgroundTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            // Get a storage manager for the local storage system.
            var localSettings = ApplicationData.Current.LocalSettings;

            // Store the desired values.
            localSettings.Values["SimpleBackgroundTask"] = "Executed!";
        }
    }
}
