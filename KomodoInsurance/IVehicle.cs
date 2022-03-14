using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    public interface IVehicle // My interface
    {
        void TurnOn();
        void TurnOff();
        void Drive();
        string Make { get; set; }
        string Model { get; set; }
        string Color { get; set; }
        bool IsRunning { get;}
    }
}
