using System.ComponentModel;
using System.Runtime.CompilerServices;
using VolumeCalculator.Annotations;

namespace VolumeCalculator.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _topHorizonFileName;
        private string _baseHorizonFileName;
        private decimal _fluidContact;

        public event PropertyChangedEventHandler PropertyChanged;

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

        [NotifyPropertyChangedInvocator]
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
