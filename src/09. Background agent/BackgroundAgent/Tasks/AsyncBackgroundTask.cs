using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Storage;

namespace BackgroundAgent.Tasks
{
    public sealed class AsyncBackgroundTask : IBackgroundTask
    {
        BackgroundTaskDeferral deferral;

        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            await this.WriteInfo();

            deferral = taskInstance.GetDeferral();
        }

        public async Task<string> WriteInfo()
        {
            // Get a storage manager for the local storage system.
            var localSettings = ApplicationData.Current.LocalSettings;

            // Store the desired values.
            localSettings.Values["AsyncBackgroundTask"] = "Executed!";

            return localSettings.Values.Keys.Count.ToString();
        }
    }
}
