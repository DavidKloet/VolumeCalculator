using Services.Data;
using System.Globalization;
using System.Threading;
using System.Windows;
using VolumeCalculator.View;

namespace VolumeCalculator
{
    public partial class App : Application
    {
        private void App_Startup(object sender, StartupEventArgs e)
        {
            var cultureInfo = new CultureInfo("en-US")
            {
                NumberFormat = { NumberGroupSeparator = "" }
            };

            CultureInfo.CurrentCulture = cultureInfo;

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            var readerFactory = new FileReaderFactory();
            var window = new MainWindow(readerFactory);

            window.Show();
        }
    }
}
