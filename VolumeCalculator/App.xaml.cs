using Domain.Data;
using System.Windows;
using VolumeCalculator.View;

namespace VolumeCalculator
{
    public partial class App : Application
    {
        private void App_Startup(object sender, StartupEventArgs e)
        {
            var readerFactory = new FileReaderFactory();
            var window = new MainWindow(readerFactory);

            window.Show();
        }
    }
}
