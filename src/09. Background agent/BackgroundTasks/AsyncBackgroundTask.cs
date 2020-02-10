using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Storage;

namespace BackgroundTasks
{
    public sealed class AsyncBackgroundTask : IBackgroundTask
    {
        BackgroundTaskDeferral deferral;

        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            this.WriteInfo();

            deferral = taskInstance.GetDeferral();
        }

        public async void WriteInfo()
        {
            // Get a storage manager for the local storage system.
            var localSettings = ApplicationData.Current.LocalSettings;

            // Store the desired values.
            localSettings.Values["AsyncBackgroundTask"] = "Executed!";
        }
    }
}
