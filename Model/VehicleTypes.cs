using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using STO.Model.Abstractions;

namespace STO.Model
{
    public class Car : Vehicle, ICarService
    {
        public string BalanceWheels()
        {
            return "Колеса відбалансовані";
        }

        public override string ToString()
        {
            return "Легковий автомобіль";
        }
    }

    public class Truck : Vehicle
    {
        public override string ToString()
        {
            return "Вантажний автомобіль";
        }

        public override ObservableCollection<VehiclePart> GetParts()
        {
            var Result = base.GetParts();
            Result.Add(new Hydraulics());
            return Result;
        }

    }

    public class Bus : Vehicle, IBusService
    {
        public override ObservableCollection<VehiclePart> GetParts()
        {
            var Result = base.GetParts();
            Result.Add(new Handrail());
            Result.Add(new Interior());
            return Result;
        }


        public string ChangeUpholstery()
        {
            return "Обивку сидінь замінено";
        }

        public override string ToString()
        {
            return "Автобус";
        }
    }
}
