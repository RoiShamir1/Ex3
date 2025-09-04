using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eLicenseType
    {
        A = 1,
        A1,
        AB,
        B1,
        A2,
        B2
    }
    public enum eFuelType
    {
        Octan98 = 1,
        Octan96,
        Octan95,
        Soler
    }
    public enum eCarDoorNumber
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }
    public enum eCarColor
    {
        Red = 1,
        Blue,
        White,
        Gray,
        Black,
        Yellow,
        Silver
    }

    public enum eStatus
    {
        InRepair = 1,
        Repaired,
        Paid
    }
}
