using System;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace STO.Model.Abstractions
{
    public abstract class VehiclePart : INotifyPropertyChanged
    {
        private short _state;

        [Range(0, 100)]
        public short State
        {
            get { return _state; }
            set
            {
                if (_state == value) return;
                _state = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get
            {
                var Attribute = (DescriptionAttribute)this.GetType().GetCustomAttributes(typeof(DescriptionAttribute), false).First();
                return Attribute.Description;
            }
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
