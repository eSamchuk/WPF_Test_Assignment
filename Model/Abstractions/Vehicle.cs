using System;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace STO.Model.Abstractions
{
    public abstract class Vehicle : INotifyPropertyChanged
    {
        private double _averageState;
        public double AverageState
        {
            get { return _averageState; }
            set
            {
                if (_averageState == value) return;
                _averageState = value;
                OnPropertyChanged();
            }
        }

        private int _repairCost;
        public int RepairCost
        {
            get { return _repairCost; }
            set
            {
                if (_repairCost == value) return;
                _repairCost = value;
                OnPropertyChanged();
            }
        }

        private int _serviceCost;
        public int ServiceCost
        {
            get { return _serviceCost; }
            set
            {
                if (_serviceCost == value) return;
                _serviceCost = value;
                OnPropertyChanged();
            }
        }

        public virtual ObservableCollection<VehiclePart> Parts { get; set; }

        public virtual ObservableCollection<KeyValuePair<string, int>> Services { get; set; }

        public Vehicle()
        {
            Parts = GetParts();

            foreach (var item in Parts)
            {
                item.PropertyChanged += Item_PropertyChanged;
            }

            var Interfaces = this.GetType().GetInterfaces().Where(x => x.Namespace.Contains(this.GetType().Namespace));

            Services = new ObservableCollection<KeyValuePair<string, int>>();

            foreach (var Interface in Interfaces)
            {
                foreach (var Method in Interface.GetMethods())
                {
                    ServiceAttribute Attribute = (ServiceAttribute)Method.GetCustomAttribute(typeof(ServiceAttribute), true);
                    Services.Add(new KeyValuePair<string, int>(Attribute.Name, Attribute.Cost));
                }
            }
        }

        public virtual ObservableCollection<VehiclePart> GetParts()
        {
            return new ObservableCollection<VehiclePart>()
            {
                new Hull(),
                new Wheels(),
                new Breaks(),
                new Chassis()
            };
        }

        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            AverageState = Parts.Average(x => x.State);
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
