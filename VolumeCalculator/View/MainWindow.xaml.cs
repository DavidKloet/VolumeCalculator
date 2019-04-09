using Domain.Calculator;
using Domain.Common;
using Domain.Data;
using Domain.UnitConverter;
using Microsoft.Win32;
using Services.Data;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VolumeCalculator.Helpers;
using VolumeCalculator.ViewModel;

namespace VolumeCalculator.View
{
    public partial class MainWindow
    {
        private readonly FileReaderFactory _readerFactory;
        private readonly MainWindowViewModel _model = new MainWindowViewModel();

        public MainWindow(FileReaderFactory readerFactory)
        {
            _readerFactory = readerFactory ?? throw new ArgumentNullException(nameof(readerFactory));

            InitializeComponent();

            DataContext = _model;

            DataObject.AddPastingHandler(GridWidth, NumericOnly_OnPaste);
            DataObject.AddPastingHandler(GridHeight, NumericOnly_OnPaste);
            DataObject.AddPastingHandler(FluidContact, NumericOnly_OnPaste);
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

        private void NumericOnly_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = string.IsNullOrEmpty(e.Text) || !DecimalValidator.IsValid(e.Text);
        }

        private static void NumericOnly_OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            var text = e.SourceDataObject.GetData(DataFormats.UnicodeText) as string;

            if (string.IsNullOrEmpty(text) || !DecimalValidator.IsValid(text))
            {
                e.CancelCommand();
            }
        }

        private void NumericOnly_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            var control = (TextBox)sender;

            if (control.Text.Length == 0)
            {
                control.Text = "0";
            }
        }

        private async void Calculate_Click(object sender, RoutedEventArgs e)
        {
            var baseGridReader = _readerFactory.GetFileReader(_model.BaseHorizonFileName);
            var topGridReader = _readerFactory.GetFileReader(_model.TopHorizonFileName);

            var calculator = VolumeCalculatorFactory.GetCalculator();
            var unitConverter = UnitConverterFactory.GetConverter(_model.Unit);
            var logger = new TextBlockLogger(Results);

            Results.Inlines.Clear();

            await calculator.CalculateAsync(baseGridReader, topGridReader,
                (NonNegativeDecimal)_model.GridWidth, (NonNegativeDecimal)_model.GridHeight,
                (NonNegativeDecimal)_model.FluidContact, unitConverter, logger);
        }
    }
}
