using System;
using System.Collections.Generic;
using System.Text;

namespace XYZCorp.ParkingLot.DTO
{
    public class BaseRateDto
    {
        //all vehicle types rate for the first 3 hours
        public decimal FlatRate { get; set; }

        //rate when vehicle exceeds 24 hours
        public decimal ExcessRate { get; set; }

        //A vehicle leaving the parking complex and returning within ParkingResetHours must be charged a continuous rate
        public int ResetHours { get; set; }
    }
}
