using System;

namespace STO.Model
{
    class ServiceAttribute : Attribute
    {
        public string Name { get; set; }
        public int Cost { get; set; }
    }
}
