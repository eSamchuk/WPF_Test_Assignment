using System;

namespace STO.Model.Abstractions
{
    public interface ICarService
    {
        [Service(Cost = 100, Name = "Балансування коліс")]
        string BalanceWheels();
    }

}
