using System;
using System.Collections.Generic;
using System.Text;
using XYZCorp.ParkingLot.Domain;

namespace XYZCorp.ParkingLot.BusinessLogic.Interfaces
{
    public interface IParkingBL
    {
        string GetStatus(int parkingStatus);
        int CalculateTotalHours(Parking parking);
        int CalculateExcessHours(Parking parking);
        decimal CalculateParkingCharge(Parking parking, SlotRate slotRates, BaseRate baseRates);
    }
}
