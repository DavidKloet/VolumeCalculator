using Services.Data;
using System.Globalization;
using System.Windows;
using VolumeCalculator.View;

namespace VolumeCalculator
{
    public partial class App : Application
    {
        private void App_Startup(object sender, StartupEventArgs e)
        {
            CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator = "";
            CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";

            var readerFactory = new FileReaderFactory();
            var window = new MainWindow(readerFactory);

            window.Show();
        }
    }
}
