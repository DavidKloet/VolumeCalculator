using Domain.UnitConverter;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using VolumeCalculator.Properties;

namespace VolumeCalculator.ViewModel
{
    /// <inheritdoc />
    /// <summary>
    /// View model for the main window
    /// Monitors changes in the UI elements
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _baseHorizonFileName;
        private string _topHorizonFileName;
        private decimal _gridWidth = 3000m;
        private decimal _gridHeight = 5000m;
        private decimal _fluidContact = 9842.52m;
        private Unit _unit = Unit.Feet;

        public event PropertyChangedEventHandler PropertyChanged;

        public string BaseHorizonFileName
        {
            get => _baseHorizonFileName;
            set
            {
                if (_baseHorizonFileName != value)
                {
                    _baseHorizonFileName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string TopHorizonFileName
        {
            get => _topHorizonFileName;
            set
            {
                if (_topHorizonFileName != value)
                {
                    _topHorizonFileName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public decimal GridWidth
        {
            get => _gridWidth;
            set
            {
                if (_gridWidth != value)
                {
                    _gridWidth = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public decimal GridHeight
        {
            get => _gridHeight;
            set
            {
                if (_gridHeight != value)
                {
                    _gridHeight = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public decimal FluidContact
        {
            get => _fluidContact;
            set
            {
                if (_fluidContact != value)
                {
                    _fluidContact = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Unit Unit
        {
            get => _unit;
            set
            {
                if (_unit != value)
                {
                    _unit = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [NotifyPropertyChangedInvocator]
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
