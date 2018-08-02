using System;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using STO.Model;
using STO.Model.Abstractions;

namespace STO.ViewModel
{
    public class VehicleRegistationViewModel : INotifyPropertyChanged
    {
        const int CostPerUnitRepair = 10;

        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>(GetEnumerableOfType<Vehicle>());

        private Vehicle _currentVehicleType;
        public Vehicle CurrentVehicleType
        {
            get { return _currentVehicleType; }
            set
            {
                if (_currentVehicleType == value) return;
                Type T = value.GetType();
                _currentVehicleType = (Vehicle)Activator.CreateInstance(T);
                CurrentPart = _currentVehicleType.Parts[0];
                OnPropertyChanged();
            }
        }

        private VehiclePart _currentPart;
        public VehiclePart CurrentPart
        {
            get { return _currentPart; }
            set
            {
                if (_currentPart == value) return;
                _currentPart = value;
                OnPropertyChanged();
            }
        }

        public ICommand RepairCommand { get; set; }
        public ICommand ServiceChangedCommand { get; set; }

        public VehicleRegistationViewModel()
        {
            RepairCommand = new RelayCommand(p => this.Repair());
            ServiceChangedCommand = new RelayCommand<int>(p => this.ServiceChanged(p));
        }

        private void ServiceChanged(object param)
        {
            CurrentVehicleType.ServiceCost += (int)param;
        }

        private void Repair()
        {
            CurrentVehicleType.RepairCost += (100 - CurrentPart.State) * CostPerUnitRepair;
            CurrentPart.State = 100;
        }

        public static IEnumerable<T> GetEnumerableOfType<T>() where T : class
        {
            List<T> objects = new List<T>();

            foreach (Type type in Assembly.GetAssembly(typeof(T)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
            {
                objects.Add((T)Activator.CreateInstance(type));
            }
            return objects;
        }

        #region INotifyPropertyChangedMembers
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
