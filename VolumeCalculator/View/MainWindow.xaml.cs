using Domain.Common;
using Domain.Data;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VolumeCalculator.ViewModel;

namespace VolumeCalculator.View
{
    public partial class MainWindow : Window
    {
        private readonly FileReaderFactory _readerFactory;

        public MainWindow(FileReaderFactory readerFactory)
        {
            _readerFactory = readerFactory ?? throw new ArgumentNullException(nameof(readerFactory));

            InitializeComponent();

            DataContext = new MainWindowViewModel();

            DataObject.AddPastingHandler(FluidContact, FluidContact_OnPaste);
        }

        private void TopHorizonFileNameBrowse_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = GetFileDialog();

            if (openFileDialog.ShowDialog() == true) TopHorizonFileName.Text = openFileDialog.FileName;
        }

        private void BaseHorizonFileNameBrowse_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = GetFileDialog();

            if (openFileDialog.ShowDialog() == true) BaseHorizonFileName.Text = openFileDialog.FileName;
        }

        private static OpenFileDialog GetFileDialog()
        {
            return new OpenFileDialog
            {
                Multiselect = false,
                Filter = "csv files (*.csv)|*.csv|txt files (*.txt)|*.txt|All files (*.*)|*.*",
                InitialDirectory = @"C:\",
                Title = "Please select a file with depth values"
            };
        }

        private void TopHorizonFileName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calculate.IsEnabled = InputIsValid();
        }

        private void BaseHorizonFileName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calculate.IsEnabled = InputIsValid();
        }

        private bool InputIsValid()
        {
            return TopHorizonFileName.Text.IsValidPath() &&
                   BaseHorizonFileName.Text.IsValidPath();

        }

        private void FluidContact_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = string.IsNullOrEmpty(e.Text) || !DecimalValidator.IsValid(e.Text);
        }

        private void FluidContact_OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            var text = e.SourceDataObject.GetData(DataFormats.UnicodeText) as string;

            if (string.IsNullOrEmpty(text) || !DecimalValidator.IsValid(text))
            {
                e.CancelCommand();
            }
        }

        private void FluidContact_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (FluidContact.Text.Length == 0)
            {
                FluidContact.Text = "0";
            }
        }

        private async void Calculate_Click(object sender, RoutedEventArgs e)
        {
            var topGrid = await _readerFactory.GetFileReader(TopHorizonFileName.Text).ReadAsync();
            var baseGrid = await _readerFactory.GetFileReader(BaseHorizonFileName.Text).ReadAsync();

        }
    }
}
