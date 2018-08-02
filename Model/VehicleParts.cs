using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using STO.Model.Abstractions;

namespace STO.Model
{
    [Description("Кузов")]
    public class Hull : VehiclePart { }

    [Description("Колеса")]
    public class Wheels : VehiclePart { }

    [Description("Двигун")]
    public class Engine : VehiclePart { }

    [Description("Гальма")]
    public class Breaks : VehiclePart { }

    [Description("Ходова")]
    public class Chassis : VehiclePart { }

    [Description("Гідравліка")]
    public class Hydraulics : VehiclePart { }

    [Description("Салон")]
    public class Interior : VehiclePart { }

    [Description("Поручні")]
    public class Handrail : VehiclePart { }

}
