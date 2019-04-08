﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using Domain.UnitConverter;
using VolumeCalculator.Annotations;
using VolumeCalculator.Helpers;

namespace VolumeCalculator.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _topHorizonFileName;
        private string _baseHorizonFileName;
        private decimal _gridWidth;
        private decimal _gridHeight;
        private decimal _fluidContact;
        private Unit _unit = Unit.Meter;

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
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
