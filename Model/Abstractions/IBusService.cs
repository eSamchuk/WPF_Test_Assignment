using System;

namespace STO.Model.Abstractions
{
    public interface IBusService
    {
        [Service(Cost = 300, Name = "Заміна обивки крісел")]
        string ChangeUpholstery();
    }
}
